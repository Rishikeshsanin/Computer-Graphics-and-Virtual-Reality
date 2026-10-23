[← All experiments](../README.md) · [Technical manual](../docs/MANUAL.md) · [Theory](../docs/GRAPHICS_THEORY.md) · [Screenshots](../docs/SCREENSHOT_GALLERY.md)

# LAB 03 · 2D Geometric Transformations

> Represent movement and reshaping as 3×3 matrices

**Stack:** Python / NumPy / Pygame · **Course:** CS4104 Computer Graphics & Virtual Reality

## On this page

[Objective](#objective) · [Core concept](#core-concept) · [Worked example](#worked-example) · [How to run](#how-to-run) · [Captured outputs](#captured-outputs) · [Interpretation](#interpretation) · [Viva questions](#viva-questions)

## Objective

A polygon is stored as points in homogeneous coordinates. Multiplication by a 3×3 matrix transforms its geometry while preserving a reusable, mathematically consistent representation.

**Learning outcome:** Explain the method, locate its implementation in the supplied source, run the demonstration in the appropriate environment, and describe the observed output accurately.

## Core concept

Translation uses T=[1,0,tx; 0,1,ty; 0,0,1]. Rotation uses cosθ and sinθ in the top-left 2×2 block. Scaling multiplies the x/y components separately. The source also implements x-axis reflection and shearing.

![CGVR learning progression: where this lab fits](../docs/assets/graphics-pipeline.svg)

## Worked example

With translation (tx,ty)=(3,−2), point (2,1,1) becomes (5,−1,1). This example illustrates homogeneous multiplication; actual source parameters are different.

## Algorithm / implementation trace

```text
Construct a 3x3 transformation matrix
Augment each 2D vertex with homogeneous w=1
Multiply matrix by each vertex column
Project the transformed 2D points into screen coordinates
Render original and result for comparison
```

## Source & files

| File / folder | Purpose |
|---|---|
| [`2d_transformations_lab3.py`](2d_transformations_lab3.py) | Translation, rotation, scaling, reflection and shear |
| [`2d_transformations_lab3.ipynb`](2d_transformations_lab3.ipynb) | Notebook version |

## How to run

From the **repository root**, install the [Python dependencies](../docs/GETTING_STARTED.md) and run:

```bash
python lab3/2d_transformations_lab3.py
```

Run one command at a time; each program opens a desktop graphics window.

## Captured outputs

<a href="2d_translation_output_lab3.png"><img src="2d_translation_output_lab3.png" alt="Original screenshot of the translation view" width="760"></a>

**Figure 3.1.** Original screenshot of the translation view. Select the image to open its committed original file.

**Source of these figures:** Existing lab-program output images preserved in this repository. These are genuine stored output captures, not newly executed screenshots.

## Interpretation

1. The Pygame display compares geometry against axes or a reference panel.
2. Translation changes position; rotation changes orientation; scaling changes size.
3. The committed screenshot shows translation—not proof that all transformations were separately captured.

### Common misunderstanding

The usual mathematical y-axis points upward, whereas pixel coordinates may increase downward. The source's `to_screen` function converts between conventions.

## Viva questions

1. Why use a 3×3 matrix instead of a 2×2 matrix for translation?
2. How does the origin affect rotation?
3. Why can shear change angles while preserving straight lines?

For explanations, use the [graphics theory reference](../docs/GRAPHICS_THEORY.md) and refer to the actual source file rather than treating a screenshot as complete proof of correctness.

## Explore next

- [Lab 04 — composite transformations](../lab4/README.md)
- [Theory and formulas](../docs/GRAPHICS_THEORY.md)

[**← Lab index**](../README.md#laboratory-index) · [Manual](../docs/MANUAL.md) · [Evidence status](../docs/EVIDENCE_STATUS.md)

---

<sub>CGVR Laboratory · Munnaluri Rishikesh · RV University</sub>
