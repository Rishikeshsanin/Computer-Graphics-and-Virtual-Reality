[← All labs](../README.md) · [Screenshot gallery](../docs/SCREENSHOT_GALLERY.md) · [Setup](../docs/GETTING_STARTED.md)

# Lab 10 / 3D Viewing Pipeline

> Contrast orthographic and perspective projection in two viewports.

**Stack:** Python · Pygame · PyOpenGL · Unity / C#

## Objective

Contrast orthographic and perspective projection in two viewports. This experiment is part of the **CS4104 Computer Graphics and Virtual Reality** lab collection.

## Concept

A rotating six-colour cube is shown using two projection styles. The Unity version uses two cameras whose `Camera.rect` values divide the screen into left and right halves; it also exposes projection controls.

## Files

| Asset | Role |
|---|---|
| [`3d_viewing_pipeline_lab10.py`](./3d_viewing_pipeline_lab10.py) | Python source |
| [`3d_viewing_pipeline_lab10.ipynb`](./3d_viewing_pipeline_lab10.ipynb) | Jupyter notebook |
| [**Unity 6 project**](./Unity_3D_Viewing_Pipeline/README.md) | Saved Unity scene and dual-camera projection demo |

## Run

After installing [repository dependencies](../docs/GETTING_STARTED.md), execute from the **repository root**:

```bash
python lab10/3d_viewing_pipeline_lab10.py
```

The program opens a Pygame/OpenGL window. Close it normally or use `Esc` where supported.

### Unity alternative

[Open the dedicated Unity 6000.3.0f1 project guide →](./Unity_3D_Viewing_Pipeline/README.md). Add that folder through Unity Hub, open its saved scene and press **Play**. The existing screenshot below documents **OpenGL**, not the Unity version.

## Captured outputs

**Figure 10.1 — 3d viewing pipeline output 1 lab10 (original OpenGL output)**

[![Lab 10 screenshot 1](./3d_viewing_pipeline_output_1_lab10.png)](./3d_viewing_pipeline_output_1_lab10.png)

**Figure 10.2 — 3d viewing pipeline output 2 lab10 (original OpenGL output)**

[![Lab 10 screenshot 2](./3d_viewing_pipeline_output_2_lab10.png)](./3d_viewing_pipeline_output_2_lab10.png)

## What to observe

- Both committed screenshots originate from the Python/OpenGL implementation.
- Unity project source is present, but Unity runtime evidence has not yet been committed.

## Evidence note

Images in this page link to files already committed in the repository. A saved PNG does not by itself establish recent performance metrics or confirm that a separate Unity project compiled on another system.

---

[**Back to CGVR collection**](../README.md) · [Source provenance](../SOURCE_REPOS.md)
