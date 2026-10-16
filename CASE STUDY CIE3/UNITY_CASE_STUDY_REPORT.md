# CS4104 Computer Graphics and Virtual Reality
## CIE3 - Case Study 3: Retail and Remote Commerce (Unity Implementation)

**Name:** MUNNALURI RISHIKESH  
**USN:** 1RVU23CSE291  
**Tool:** Unity 6 (6000.3.0f1), C#, ShaderLab/HLSL  
**Aim:** Illustrate AR/VR furniture-preview rendering concepts through a Unity 3D scene.

## Problem scenario

A furniture retailer wants customers to virtually place furniture in their rooms through an AR/VR application. The developer must make a red velvet chair appear naturally lit, make a leather sofa look textured without using heavy polygon geometry, and map logical interaction coordinates accurately to a phone or VR device's viewport.

## Question 1 - Illumination and Color Models

The visualizer uses a **custom Phong fragment shader** to combine three lighting terms:

**Ambient:** Approximates soft reflected light present throughout the room. Formula: `Iambient = ka * Ia`. It keeps the chair visible in areas not directly illuminated.

**Diffuse:** Depends on the dot product of unit surface normal `N` and direction to light `L`: `Idiffuse = kd * Ip * max(0, N dot L)`. It represents matte cloth or velvet responding to daylight direction.

**Specular:** Uses the view direction `V` and the reflected light direction `R`: `Ispecular = ks * Ip * max(0, R dot V)^n`. It adds view-dependent highlights. Velvet uses weaker highlights than shiny leather so it does not look like glossy plastic.

**Final equation:** `I = Ia*ka + Ip*(kd*max(N dot L,0) + ks*max(R dot V,0)^n)`.

In the Unity demo the **lighting mode** buttons isolate the contribution of each term. The **daylight** slider adjusts brightness; the **specular** slider changes sofa highlights. A real AR system would additionally use light estimates from the physical room; this scene uses a simulated directional light.

## Question 2 - Texture and Bump Mapping

A leather sofa needs visible pores, grain and minor surface irregularities. Model these with **two textures**:

1. **Albedo/diffuse texture**: two-dimensional leather color pattern sampled using `(u,v)` coordinates of the sofa mesh. The same low-polygon geometry is retained.
2. **Normal/bump map**: a texture encoding local tangent-space surface normals. For each shaded pixel, the renderer transforms this normal into world space and recalculates diffuse/specular illumination. This gives apparent micro-relief while **not increasing the number of mesh vertices or changing the silhouette**.

The Unity C# script procedurally generates a leather albedo image and a normal texture, while the HLSL shader applies them. Toggle **Texture** and **Bump** independently to inspect the result. This approach improves surface realism with significantly less geometric complexity than modeling each pore. Optimization choices include mipmaps, small shared textures, and low-poly primitive meshes.

## Question 3 - Window-to-Viewport Transformation

The Unity demo maps a logical interaction window `[-1, 1] x [-1, 1]` to a phone-like viewport in **pixel coordinates**:

- Viewport X range = `[70, 1010]`
- Viewport Y range = `[120, 1800]`

For a logical point `(xw, yw)`, map to the viewport using:

`xv = xv_min + (xw - xw_min) * (xv_max - xv_min)/(xw_max - xw_min)`

`yv = yv_min + (yw - yw_min) * (yv_max - yv_min)/(yw_max - yw_min)`

Example `(xw, yw) = (0.25, -0.30)` yields:

- `xv = 70 + (0.25 + 1) * 940 / 2 = 657.5`
- `yv = 120 + (-0.30 + 1) * 1680 / 2 = 708.0`

The Unity overlay displays these numbers and a marker inside a phone-shaped viewport rectangle. Logical X/Y sliders update the point interactively. The Inset/Fill button changes the actual Camera.rect; a second mapped marker uses Camera.pixelRect to demonstrate the same transformation on the rendered Game view. The demonstration converts bottom-left logical coordinates to pixel coordinates; the IMGUI overlay flips Y for top-left GUI drawing. This illustrates how application interaction controls can align with screen positions on different displays.

## Implementation architecture

```
Unity Scene Auto Builder (Editor)
       |
       v
Runtime Furniture Demo (C#)
  |---- Create model room and primitive furniture geometry
  |---- Generate leather color texture + normal map
  |---- Configure daylight and orbit camera
  |---- Update material shader parameters from UI controls
  |---- Convert logical window to phone viewport coordinates
       |
       v
CGVR/PhongFurniture Shader (HLSL)
  |---- Ambient + diffuse + specular
  |---- Texture (UV) + perturb normal using bump map
       |
       v
Unity Game View + phone-coordinate overlay
```

## Procedure

1. Open `Unity_Retail_AR_Demo` in Unity Hub using Unity 6000.3.0f1.
2. Open the supplied scene (editor scripts can recreate it if missing): `CIE3_Retail_Furniture_Visualizer` scene.
3. Press Play and examine the velvet chair and leather sofa.
4. Switch from Ambient Only to Diffuse to Specular to observe lighting contributions.
5. Toggle leather Texture and Bump to compare different visual details.
6. Toggle Viewport mapping and check the example converts to `(657.5, 708.0)`.
7. Drag/zoom/rotate furniture to explore the live 3D scene.
8. Run menu `CGVR CIE3 > Validate Scene and Mapping` and capture Game-view outputs.

## Screenshots to capture (from real Unity runtime)

- `[ ]` Game View with red chair and leather sofa visible
- `[ ]` Ambient-only lighting mode
- `[ ]` Ambient + diffuse + specular mode
- `[ ]` Leather texture disabled vs enabled
- `[ ]` Bump disabled vs enabled (zoom onto sofa surface)
- `[ ]` Viewport overlay showing `(657.5, 708.0)`
- `[ ]` Unity hierarchy and scene menu, if required

## Results and discussion

**Expected outcomes** (pending running the Unity project in the local editor):
- Rendering shows progressively more shape and highlights as ambient, diffuse and specular terms are enabled.
- Leather texture and normal-map toggles visibly change color/grain and shading without changing sofa mesh geometry.
- Coordinate transformation produces `(657.5, 708.0)` for the worked example.

**Validation status:** source has been statically checked. Unity Editor and runtime validation screenshots are pending, because the preparation environment does not contain the Unity Editor. These are not presented as verified experimental results.

## Conclusion

The Unity demo illustrates core techniques necessary for a retail AR/VR furniture visualizer: Phong illumination for material realism, texture and bump mapping for efficient surface detail, and window-to-viewport mapping for consistent mobile/VR interaction. It is a simulated 3D scene rather than a device-tracked AR Foundation or browser WebXR deployment.
