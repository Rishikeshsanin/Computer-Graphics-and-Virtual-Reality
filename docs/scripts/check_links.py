#!/usr/bin/env python3
"""Validate relative Markdown links and HTML href/src targets in repository docs.

No external network requests, no third-party packages. This checks existence,
not remote URL availability, the semantics of anchors or runtime screenshots.
"""
from __future__ import annotations

import re
import sys
from pathlib import Path
from urllib.parse import unquote, urlsplit

ROOT = Path(__file__).resolve().parents[2]
MARKDOWN_LINK = re.compile(r'!?\[[^\]\n]*\]\(([^)\n]+)\)')
HTML_LINK = re.compile(r'(?:href|src)\s*=\s*["\']([^"\']+)["\']', re.IGNORECASE)
FENCED = re.compile(r'^```.*?^```\s*$', re.MULTILINE | re.DOTALL)
INLINE_CODE = re.compile(r'`[^\n`]+`')
EXTERNAL = re.compile(r'^(?:[a-zA-Z][\w+.-]*:|//|#)')

def targets(markdown: str):
    clean = FENCED.sub('', markdown)
    clean = INLINE_CODE.sub('', clean)
    yield from (m.group(1) for m in MARKDOWN_LINK.finditer(clean))
    yield from (m.group(1) for m in HTML_LINK.finditer(clean))

def validate(path: Path):
    errors = []
    count = 0
    content = path.read_text(encoding="utf-8")
    for raw in targets(content):
        raw = raw.strip().strip("<>")
        if not raw or EXTERNAL.match(raw):
            continue
        # GitHub Markdown can contain a quoted title; not used for these docs.
        href = raw.split()[0] if " " in raw and not raw.startswith(("..", "./")) else raw
        relative = unquote(urlsplit(href).path)
        if not relative:
            continue
        resolved = (path.parent / relative).resolve()
        count += 1
        if not resolved.is_relative_to(ROOT.resolve()):
            errors.append(f"{path.relative_to(ROOT)}: path escapes repository: {raw}")
        elif not resolved.exists():
            errors.append(f"{path.relative_to(ROOT)}: missing local target: {raw}")
    return count, errors

def main():
    paths = [ROOT / "README.md", *ROOT.glob("docs/**/*.md"),
             *ROOT.glob("lab*/README.md"),
             *ROOT.glob("lab*/Unity_*/README.md"),
             *ROOT.glob("CASE STUDY CIE3/**/README.md")]
    docs = sorted(set(path for path in paths if path.is_file()))
    seen, failures = 0, []
    for path in docs:
        count, errors = validate(path)
        seen += count
        failures.extend(errors)
    print(f"Checked {seen} relative links/images in {len(docs)} Markdown documents")
    for error in failures:
        print("ERROR:", error)
    return 1 if failures else 0

if __name__ == "__main__":
    sys.exit(main())
