[← Manual](MANUAL.md) · [Architecture](ARCHITECTURE.md) · [All labs](../README.md#laboratory-index)

# Graphics Theory & Formula Reference

A concise companion to the runnable experiments. The descriptions below are grounded in the source programs and explain what their implementation *intends to demonstrate*. Screenshots and runtime verification are documented separately in the [evidence ledger](EVIDENCE_STATUS.md).

## 01 — DDA line generation

For endpoints `(x₁,y₁)` and `(x₂,y₂)`, compute:

```text
dx = x₂ − x₁            dy = y₂ − y₁
steps = max(|dx|, |dy|)
xIncrement = dx/steps   yIncrement = dy/steps
```

Start at the first endpoint; plot rounded coordinates and increment for `steps+1` samples. The [source](../lab1/dda_line_lab1.py) handles a zero-length line. In the reference image, adjacent raster points approximate a continuous straight line.

**Contrast:** [Bresenham](../lab1/bresenham_line_lab1.py) updates an integer error accumulator, making its per-step arithmetic different from DDA's fractional increments.

## 02 — Midpoint circle

Starting at `(x,y) = (0,r)`, take decision parameter `p = 1 − r`. At each step, decide whether the next x increment also requires reducing y. One octant generates eight symmetric points around centre `(cx,cy)`, so there is no need to compute sine and cosine for every plotted pixel. See [Lab 2](../lab2/README.md).

## 03 — Homogeneous 2D transformations

Using column-vector convention:

```text
T(tx,ty) = [1 0 tx]   R(θ) = [cosθ −sinθ 0]   S(sx,sy) = [sx 0  0]
           [0 1 ty]          [sinθ  cosθ 0]               [0 sy 0]
           [0 0  1]          [  0     0  1]               [0  0 1]
```

Transform `[x,y,1]ᵀ` by multiplying the selected 3×3 matrix. Additional reflection and shear matrices are implemented in [Lab 3](../lab3/2d_transformations_lab3.py).

## 04 — Composite transforms

The source defines `M = T(235,70) · R(35°) · S(1.25,0.85)`. With column vectors, **scaling occurs first**, then rotation, then translation. Reversing the product generally produces a different result. See [Lab 4](../lab4/README.md).

## 05 — Cohen–Sutherland clipping

Assign each segment endpoint a four-bit outcode (left/right/bottom/top) relative to the clipping rectangle:

- Both zero → trivially accept.
- Bitwise AND non-zero → trivially reject.
- Otherwise → select an outside endpoint, intersect with the corresponding rectangle boundary, recompute code, repeat.

See [Lab 5](../lab5/README.md). This is 2D clipping *before* line rasterization inside the final display.

## 06 — Z-buffer visibility

Each raster fragment has a depth value. With depth testing enabled, the depth buffer compares the fragment against the stored visible depth; a fragment farther than what has already been accepted is rejected. Lab 6 contrasts **disabled** versus **enabled** depth testing with overlapping triangles in [two OpenGL viewports](../lab6/README.md).

## 07 — Phong-style illumination

The conceptual illumination equation is:

```text
I = Ia ka + Ip [ kd max(0,N·L) + ks max(0,R·V)^n ]
        ambient       diffuse                 specular
```

- `N`: normalized surface normal.
- `L`: normalized direction to the light.
- `R`: reflected light direction.
- `V`: direction to the viewer.
- `n`: shininess exponent (concentrates the specular highlight).

[Lab 7](../lab7/README.md) configures OpenGL's lighting/material system. The [CIE3 Unity shader](../CASE%20STUDY%20CIE3/Unity_Retail_AR_Demo/Assets/Shaders/PhongFurniture.shader) instead explicitly computes the three terms in its fragment shader. These are related teaching examples, not identical renderers.

## 08 — Programmable GPU stages

```text
Geometry coordinates → Vertex shader → Clipping/rasterization
                                   → Interpolated vertex attributes
                                   → Fragment shader → Pixel colour
```

[Lab 8](../lab8/README.md) rotates a triangle in the vertex shader and outputs interpolated RGB at each fragment. Its Python version uses GLSL 330, a VAO/VBO and a uniform rotation angle; the separate Unity version illustrates the same two shader stages.

## 09 — Interactive Unity scene

The preserved Lab 9 scripts cover input polling, a CharacterController, gravity and jumping, a follow camera, collectibles, and on-screen score feedback. A scene auto-setup script can construct the environment; consult the [standalone Unity source](https://github.com/Rishikeshsanin/unity-interactive-3d-scene) for the complete setup. See [Lab 9](../lab9/README.md).

## 10 — 3D viewing pipeline

```text
Object/local → Model → World → View → Projection
             → Clip space → Normalized device coordinates → Viewport pixels
```

A **perspective** matrix creates foreshortening as distance increases. An **orthographic** projection keeps parallel lines parallel and does not shrink distant objects merely because they are farther away. Lab 10's Python OpenGL program renders the same rotating six-colour cube into two half-width viewports. The separate Unity demo uses two cameras and two `Camera.rect` regions.

## CIE3 — Texture vs bump vs viewport

**UV texture:** A 2D colour map is sampled at mesh UV coordinates and multiplied into the surface albedo.

**Normal/bump detail:** Alter the normal used in lighting (or sample a height-based bump texture). The *silhouette, mesh vertices and polygon count are unchanged*. [Unity](../CASE%20STUDY%20CIE3/Unity_Retail_AR_Demo/README.md) uses tangent-space normal mapping; the [browser](../CASE%20STUDY%20CIE3/mobile-web/README.md) uses a generated height/bump map.

**Window-to-viewport mapping:**

```text
xv = xminViewport + (xw−xminWindow) × widthViewport / widthWindow
yv = yminViewport + (yw−yminWindow) × heightViewport / heightWindow

Window: [-1,1] × [-1,1]
Viewport: x=[70,1010], y=[120,1800]
Point: (0.25,−0.30)

xv = 70 + (1.25/2)×940 = 657.5
yv = 120 + (0.70/2)×1680 = 708.0
```

**Coordinate caveat:** GUI frameworks can use different Y origins; the source code converts values appropriately for its own control panel. This worked example is the logical mapping, not the physical pixel dimensions of the user's phone.

---

[Manual](MANUAL.md) · [Each lab's code and observations](../README.md#laboratory-index) · [Genuine outputs](SCREENSHOT_GALLERY.md)
