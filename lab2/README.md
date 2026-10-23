[← All labs](../README.md) · [Screenshot gallery](../docs/SCREENSHOT_GALLERY.md) · [Setup](../docs/GETTING_STARTED.md)

# Lab 02 / Midpoint Circle Drawing

> Draw a circle efficiently using decision parameters and eight-way symmetry.

**Stack:** Python · Pygame

## Objective

Draw a circle efficiently using decision parameters and eight-way symmetry. This experiment is part of the **CS4104 Computer Graphics and Virtual Reality** lab collection.

## Concept

Start at `(x, y) = (0, r)` with `p = 1 − r`. At each iteration, a decision parameter selects the next point. Plot its eight symmetric positions to complete the circle without trigonometry for every pixel.

## Files

| Asset | Role |
|---|---|
| [`midpoint_circle_lab2.py`](./midpoint_circle_lab2.py) | Python source |
| [`midpoint_circle_lab2.ipynb`](./midpoint_circle_lab2.ipynb) | Jupyter notebook |

## Run

After installing [repository dependencies](../docs/GETTING_STARTED.md), execute from the **repository root**:

```bash
python lab2/midpoint_circle_lab2.py
```

The program opens a Pygame/OpenGL window. Close it normally or use `Esc` where supported.

## Captured outputs

**Figure 2.1 — midpoint circle output lab2 (original lab output)**

[![Lab 2 screenshot 1](./midpoint_circle_output_lab2.png)](./midpoint_circle_output_lab2.png)

## What to observe

- The rendered output uses eight-way symmetry around a shared centre.
- A decision variable chooses candidate lattice points along one octant.

## Evidence note

Images in this page link to files already committed in the repository. A saved PNG does not by itself establish recent performance metrics or confirm that a separate Unity project compiled on another system.

---

[**Back to CGVR collection**](../README.md) · [Source provenance](../SOURCE_REPOS.md)
