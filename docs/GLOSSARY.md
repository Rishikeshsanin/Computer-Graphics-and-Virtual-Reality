[← Manual](MANUAL.md) · [Theory & equations](GRAPHICS_THEORY.md)

# CGVR Glossary

| Term | Practical meaning | Where to see it |
|---|---|---|
| **Albedo** | Base surface colour before shading | [CIE3 leather maps](../CASE%20STUDY%20CIE3/README.md) |
| **Ambient light** | Base illumination independent of the particular surface/light angle | [Lab 7](../lab7/README.md) |
| **Bresenham algorithm** | Integer decision-error rasterizer for lines | [Lab 1](../lab1/README.md) |
| **Bump map** | Height/normal-based detail that alters lighting, not mesh silhouette | [CIE3 browser](../CASE%20STUDY%20CIE3/mobile-web/README.md) |
| **Clipping** | Removing geometry outside a specified viewing region | [Lab 5](../lab5/README.md) |
| **Depth buffer / Z-buffer** | Per-pixel depth comparisons for occlusion | [Lab 6](../lab6/README.md) |
| **Diffuse reflection** | Light intensity varying with the angle between normal and light | [Lab 7](../lab7/README.md) |
| **DDA** | Digital Differential Analyzer: incremental rasterization | [Lab 1](../lab1/README.md) |
| **Fragment shader** | GPU program that determines fragment output colour and related values | [Lab 8](../lab8/README.md) |
| **Homogeneous coordinates** | 2D/3D coordinates extended to enable matrix translations | [Lab 3](../lab3/README.md) |
| **Normal map** | RGB representation of surface-normal directions used in shading | [Unity shader](../CASE%20STUDY%20CIE3/Unity_Retail_AR_Demo/Assets/Shaders/PhongFurniture.shader) |
| **Orthographic projection** | Parallel projection, without distance-based foreshortening | [Lab 10](../lab10/README.md) |
| **Perspective projection** | Projection where distant objects appear smaller | [Lab 10](../lab10/README.md) |
| **Phong illumination** | Ambient + diffuse + specular reflectance model | [Lab 7](../lab7/README.md) |
| **Rasterization** | Converting geometric primitives to covered pixel samples | [Labs 1–2](../lab1/README.md) |
| **Specular highlight** | View-dependent simulated reflection of a light source | [CIE3](../CASE%20STUDY%20CIE3/README.md) |
| **Tangent space** | Local per-surface basis for interpreting normal-map directions | [Unity shader](../CASE%20STUDY%20CIE3/Unity_Retail_AR_Demo/Assets/Shaders/PhongFurniture.shader) |
| **UV coordinates** | 2D coordinates on a mesh to sample a texture | [CIE3](../CASE%20STUDY%20CIE3/README.md) |
| **Vertex shader** | GPU program mapping input vertices into clip-space positions | [Lab 8](../lab8/README.md) |
| **Viewport** | Region of the framebuffer receiving a rendered image | [Lab 10](../lab10/README.md) |
| **WebGL** | Browser graphics API to use GPU rendering | [Browser studio](../CASE%20STUDY%20CIE3/mobile-web/README.md) |
| **WebXR** | Web API family for supported immersive XR sessions | Not implemented in these demos |
| **Window-to-viewport transform** | Map logical viewing coordinates into pixel coordinates | [CIE3 mapper](../CASE%20STUDY%20CIE3/README.md) |

**Recommended reading:** Follow the [ten experiments](MANUAL.md#part-i--laboratory-programs) in sequence, then study [the integrated case study](../CASE%20STUDY%20CIE3/README.md).
