[← All labs](../README.md) · [Screenshot gallery](../docs/SCREENSHOT_GALLERY.md) · [Setup](../docs/GETTING_STARTED.md)

# Lab 05 / Cohen–Sutherland Line Clipping

> Clip segments to a rectangular viewing window using 4-bit region codes.

**Stack:** Python · Pygame · PyOpenGL

## Objective

Clip segments to a rectangular viewing window using 4-bit region codes. This experiment is part of the **CS4104 Computer Graphics and Virtual Reality** lab collection.

## Concept

Each endpoint gets an outcode with left/right/top/bottom bits. Accept when both codes are zero; reject when their bitwise AND is non-zero; otherwise intersect against a boundary and repeat.

## Files

| Asset | Role |
|---|---|
| [`cohen_sutherland_line_clipping_lab5.py`](./cohen_sutherland_line_clipping_lab5.py) | Python source |
| [`cohen_sutherland_line_clipping_lab5.ipynb`](./cohen_sutherland_line_clipping_lab5.ipynb) | Jupyter notebook |

## Run

After installing [repository dependencies](../docs/GETTING_STARTED.md), execute from the **repository root**:

```bash
python lab5/cohen_sutherland_line_clipping_lab5.py
```

The program opens a Pygame/OpenGL window. Close it normally or use `Esc` where supported.

## Captured outputs

**Figure 5.1 — cohen sutherland output lab5 (original lab output)**

[![Lab 5 screenshot 1](./cohen_sutherland_output_lab5.png)](./cohen_sutherland_output_lab5.png)

## What to observe

- The OpenGL view compares a segment's original extent with the clipped region.
- An accepted clipped segment lies within the window bounds.

## Evidence note

Images in this page link to files already committed in the repository. A saved PNG does not by itself establish recent performance metrics or confirm that a separate Unity project compiled on another system.

---

[**Back to CGVR collection**](../README.md) · [Source provenance](../SOURCE_REPOS.md)
