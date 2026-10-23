[← Home](../README.md) · [Technical manual](MANUAL.md) · [Evidence ledger](EVIDENCE_STATUS.md)

# Illustrated Results Gallery

The purpose of this gallery is to show **what each real experiment actually produced**, with accurate captions and links back to source. Images in this section are not conceptual mockups.

**Collection:** **12** stored Python/Pygame/PyOpenGL captures + **2** genuine Unity earlier-build views (with thumbnail and full-context versions).

## Rasterization · Labs 01–02

| DDA output · first view | DDA output · second view |
|:---:|:---:|
| [![First DDA line rasterization screenshot](../lab1/dda_output_1_lab1.png)](../lab1/dda_output_1_lab1.png) | [![Second DDA line rasterization screenshot](../lab1/dda_output_2_lab1.png)](../lab1/dda_output_2_lab1.png) |
| Sample line pixels from the fractional-increment DDA method | Alternate DDA capture |
| Bresenham · first view | Bresenham · second view |
| [![First Bresenham screenshot](../lab1/bresenham_output_1_lab1.png)](../lab1/bresenham_output_1_lab1.png) | [![Second Bresenham screenshot](../lab1/bresenham_output_2_lab1.png)](../lab1/bresenham_output_2_lab1.png) |
| Integer-error line rasterization | Alternate raster output |

**Midpoint circle · Lab 02**

[![Midpoint circle captured output](../lab2/midpoint_circle_output_lab2.png)](../lab2/midpoint_circle_output_lab2.png)

The circle uses **eight-way symmetry**; the full outline is formed from octant decisions. [Learn the algorithm →](../lab2/README.md)

## Transformations & clipping · Labs 03–05

| Transformation · Lab 03 | Clipping · Lab 05 |
|:---:|:---:|
| [![Translation screenshot](../lab3/2d_translation_output_lab3.png)](../lab3/2d_translation_output_lab3.png) | [![Line clipping screenshot](../lab5/cohen_sutherland_output_lab5.png)](../lab5/cohen_sutherland_output_lab5.png) |
| Original translation result using homogeneous matrices; **not** every transformation mode | Cohen–Sutherland window clipping, rendered in OpenGL |

**Lab 04:** Source for composite transformations exists, but **no genuine output screenshot** is in the repo yet. [See source/experiment guide →](../lab4/README.md)

## Rendering & shading · Labs 06–08

| Z-buffer · Lab 06 | Phong lighting · Lab 07 |
|:---:|:---:|
| [![Depth buffer comparison](../lab6/z_buffer_output_lab6.png)](../lab6/z_buffer_output_lab6.png) | [![Phong model result](../lab7/phong_illumination_output_lab7.png)](../lab7/phong_illumination_output_lab7.png) |
| Visibility with different depth-testing modes | Ambient, diffuse and specular material response in OpenGL |

**Vertex / fragment shaders · Lab 08**

[![Original OpenGL RGB shader result](../lab8/vertex_fragment_shaders_output_lab8.png)](../lab8/vertex_fragment_shaders_output_lab8.png)

The RGB triangle shows interpolated fragment colours after vertex processing. This is the **original Python/OpenGL screenshot**. The new Unity shader port has a separate [project guide](../lab8/Unity_Vertex_Fragment_Shaders/README.md) and requires a separate authentic Unity capture.

## Viewing pipeline · Lab 10

| Original OpenGL view · image 1 | Original OpenGL view · image 2 |
|:---:|:---:|
| [![Viewing pipeline image 1](../lab10/3d_viewing_pipeline_output_1_lab10.png)](../lab10/3d_viewing_pipeline_output_1_lab10.png) | [![Viewing pipeline image 2](../lab10/3d_viewing_pipeline_output_2_lab10.png)](../lab10/3d_viewing_pipeline_output_2_lab10.png) |
| Orthographic/perspective viewport comparison | Second capture of the same GL demonstration |

These represent **PyOpenGL**, not the dedicated Unity Lab 10 project. [Study the two-camera Unity source →](../lab10/Unity_3D_Viewing_Pipeline/README.md)

## CIE3 Unity · earlier-build genuine evidence

These captures were taken from the actual project owner's Unity Play-mode session on **18 October 2026**. The images are evidence that **the earlier build displayed the furniture and scene**. They do **not** establish that subsequent camera/presentation controls were runtime-tested.

| Full room | Closer furniture view |
|:---:|:---:|
| [![Earlier Unity room overview](../CASE%20STUDY%20CIE3/outputs/unity_room_earlier_build.jpg)](../CASE%20STUDY%20CIE3/outputs/unity_room_overview_earlier_build.jpg) | [![Earlier Unity close view](../CASE%20STUDY%20CIE3/outputs/unity_closeup_earlier_build.jpg)](../CASE%20STUDY%20CIE3/outputs/unity_furniture_closeup_earlier_build.jpg) |
| [Open full Unity Editor screenshot](../CASE%20STUDY%20CIE3/outputs/unity_room_overview_earlier_build.jpg) | [Open full Unity Editor screenshot](../CASE%20STUDY%20CIE3/outputs/unity_furniture_closeup_earlier_build.jpg) |

[**Read the CIE3 case study, lighting/material/viewport explanation →**](../CASE%20STUDY%20CIE3/README.md)

## Pending screenshots and concepts

The repository still needs authenticated runtime captures for Lab 04, Lab 09, **Unity** Lab 08 and Lab 10, updated CIE3 lighting/material comparisons, and the physical mobile browser.

A [Chromium screenshot workflow](../.github/workflows/cgvr-showroom-screenshots.yml) exists for the browser app. Its source does **not** count as proof of successful execution; generated images should be linked only when they actually appear in the repository. Emulated-mobile screenshots, if generated, should never be claimed as physical-phone evidence.

Two [CIE3 concept images](../CASE%20STUDY%20CIE3/Previews/README.md) were AI-generated to illustrate a design direction. **They are not Unity or web output** and are not mixed into this evidence gallery.

[Evidence ledger →](EVIDENCE_STATUS.md) · [Capture instructions →](../CASE%20STUDY%20CIE3/outputs/README.md)

---

[↑ Gallery top](#illustrated-results-gallery) · [Manual](MANUAL.md) · [Home](../README.md)
