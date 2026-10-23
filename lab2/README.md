[← All experiments](../README.md) · [Technical manual](../docs/MANUAL.md) · [Theory](../docs/GRAPHICS_THEORY.md) · [Screenshots](../docs/SCREENSHOT_GALLERY.md)

# LAB 02 · Midpoint Circle Algorithm

> One octant, eight-way symmetry

**Stack:** Python / Pygame · **Course:** CS4104 Computer Graphics & Virtual Reality

## On this page

[Objective](#objective) · [Core concept](#core-concept) · [Worked example](#worked-example) · [How to run](#how-to-run) · [Captured outputs](#captured-outputs) · [Interpretation](#interpretation) · [Viva questions](#viva-questions)

## Objective

A raster circle is built by deciding between adjacent pixel candidates in one octant and reflecting each accepted point across symmetry axes.

**Learning outcome:** Explain the method, locate its implementation in the supplied source, run the demonstration in the appropriate environment, and describe the observed output accurately.

## Core concept

For a radius r, initialize x=0, y=r and p=1−r. At every iteration advance x. If the decision parameter crosses the boundary, decrement y. Extend each computed pair to eight positions around (cx,cy).

![CGVR learning progression: where this lab fits](../docs/assets/graphics-pipeline.svg)

## Worked example

For radius r=5, start at (0,5), p=−4. The eight symmetric points are generated from this single octant sample. The source uses a larger radius for a clear on-screen visualization.

## Algorithm / implementation trace

```text
Set x=0, y=radius, decision=1-radius
While x<=y:
  Plot eight symmetric points about (cx,cy)
  Increment x; update decision
  Decrement y when the decision crosses the boundary
```

## Source & files

| File / folder | Purpose |
|---|---|
| [`midpoint_circle_lab2.py`](midpoint_circle_lab2.py) | Circle rasterization source |
| [`midpoint_circle_lab2.ipynb`](midpoint_circle_lab2.ipynb) | Notebook version |

## How to run

From the **repository root**, install the [Python dependencies](../docs/GETTING_STARTED.md) and run:

```bash
python lab2/midpoint_circle_lab2.py
```

Run one command at a time; each program opens a desktop graphics window.

## Captured outputs

<a href="midpoint_circle_output_lab2.png"><img src="midpoint_circle_output_lab2.png" alt="Original midpoint-circle output" width="760"></a>

**Figure 2.1.** Original midpoint-circle output. Select the image to open its committed original file.

**Source of these figures:** Existing lab-program output images preserved in this repository. These are genuine stored output captures, not newly executed screenshots.

## Interpretation

1. Points form a circular outline around one shared centre.
2. The eight-way symmetry reduces the number of unique calculations.
3. Small circles can show visibly uneven pixel spacing because of raster quantization.

### Common misunderstanding

The algorithm draws a discrete approximation, not a mathematically continuous curve. Duplicated symmetric pixels near axes are possible and do not imply extra geometry.

## Viva questions

1. What is the decision parameter used for?
2. Why is plotting eight symmetrical points valid?
3. How is this related to Bresenham-style raster decisions?

For explanations, use the [graphics theory reference](../docs/GRAPHICS_THEORY.md) and refer to the actual source file rather than treating a screenshot as complete proof of correctness.

## Explore next

- [Lab 01 — raster lines](../lab1/README.md)
- [Lab 03 — 2D transformations](../lab3/README.md)

[**← Lab index**](../README.md#laboratory-index) · [Manual](../docs/MANUAL.md) · [Evidence status](../docs/EVIDENCE_STATUS.md)

---

<sub>CGVR Laboratory · Munnaluri Rishikesh · RV University</sub>
