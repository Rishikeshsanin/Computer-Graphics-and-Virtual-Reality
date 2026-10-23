[← All experiments](../README.md) · [Technical manual](../docs/MANUAL.md) · [Theory](../docs/GRAPHICS_THEORY.md) · [Screenshots](../docs/SCREENSHOT_GALLERY.md)

# LAB 05 · Cohen–Sutherland Line Clipping

> Accept, reject or intersect against a rectangle

**Stack:** Python / Pygame / PyOpenGL · **Course:** CS4104 Computer Graphics & Virtual Reality

## On this page

[Objective](#objective) · [Core concept](#core-concept) · [Worked example](#worked-example) · [How to run](#how-to-run) · [Captured outputs](#captured-outputs) · [Interpretation](#interpretation) · [Viva questions](#viva-questions)

## Objective

Before rasterizing a line inside a window, clip segments that extend beyond its rectangular boundaries. Region codes make some decisions immediate.

**Learning outcome:** Explain the method, locate its implementation in the supplied source, run the demonstration in the appropriate environment, and describe the observed output accurately.

## Core concept

Each endpoint receives four bits: LEFT=1, RIGHT=2, BOTTOM=4, TOP=8 (INSIDE=0 in source). If both codes are zero, accept. If bitwise AND is nonzero, reject. Otherwise intersect an outside endpoint with a boundary.

![CGVR learning progression: where this lab fits](../docs/assets/graphics-pipeline.svg)

## Worked example

For a segment whose two endpoints both lie above the top edge, both TOP bits are set, so `code1 & code2 ≠ 0` and the segment is rejected without solving any intersection.

## Algorithm / implementation trace

```text
Compute 4-bit outcode for each endpoint
Loop:
  If both outcodes == 0: accept
  If (outcode1 & outcode2) != 0: reject
  Choose outside endpoint and clip at a window boundary
  Replace endpoint; recompute its outcode
```

## Source & files

| File / folder | Purpose |
|---|---|
| [`cohen_sutherland_line_clipping_lab5.py`](cohen_sutherland_line_clipping_lab5.py) | Outcode generation and line clipping |
| [`cohen_sutherland_line_clipping_lab5.ipynb`](cohen_sutherland_line_clipping_lab5.ipynb) | Notebook version |

## How to run

From the **repository root**, install the [Python dependencies](../docs/GETTING_STARTED.md) and run:

```bash
python lab5/cohen_sutherland_line_clipping_lab5.py
```

Run one command at a time; each program opens a desktop graphics window.

## Captured outputs

<a href="cohen_sutherland_output_lab5.png"><img src="cohen_sutherland_output_lab5.png" alt="Original OpenGL clipping output" width="760"></a>

**Figure 5.1.** Original OpenGL clipping output. Select the image to open its committed original file.

**Source of these figures:** Existing lab-program output images preserved in this repository. These are genuine stored output captures, not newly executed screenshots.

## Interpretation

1. Compare the original line to the portion kept within the clipping window.
2. Trivial rejection needs only bitwise comparison.
3. Segments crossing a boundary are replaced by calculated intersection coordinates.

### Common misunderstanding

Clipping is a geometric operation before rasterization. Do not mistake it for merely hiding line segments outside a rectangle with a visual overlay.

## Viva questions

1. Why do outcodes accelerate clipping?
2. What does nonzero bitwise AND prove?
3. Which boundary is chosen when several outcode bits are set?

For explanations, use the [graphics theory reference](../docs/GRAPHICS_THEORY.md) and refer to the actual source file rather than treating a screenshot as complete proof of correctness.

## Explore next

- [Lab 01 — rasterization](../lab1/README.md)
- [Lab 10 — viewing pipeline](../lab10/README.md)

[**← Lab index**](../README.md#laboratory-index) · [Manual](../docs/MANUAL.md) · [Evidence status](../docs/EVIDENCE_STATUS.md)

---

<sub>CGVR Laboratory · Munnaluri Rishikesh · RV University</sub>
