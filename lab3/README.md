[← All labs](../README.md) · [Screenshot gallery](../docs/SCREENSHOT_GALLERY.md) · [Setup](../docs/GETTING_STARTED.md)

# Lab 03 / 2D Geometric Transformations

> Apply translation, rotation, scaling, reflection and shearing with homogeneous coordinates.

**Stack:** Python · NumPy · Pygame

## Objective

Apply translation, rotation, scaling, reflection and shearing with homogeneous coordinates. This experiment is part of the **CS4104 Computer Graphics and Virtual Reality** lab collection.

## Concept

Represent points as homogeneous column vectors `[x y 1]ᵀ`. Multiply by 3×3 matrices for translation, rotation, scaling, reflection, or shear. Compare the original polygon with each transformed result.

## Files

| Asset | Role |
|---|---|
| [`2d_transformations_lab3.py`](./2d_transformations_lab3.py) | Python source |
| [`2d_transformations_lab3.ipynb`](./2d_transformations_lab3.ipynb) | Jupyter notebook |

## Run

After installing [repository dependencies](../docs/GETTING_STARTED.md), execute from the **repository root**:

```bash
python lab3/2d_transformations_lab3.py
```

The program opens a Pygame/OpenGL window. Close it normally or use `Esc` where supported.

## Captured outputs

**Figure 3.1 — 2d translation output lab3 (original lab output)**

[![Lab 3 screenshot 1](./2d_translation_output_lab3.png)](./2d_translation_output_lab3.png)

## What to observe

- The program illustrates multiple transformation types.
- The committed screenshot documents a translation view; it is not evidence of a separate screenshot for every transformation.

## Evidence note

Images in this page link to files already committed in the repository. A saved PNG does not by itself establish recent performance metrics or confirm that a separate Unity project compiled on another system.

---

[**Back to CGVR collection**](../README.md) · [Source provenance](../SOURCE_REPOS.md)
