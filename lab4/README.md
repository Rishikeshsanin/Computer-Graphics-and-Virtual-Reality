[← All labs](../README.md) · [Screenshot gallery](../docs/SCREENSHOT_GALLERY.md) · [Setup](../docs/GETTING_STARTED.md)

# Lab 04 / Composite Transformations

> Demonstrate why matrix multiplication order matters.

**Stack:** Python · NumPy · Pygame

## Objective

Demonstrate why matrix multiplication order matters. This experiment is part of the **CS4104 Computer Graphics and Virtual Reality** lab collection.

## Concept

The source constructs `M = T(235, 70) @ R(35°) @ S(1.25, 0.85)`. With column vectors, scaling is applied first, then rotation, then translation. The resulting polygon is drawn alongside the original.

## Files

| Asset | Role |
|---|---|
| [`composite_transformations_lab4.py`](./composite_transformations_lab4.py) | Python source |
| [`composite_transformations_lab4.ipynb`](./composite_transformations_lab4.ipynb) | Jupyter notebook |

## Run

After installing [repository dependencies](../docs/GETTING_STARTED.md), execute from the **repository root**:

```bash
python lab4/composite_transformations_lab4.py
```

The program opens a Pygame/OpenGL window. Close it normally or use `Esc` where supported.

## Captured outputs

_No genuine screenshot has been committed for this lab. The executable source is present; capture a local run before inserting an output image._

## What to observe

- Matrix composition produces a single transform from three operations.
- A genuine runtime screenshot has not yet been committed for this lab.

## Evidence note

Images in this page link to files already committed in the repository. A saved PNG does not by itself establish recent performance metrics or confirm that a separate Unity project compiled on another system.

---

[**Back to CGVR collection**](../README.md) · [Source provenance](../SOURCE_REPOS.md)
