[← All experiments](../README.md) · [Technical manual](../docs/MANUAL.md) · [Theory](../docs/GRAPHICS_THEORY.md) · [Screenshots](../docs/SCREENSHOT_GALLERY.md)

# LAB 06 · Z-Buffer Hidden-Surface Removal

> Which overlapping surface is actually visible?

**Stack:** Python / Pygame / PyOpenGL · **Course:** CS4104 Computer Graphics & Virtual Reality

## On this page

[Objective](#objective) · [Core concept](#core-concept) · [Worked example](#worked-example) · [How to run](#how-to-run) · [Captured outputs](#captured-outputs) · [Interpretation](#interpretation) · [Viva questions](#viva-questions)

## Objective

Even when multiple triangles cover the same screen pixel, only the nearest visible fragment should contribute to the final surface image. The depth test checks which fragment wins.

**Learning outcome:** Explain the method, locate its implementation in the supplied source, run the demonstration in the appropriate environment, and describe the observed output accurately.

## Core concept

The source requests a **24-bit depth buffer** and compares two render states: GL_DEPTH_TEST disabled in one viewport and enabled in the other. Depth values are tested when fragments are rasterized.

![CGVR learning progression: where this lab fits](../docs/assets/graphics-pipeline.svg)

## Worked example

Imagine a foreground red triangle overlapping a background blue triangle. With depth testing enabled, the nearer fragments remain visible regardless of triangle submission order; without a depth test, draw order can change apparent visibility.

## Algorithm / implementation trace

```text
Allocate a colour buffer and depth buffer
Left viewport: disable depth testing; draw scene
Right viewport: enable depth testing; draw scene
Compare overlap visibility
```

## Source & files

| File / folder | Purpose |
|---|---|
| [`z_buffer_hidden_surface_removal_lab6.py`](z_buffer_hidden_surface_removal_lab6.py) | Two OpenGL viewports, depth test comparison |
| [`z_buffer_hidden_surface_removal_lab6.ipynb`](z_buffer_hidden_surface_removal_lab6.ipynb) | Notebook version |

## How to run

From the **repository root**, install the [Python dependencies](../docs/GETTING_STARTED.md) and run:

```bash
python lab6/z_buffer_hidden_surface_removal_lab6.py
```

Run one command at a time; each program opens a desktop graphics window.

## Captured outputs

<a href="z_buffer_output_lab6.png"><img src="z_buffer_output_lab6.png" alt="Original OpenGL Z-buffer comparison" width="760"></a>

**Figure 6.1.** Original OpenGL Z-buffer comparison. Select the image to open its committed original file.

**Source of these figures:** Existing lab-program output images preserved in this repository. These are genuine stored output captures, not newly executed screenshots.

## Interpretation

1. The original screenshot contains side-by-side visibility output.
2. Z-buffering is distinct from sorting a scene globally: fragments are compared at each screen sample.
3. Depth-buffer state and clearing matter across multiple viewports.

### Common misunderstanding

Depth testing cannot work without a valid depth attachment or depth-buffer clear. The program requests a 24-bit buffer and clears depth appropriately.

## Viva questions

1. Why is a Z-buffer useful with intersecting objects?
2. What is stored in the depth buffer?
3. What changes when GL_DEPTH_TEST is disabled?

For explanations, use the [graphics theory reference](../docs/GRAPHICS_THEORY.md) and refer to the actual source file rather than treating a screenshot as complete proof of correctness.

## Explore next

- [Lab 07 — lighting](../lab7/README.md)
- [Lab 10 — projected scene](../lab10/README.md)

[**← Lab index**](../README.md#laboratory-index) · [Manual](../docs/MANUAL.md) · [Evidence status](../docs/EVIDENCE_STATUS.md)

---

<sub>CGVR Laboratory · Munnaluri Rishikesh · RV University</sub>
