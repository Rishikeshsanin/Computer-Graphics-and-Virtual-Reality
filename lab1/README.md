[← All experiments](../README.md) · [Technical manual](../docs/MANUAL.md) · [Theory](../docs/GRAPHICS_THEORY.md) · [Screenshots](../docs/SCREENSHOT_GALLERY.md)

# LAB 01 · DDA and Bresenham Line Drawing

> Two routes from a mathematical line to discrete pixels

**Stack:** Python / Pygame · **Course:** CS4104 Computer Graphics & Virtual Reality

## On this page

[Objective](#objective) · [Core concept](#core-concept) · [Worked example](#worked-example) · [How to run](#how-to-run) · [Captured outputs](#captured-outputs) · [Interpretation](#interpretation) · [Viva questions](#viva-questions)

## Objective

A mathematical line has infinitely many locations, but a raster screen has discrete pixel coordinates. These programs show how an algorithm selects the pixels that approximate an ideal segment.

**Learning outcome:** Explain the method, locate its implementation in the supplied source, run the demonstration in the appropriate environment, and describe the observed output accurately.

## Core concept

DDA computes **dx**, **dy** and **steps = max(|dx|,|dy|)**; x and y advance by fractions of those differences. Bresenham tracks an integer error term and adjusts the pixel in the dominant and/or secondary axis as needed.

![CGVR learning progression: where this lab fits](../docs/assets/graphics-pipeline.svg)

## Worked example

For DDA from (0,0) to (3,2): steps = 3, Δx = 1, Δy ≈ 0.667. Rounded samples are (0,0), (1,1), (2,1), (3,2). This is a worked *illustration*; the scripts use their own demonstration endpoints.

## Algorithm / implementation trace

```text
DDA: choose the maximum axis distance as the step count
For each step: draw round(x), round(y); increment x and y

Bresenham: initialize dx, dy, directions and error
Draw current integer point; update error and x/y until endpoint
```

## Source & files

| File / folder | Purpose |
|---|---|
| [`dda_line_lab1.py`](dda_line_lab1.py) | Floating-point DDA implementation |
| [`dda_line_lab1.ipynb`](dda_line_lab1.ipynb) | Notebook version |
| [`bresenham_line_lab1.py`](bresenham_line_lab1.py) | Integer-error Bresenham implementation |
| [`bresenham_line_lab1.ipynb`](bresenham_line_lab1.ipynb) | Notebook version |

## How to run

From the **repository root**, install the [Python dependencies](../docs/GETTING_STARTED.md) and run:

```bash
python lab1/dda_line_lab1.py
python lab1/bresenham_line_lab1.py
```

Run one command at a time; each program opens a desktop graphics window.

## Captured outputs

<a href="dda_output_1_lab1.png"><img src="dda_output_1_lab1.png" alt="DDA: original captured output 1" width="440"></a>

**Figure 1.1.** DDA: original captured output 1. Select the image to open its committed original file.

<a href="dda_output_2_lab1.png"><img src="dda_output_2_lab1.png" alt="DDA: original captured output 2" width="440"></a>

**Figure 1.2.** DDA: original captured output 2. Select the image to open its committed original file.

<a href="bresenham_output_1_lab1.png"><img src="bresenham_output_1_lab1.png" alt="Bresenham: original captured output 1" width="440"></a>

**Figure 1.3.** Bresenham: original captured output 1. Select the image to open its committed original file.

<a href="bresenham_output_2_lab1.png"><img src="bresenham_output_2_lab1.png" alt="Bresenham: original captured output 2" width="440"></a>

**Figure 1.4.** Bresenham: original captured output 2. Select the image to open its committed original file.

**Source of these figures:** Existing lab-program output images preserved in this repository. These are genuine stored output captures, not newly executed screenshots.

## Interpretation

1. The programs use Pygame to render raster points on a grid alongside a reference line.
2. DDA explicitly rounds floating-point coordinates; Bresenham's core stepping logic operates on integers.
3. The committed files show two captures for each algorithm; results are examples, not performance benchmarks.

### Common misunderstanding

A diagonal may look jagged at low resolution: that is expected for pixel rasterization. Remember the image grid is discrete even when the mathematical segment is continuous.

## Viva questions

1. Why is DDA straightforward but potentially reliant on floating-point arithmetic?
2. How does Bresenham decide when to increment the second axis?
3. When would a line of zero length require special handling?

For explanations, use the [graphics theory reference](../docs/GRAPHICS_THEORY.md) and refer to the actual source file rather than treating a screenshot as complete proof of correctness.

## Explore next

- [Lab 02 — circle rasterization](../lab2/README.md)
- [Lab 05 — clipping](../lab5/README.md)

[**← Lab index**](../README.md#laboratory-index) · [Manual](../docs/MANUAL.md) · [Evidence status](../docs/EVIDENCE_STATUS.md)

---

<sub>CGVR Laboratory · Munnaluri Rishikesh · RV University</sub>
