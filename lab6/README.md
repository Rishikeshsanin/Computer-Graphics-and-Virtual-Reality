[← All labs](../README.md) · [Screenshot gallery](../docs/SCREENSHOT_GALLERY.md) · [Setup](../docs/GETTING_STARTED.md)

# Lab 06 / Z-Buffer Hidden-Surface Removal

> Compare overlapping 3D primitives with depth testing disabled and enabled.

**Stack:** Python · Pygame · PyOpenGL

## Objective

Compare overlapping 3D primitives with depth testing disabled and enabled. This experiment is part of the **CS4104 Computer Graphics and Virtual Reality** lab collection.

## Concept

The experiment renders overlapping triangles in side-by-side OpenGL viewports. On one side the depth test is disabled; on the other, the Z-buffer determines visibility so the nearer surface is shown.

## Files

| Asset | Role |
|---|---|
| [`z_buffer_hidden_surface_removal_lab6.py`](./z_buffer_hidden_surface_removal_lab6.py) | Python source |
| [`z_buffer_hidden_surface_removal_lab6.ipynb`](./z_buffer_hidden_surface_removal_lab6.ipynb) | Jupyter notebook |

## Run

After installing [repository dependencies](../docs/GETTING_STARTED.md), execute from the **repository root**:

```bash
python lab6/z_buffer_hidden_surface_removal_lab6.py
```

The program opens a Pygame/OpenGL window. Close it normally or use `Esc` where supported.

## Captured outputs

**Figure 6.1 — z buffer output lab6 (original lab output)**

[![Lab 6 screenshot 1](./z_buffer_output_lab6.png)](./z_buffer_output_lab6.png)

## What to observe

- Depth buffering stores depth alongside pixels and rejects fragments behind already rendered geometry.
- The visualization demonstrates a concrete occlusion difference.

## Evidence note

Images in this page link to files already committed in the repository. A saved PNG does not by itself establish recent performance metrics or confirm that a separate Unity project compiled on another system.

---

[**Back to CGVR collection**](../README.md) · [Source provenance](../SOURCE_REPOS.md)
