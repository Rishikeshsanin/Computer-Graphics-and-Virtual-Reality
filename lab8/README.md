[← All labs](../README.md) · [Screenshot gallery](../docs/SCREENSHOT_GALLERY.md) · [Setup](../docs/GETTING_STARTED.md)

# Lab 08 / Vertex and Fragment Shaders

> A GPU-rotated RGB triangle, now implemented in OpenGL and Unity.

**Stack:** Python · Pygame · OpenGL / GLSL · Unity / C#

## Objective

A GPU-rotated RGB triangle, now implemented in OpenGL and Unity. This experiment is part of the **CS4104 Computer Graphics and Virtual Reality** lab collection.

## Concept

The vertex shader rotates vertex positions using a uniform angle, and the fragment shader emits interpolated per-vertex RGB values. The new Unity project uses a custom shader with the same educational stages.

## Files

| Asset | Role |
|---|---|
| [`vertex_fragment_shaders_lab8.py`](./vertex_fragment_shaders_lab8.py) | Python source |
| [`vertex_fragment_shaders_lab8.ipynb`](./vertex_fragment_shaders_lab8.ipynb) | Jupyter notebook |
| [**Unity 6 project**](./Unity_Vertex_Fragment_Shaders/README.md) | Saved Unity scene, custom RGB shader and controls |

## Run

After installing [repository dependencies](../docs/GETTING_STARTED.md), execute from the **repository root**:

```bash
python lab8/vertex_fragment_shaders_lab8.py
```

The program opens a Pygame/OpenGL window. Close it normally or use `Esc` where supported.

### Unity alternative

[Open the dedicated Unity 6000.3.0f1 project guide →](./Unity_Vertex_Fragment_Shaders/README.md). Add that folder through Unity Hub, open its saved scene and press **Play**. The existing screenshot below documents **OpenGL**, not the Unity version.

## Captured outputs

**Figure 8.1 — vertex fragment shaders output lab8 (original OpenGL output)**

[![Lab 8 screenshot 1](./vertex_fragment_shaders_output_lab8.png)](./vertex_fragment_shaders_output_lab8.png)

## What to observe

- OpenGL screenshot is already committed.
- Unity's shader-driven triangle has source and a saved scene, but its runtime screenshot must be captured in Unity.

## Evidence note

Images in this page link to files already committed in the repository. A saved PNG does not by itself establish recent performance metrics or confirm that a separate Unity project compiled on another system.

---

[**Back to CGVR collection**](../README.md) · [Source provenance](../SOURCE_REPOS.md)
