[← All experiments](../README.md) · [Technical manual](../docs/MANUAL.md) · [Theory](../docs/GRAPHICS_THEORY.md) · [Screenshots](../docs/SCREENSHOT_GALLERY.md)

# LAB 04 · Composite Transformations

> Combine multiple transformations—and respect their order

**Stack:** Python / NumPy / Pygame · **Course:** CS4104 Computer Graphics & Virtual Reality

## On this page

[Objective](#objective) · [Core concept](#core-concept) · [Worked example](#worked-example) · [How to run](#how-to-run) · [Captured outputs](#captured-outputs) · [Interpretation](#interpretation) · [Viva questions](#viva-questions)

## Objective

Instead of updating every vertex after each step, build a single matrix product that represents several geometric operations. Matrix multiplication order determines the result.

**Learning outcome:** Explain the method, locate its implementation in the supplied source, run the demonstration in the appropriate environment, and describe the observed output accurately.

## Core concept

The source explicitly uses **M = T(235,70) · R(35°) · S(1.25,0.85)** with column vectors. Therefore the shape is **scaled → rotated → translated**.

![CGVR learning progression: where this lab fits](../docs/assets/graphics-pipeline.svg)

## Worked example

If point (1,0) is scaled uniformly by 2 and then translated by (3,0), it becomes (5,0); translating first and then scaling produces (8,0). This shows why S·T and T·S differ.

## Algorithm / implementation trace

```text
Build separate Scale, Rotate and Translate matrices
Multiply to obtain M = T @ R @ S
For each polygon vertex, compute M @ [x, y, 1]^T
Draw original and resulting outlines
```

## Source & files

| File / folder | Purpose |
|---|---|
| [`composite_transformations_lab4.py`](composite_transformations_lab4.py) | Matrix composition and transformed polygon |
| [`composite_transformations_lab4.ipynb`](composite_transformations_lab4.ipynb) | Notebook version |

## How to run

From the **repository root**, install the [Python dependencies](../docs/GETTING_STARTED.md) and run:

```bash
python lab4/composite_transformations_lab4.py
```

Run one command at a time; each program opens a desktop graphics window.

## Captured outputs

**Capture pending:** This lab has source code but no verified screenshot committed to the repository. Do not use an AI-generated substitute.

**Evidence status:** Runtime capture is pending; the diagram above is a conceptual learning-path illustration, not a screenshot.

## Interpretation

1. The code defines a sample polygon and computes a composite matrix.
2. The visual result should show transformed and original outlines in the same view.
3. No genuine committed Lab 4 runtime screenshot is available, so visual comparisons here describe source intent.

### Common misunderstanding

Writing operations in spoken order does not guarantee the same matrix order. With column vectors, the rightmost matrix operates first.

## Viva questions

1. Why is matrix multiplication generally noncommutative?
2. Which transformation is applied first in T·R·S?
3. What happens when the rotation centre changes?

For explanations, use the [graphics theory reference](../docs/GRAPHICS_THEORY.md) and refer to the actual source file rather than treating a screenshot as complete proof of correctness.

## Explore next

- [Lab 03 — individual transformations](../lab3/README.md)
- [Lab 10 — model/view/projection](../lab10/README.md)

[**← Lab index**](../README.md#laboratory-index) · [Manual](../docs/MANUAL.md) · [Evidence status](../docs/EVIDENCE_STATUS.md)

---

<sub>CGVR Laboratory · Munnaluri Rishikesh · RV University</sub>
