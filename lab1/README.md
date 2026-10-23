[← All labs](../README.md) · [Screenshot gallery](../docs/SCREENSHOT_GALLERY.md) · [Setup](../docs/GETTING_STARTED.md)

# Lab 01 / Line Rasterization · DDA & Bresenham

> Compare floating-point incremental rasterization with an integer decision-error line algorithm.

**Stack:** Python · Pygame

## Objective

Compare floating-point incremental rasterization with an integer decision-error line algorithm. This experiment is part of the **CS4104 Computer Graphics and Virtual Reality** lab collection.

## Concept

DDA chooses `steps = max(|dx|, |dy|)` and advances by fractional x/y increments. Bresenham instead updates an integer error term to choose raster pixels. The visual comparison highlights discretization decisions on a pixel grid.

## Files

| Asset | Role |
|---|---|
| [`dda_line_lab1.py`](./dda_line_lab1.py) | Python source |
| [`bresenham_line_lab1.py`](./bresenham_line_lab1.py) | Python source |
| [`dda_line_lab1.ipynb`](./dda_line_lab1.ipynb) | Jupyter notebook |
| [`bresenham_line_lab1.ipynb`](./bresenham_line_lab1.ipynb) | Jupyter notebook |

## Run

After installing [repository dependencies](../docs/GETTING_STARTED.md), execute from the **repository root**:

```bash
python lab1/dda_line_lab1.py
python lab1/bresenham_line_lab1.py
```

The program opens a Pygame/OpenGL window. Close it normally or use `Esc` where supported.

## Captured outputs

**Figure 1.1 — dda output 1 lab1 (original lab output)**

[![Lab 1 screenshot 1](./dda_output_1_lab1.png)](./dda_output_1_lab1.png)

**Figure 1.2 — dda output 2 lab1 (original lab output)**

[![Lab 1 screenshot 2](./dda_output_2_lab1.png)](./dda_output_2_lab1.png)

**Figure 1.3 — bresenham output 1 lab1 (original lab output)**

[![Lab 1 screenshot 3](./bresenham_output_1_lab1.png)](./bresenham_output_1_lab1.png)

**Figure 1.4 — bresenham output 2 lab1 (original lab output)**

[![Lab 1 screenshot 4](./bresenham_output_2_lab1.png)](./bresenham_output_2_lab1.png)

## What to observe

- The output window draws a reference line with highlighted computed raster points.
- Both methods output an ordered set of integer pixel coordinates.
- The algorithms address the same goal with different incremental arithmetic.

## Evidence note

Images in this page link to files already committed in the repository. A saved PNG does not by itself establish recent performance metrics or confirm that a separate Unity project compiled on another system.

---

[**Back to CGVR collection**](../README.md) · [Source provenance](../SOURCE_REPOS.md)
