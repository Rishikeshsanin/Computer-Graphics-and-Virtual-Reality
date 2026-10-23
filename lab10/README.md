[← All experiments](../README.md) · [Technical manual](../docs/MANUAL.md) · [Theory](../docs/GRAPHICS_THEORY.md) · [Screenshots](../docs/SCREENSHOT_GALLERY.md)

# LAB 10 · 3D Viewing Pipeline and Projection

> One cube, two views: orthographic against perspective

**Stack:** Python / PyOpenGL and Unity 6000.3.0f1 · **Course:** CS4104 Computer Graphics & Virtual Reality

## On this page

[Objective](#objective) · [Core concept](#core-concept) · [Worked example](#worked-example) · [How to run](#how-to-run) · [Captured outputs](#captured-outputs) · [Interpretation](#interpretation) · [Viva questions](#viva-questions)

## Objective

Viewing and projection convert 3D world geometry into pixels. Orthographic and perspective matrices map the same cube differently even from a shared camera position.

**Learning outcome:** Explain the method, locate its implementation in the supplied source, run the demonstration in the appropriate environment, and describe the observed output accurately.

## Core concept

The code uses look-at camera position **(4,3,6)** toward origin, rotates a six-colour cube, and shows **left orthographic** and **right perspective (45° FOV)** views in half-width viewports.

![CGVR learning progression: where this lab fits](../docs/assets/graphics-pipeline.svg)

## Worked example

In orthographic projection, moving a given object farther away does not automatically reduce its projected size. In perspective projection, farther points are foreshortened. The screenshots compare both projection choices for the cube.

## Algorithm / implementation trace

```text
Create 8 cube vertices, 6 faces and 12 edges
For each frame: clear colour/depth and update rotation
Configure left half viewport and orthographic projection; draw cube
Configure right half viewport and perspective projection; draw cube
Display both results
```

## Source & files

| File / folder | Purpose |
|---|---|
| [`3d_viewing_pipeline_lab10.py`](3d_viewing_pipeline_lab10.py) | Python/OpenGL dual viewport implementation |
| [`3d_viewing_pipeline_lab10.ipynb`](3d_viewing_pipeline_lab10.ipynb) | Notebook version |
| [Dedicated Unity source and setup guide](Unity_3D_Viewing_Pipeline/README.md) | Scene, C# script, custom shader and project settings |

## How to run

From the **repository root**, install the [Python dependencies](../docs/GETTING_STARTED.md) and run:

```bash
python lab10/3d_viewing_pipeline_lab10.py
```

Run one command at a time; each program opens a desktop graphics window.

**Unity alternative:** [Open Unity_3D_Viewing_Pipeline setup →](Unity_3D_Viewing_Pipeline/README.md). Add that exact folder in Unity Hub, open its saved scene and press Play. Its runtime output is **not** the same screenshot as the earlier OpenGL capture.

## Captured outputs

<a href="3d_viewing_pipeline_output_1_lab10.png"><img src="3d_viewing_pipeline_output_1_lab10.png" alt="OpenGL projected cube: original screenshot 1" width="440"></a>

**Figure 10.1.** OpenGL projected cube: original screenshot 1. Select the image to open its committed original file.

<a href="3d_viewing_pipeline_output_2_lab10.png"><img src="3d_viewing_pipeline_output_2_lab10.png" alt="OpenGL projected cube: original screenshot 2" width="440"></a>

**Figure 10.2.** OpenGL projected cube: original screenshot 2. Select the image to open its committed original file.

**Source of these figures:** Existing Python/OpenGL output images preserved in this repository. These are genuine stored output captures, not newly executed screenshots.

## Interpretation

1. Two original screenshots exist for the Python/OpenGL program.
2. The Unity port creates a shared cube and two cameras with separate viewport rectangles.
3. The new Unity build has source and saved scene but requires its own local Play-mode screenshot.

### Common misunderstanding

The two projections do not mean two different cubes; it is the same scene viewed through different projection transforms. Depth testing is required for correct face visibility.

## Viva questions

1. What does the view matrix do before projection?
2. Why do distant objects shrink in perspective but not orthographic projection?
3. How do two cameras map into left/right halves of one Game window?

For explanations, use the [graphics theory reference](../docs/GRAPHICS_THEORY.md) and refer to the actual source file rather than treating a screenshot as complete proof of correctness.

## Explore next

- [Unity Lab 10 — open project](Unity_3D_Viewing_Pipeline/README.md)
- [CIE3 viewport transformation](../CASE%20STUDY%20CIE3/README.md)

[**← Lab index**](../README.md#laboratory-index) · [Manual](../docs/MANUAL.md) · [Evidence status](../docs/EVIDENCE_STATUS.md)

---

<sub>CGVR Laboratory · Munnaluri Rishikesh · RV University</sub>
