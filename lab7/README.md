[← All experiments](../README.md) · [Technical manual](../docs/MANUAL.md) · [Theory](../docs/GRAPHICS_THEORY.md) · [Screenshots](../docs/SCREENSHOT_GALLERY.md)

# LAB 07 · Phong Illumination Model

> Ambient, diffuse and specular terms make form readable

**Stack:** Python / Pygame / PyOpenGL · **Course:** CS4104 Computer Graphics & Virtual Reality

## On this page

[Objective](#objective) · [Core concept](#core-concept) · [Worked example](#worked-example) · [How to run](#how-to-run) · [Captured outputs](#captured-outputs) · [Interpretation](#interpretation) · [Viva questions](#viva-questions)

## Objective

A 3D surface does not look dimensional from base colour alone. A reflection model combines a constant ambient contribution, angle-dependent diffuse light and viewer-dependent specular highlights.

**Learning outcome:** Explain the method, locate its implementation in the supplied source, run the demonstration in the appropriate environment, and describe the observed output accurately.

## Core concept

**I = Ia·ka + Ip·[kd·max(0,N·L) + ks·max(0,R·V)^n]** is the conceptual model. The source sets OpenGL ambient, diffuse, specular and shininess properties, smooth shading and a positioned light.

![CGVR learning progression: where this lab fits](../docs/assets/graphics-pipeline.svg)

## Worked example

When N and L point in the same direction, N·L = 1 gives strong diffuse reflection. When N·L ≤ 0, the diffuse term becomes zero. A larger shininess exponent concentrates specular response.

## Algorithm / implementation trace

```text
Enable depth test, OpenGL lighting and a light source
Set ambient/diffuse/specular light terms
Set material reflection terms and shininess
Draw a smooth-shaded 3D object while varying viewpoint
```

## Source & files

| File / folder | Purpose |
|---|---|
| [`phong_illumination_lab7.py`](phong_illumination_lab7.py) | OpenGL lighting and material setup |
| [`phong_illumination_lab7.ipynb`](phong_illumination_lab7.ipynb) | Notebook version |

## How to run

From the **repository root**, install the [Python dependencies](../docs/GETTING_STARTED.md) and run:

```bash
python lab7/phong_illumination_lab7.py
```

Run one command at a time; each program opens a desktop graphics window.

## Captured outputs

<a href="phong_illumination_output_lab7.png"><img src="phong_illumination_output_lab7.png" alt="Original OpenGL illumination output" width="760"></a>

**Figure 7.1.** Original OpenGL illumination output. Select the image to open its committed original file.

**Source of these figures:** Existing lab-program output images preserved in this repository. These are genuine stored output captures, not newly executed screenshots.

## Interpretation

1. A red object receives directional shading and highlights.
2. Shininess changes the appearance of a specular region without changing mesh silhouette.
3. This lab uses OpenGL's lighting/material configuration; the CIE3 Unity shader separately computes a Phong-style fragment equation.

### Common misunderstanding

Do not equate a bright material colour with a specular highlight: diffuse and specular terms depend on different directional relationships.

## Viva questions

1. What determines diffuse intensity?
2. Why does specular appearance depend on the viewer?
3. What does a high shininess exponent mean?

For explanations, use the [graphics theory reference](../docs/GRAPHICS_THEORY.md) and refer to the actual source file rather than treating a screenshot as complete proof of correctness.

## Explore next

- [CIE3 custom Unity Phong shader](../CASE%20STUDY%20CIE3/Unity_Retail_AR_Demo/Assets/Shaders/PhongFurniture.shader)
- [Lab 08 — programmable shaders](../lab8/README.md)

[**← Lab index**](../README.md#laboratory-index) · [Manual](../docs/MANUAL.md) · [Evidence status](../docs/EVIDENCE_STATUS.md)

---

<sub>CGVR Laboratory · Munnaluri Rishikesh · RV University</sub>
