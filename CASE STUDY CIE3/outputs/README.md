# Unity CIE3 — screenshot capture checklist

[← Case-study hub](../README.md) · [Unity guide](../Unity_Retail_AR_Demo/README.md) · [Evidence status](../../docs/EVIDENCE_STATUS.md)

This folder is reserved for **genuine captures of the Unity Game view in Play mode**. Do not replace screenshots with AI-generated illustrations, Python plots, or mobile-browser output.

**Current repo state:** No CIE3 Unity PNGs are committed here. The project owner previously shared two real earlier-build screenshots in chat, but they have not been checked into this folder and do not verify the latest improvements.

## Capture settings

1. Open the project with **Unity 6000.3.0f1** and press **Play**.
2. Maximize the Game tab (**Shift + Space**) and use a readable landscape aspect ratio.
3. Keep the camera/view consistent for side-by-side mode comparisons.
4. Capture as unmodified PNG using **Win + Shift + S**, a Game-view capture, or an equivalent legitimate screen capture.
5. Save the files into this folder; then add them to the README and faculty report with honest captions.

| Filename | Demonstration | Evidence requirement |
|---|---|---|
| `unity_01_room_overview.png` | Full room, **R**, Phong mode 3 | Chair and sofa both visible |
| `unity_02_phong_ambient.png` | Press **1** | Ambient-only lighting |
| `unity_03_phong_full.png` | Press **3** | Combined ambient/diffuse/specular |
| `unity_04_sofa_texture_off.png` | Focus sofa, **T** off | Albedo detail disabled |
| `unity_05_sofa_texture_on.png` | Same angle, **T** on | Albedo detail enabled |
| `unity_06_sofa_bump_off.png` | Same angle, **B** off | Flat/smoother normals |
| `unity_07_sofa_bump_on.png` | Same angle, **B** on | Material micro-detail shading |
| `unity_08_viewport_mapping.png` | Mapping panel, Reset point | `(0.25,-0.30)→(657.5,708.0)` visible |
| `unity_09_inset_viewport.png` | Inset viewport enabled | Actual camera view rectangle changes |

Capture the full-room view plus at least the most illustrative mode comparison if time is limited. Do not claim all nine exist until they have been committed.

## How to embed a capture once it exists

```markdown
![Unity Game view — full furniture showroom, captured in Play mode](outputs/unity_01_room_overview.png)
```

The example above is **not an active image link** because the PNG has not yet been added. Do not rename the illustrations in [Previews](../Previews/README.md) as evidence.
