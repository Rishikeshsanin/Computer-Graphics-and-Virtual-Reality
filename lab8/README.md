[← All experiments](../README.md) · [Technical manual](../docs/MANUAL.md) · [Theory](../docs/GRAPHICS_THEORY.md) · [Screenshots](../docs/SCREENSHOT_GALLERY.md)

# LAB 08 · Vertex and Fragment Shaders

> Follow a rotating RGB triangle through GPU shader stages

**Stack:** Python / OpenGL 3.3 GLSL and Unity 6000.3.0f1 · **Course:** CS4104 Computer Graphics & Virtual Reality

## On this page

[Objective](#objective) · [Core concept](#core-concept) · [Worked example](#worked-example) · [How to run](#how-to-run) · [Captured outputs](#captured-outputs) · [Interpretation](#interpretation) · [Viva questions](#viva-questions)

## Objective

A programmable graphics pipeline uses a vertex shader to transform positions and pass attributes, then interpolates those attributes for covered fragments before a fragment shader outputs colour.

**Learning outcome:** Explain the method, locate its implementation in the supplied source, run the demonstration in the appropriate environment, and describe the observed output accurately.

## Core concept

The vertex stage applies a two-dimensional rotation **x′ = x cosθ − y sinθ**, **y′ = x sinθ + y cosθ**. Red, green and blue values assigned at triangle vertices interpolate smoothly across interior fragments.

![CGVR learning progression: where this lab fits](../docs/assets/graphics-pipeline.svg)

## Worked example

The source sets triangle points (0,0.65) red, (−0.60,−0.50) green and (0.60,−0.50) blue. It updates a uniform angle every frame. The Unity version uses analogous vertex and fragment programs.

## Algorithm / implementation trace

```text
Create an OpenGL 3.3 context, VAO and VBO
Upload three XY positions and RGB colours
Compile vertex/fragment shaders and link program
Every frame: update angle uniform, draw three vertices
GPU rotates vertex positions and interpolates fragment colour
```

## Source & files

| File / folder | Purpose |
|---|---|
| [`vertex_fragment_shaders_lab8.py`](vertex_fragment_shaders_lab8.py) | Python/OpenGL GLSL 330 implementation |
| [`vertex_fragment_shaders_lab8.ipynb`](vertex_fragment_shaders_lab8.ipynb) | Notebook version |
| [Dedicated Unity source and setup guide](Unity_Vertex_Fragment_Shaders/README.md) | Scene, C# script, custom shader and project settings |

## How to run

From the **repository root**, install the [Python dependencies](../docs/GETTING_STARTED.md) and run:

```bash
python lab8/vertex_fragment_shaders_lab8.py
```

Run one command at a time; each program opens a desktop graphics window.

**Unity alternative:** [Open Unity_Vertex_Fragment_Shaders setup →](Unity_Vertex_Fragment_Shaders/README.md). Add that exact folder in Unity Hub, open its saved scene and press Play. Its runtime output is **not** the same screenshot as the earlier OpenGL capture.

## Captured outputs

<a href="vertex_fragment_shaders_output_lab8.png"><img src="vertex_fragment_shaders_output_lab8.png" alt="Original Python/OpenGL shader screenshot" width="760"></a>

**Figure 8.1.** Original Python/OpenGL shader screenshot. Select the image to open its committed original file.

**Source of these figures:** Existing Python/OpenGL output images preserved in this repository. These are genuine stored output captures, not newly executed screenshots.

## Interpretation

1. The committed screenshot records the Python/OpenGL implementation, not Unity.
2. RGB gradients appear across the triangle because attributes interpolate.
3. The Unity implementation lives in a separate project folder; its first runtime screenshot is still pending.

### Common misunderstanding

A missing OpenGL 3.3 core context can prevent the Python GLSL program from compiling. For the Unity version, use the Built-in Render Pipeline and inspect the Editor Console.

## Viva questions

1. Which work happens in the vertex stage versus fragment stage?
2. Why does the triangle show intermediate colours?
3. Why must the rotation angle be uploaded as a uniform?

For explanations, use the [graphics theory reference](../docs/GRAPHICS_THEORY.md) and refer to the actual source file rather than treating a screenshot as complete proof of correctness.

## Explore next

- [Unity Lab 08 — open project](Unity_Vertex_Fragment_Shaders/README.md)
- [Lab 07 — illumination](../lab7/README.md)

[**← Lab index**](../README.md#laboratory-index) · [Manual](../docs/MANUAL.md) · [Evidence status](../docs/EVIDENCE_STATUS.md)

---

<sub>CGVR Laboratory · Munnaluri Rishikesh · RV University</sub>
