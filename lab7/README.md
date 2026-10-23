[← All labs](../README.md) · [Screenshot gallery](../docs/SCREENSHOT_GALLERY.md) · [Setup](../docs/GETTING_STARTED.md)

# Lab 07 / Phong Illumination Model

> Inspect ambient, diffuse and specular terms on a lit 3D object.

**Stack:** Python · Pygame · PyOpenGL

## Objective

Inspect ambient, diffuse and specular terms on a lit 3D object. This experiment is part of the **CS4104 Computer Graphics and Virtual Reality** lab collection.

## Concept

The OpenGL example configures ambient, diffuse and specular light/material parameters and a shininess exponent. Reflected light varies with light direction, surface normal and view direction.

## Files

| Asset | Role |
|---|---|
| [`phong_illumination_lab7.py`](./phong_illumination_lab7.py) | Python source |
| [`phong_illumination_lab7.ipynb`](./phong_illumination_lab7.ipynb) | Jupyter notebook |

## Run

After installing [repository dependencies](../docs/GETTING_STARTED.md), execute from the **repository root**:

```bash
python lab7/phong_illumination_lab7.py
```

The program opens a Pygame/OpenGL window. Close it normally or use `Esc` where supported.

## Captured outputs

**Figure 7.1 — phong illumination output lab7 (original lab output)**

[![Lab 7 screenshot 1](./phong_illumination_output_lab7.png)](./phong_illumination_output_lab7.png)

## What to observe

- The lighting model makes the red material look dimensional rather than flat.
- The committed PNG is an OpenGL output, not the separate CIE3 Unity shader screenshot.

## Evidence note

Images in this page link to files already committed in the repository. A saved PNG does not by itself establish recent performance metrics or confirm that a separate Unity project compiled on another system.

---

[**Back to CGVR collection**](../README.md) · [Source provenance](../SOURCE_REPOS.md)
