[← Manual](MANUAL.md) · [Live studio ↗](https://cgvr-furniture-studio.vercel.app/) · [Evidence](EVIDENCE_STATUS.md)

# Faculty Demonstration & Presentation Guide

Use this as a **repeatable live walkthrough**. It focuses on what the program shows, what each operation proves, and what it does *not* prove.

## Suggested 4-minute CIE3 demo

| Time | Action | What to explain |
|---|---|---|
| **0:00–0:30** | Open the Unity furniture room or browser showroom, return to room focus | “This is a low-poly retail furniture visualization scene: red chair, leather sofa, and adjustable camera.” |
| **0:30–1:15** | Unity keys `1 → 2 → 3` (or browser Lighting panel) | Ambient is base illumination; diffuse depends on normal/light angle; specular depends on view/light relation. |
| **1:15–2:00** | Select sofa, focus with `F`; toggle `T` while keeping the camera stable | UV-mapped leather colour changes without increasing geometry. |
| **2:00–2:40** | Toggle `B`, orbit slightly for highlight comparison | Microdetail changes shading normals; it does not add new vertices. |
| **2:40–3:30** | Open viewport mapping (`V` in Unity, Mapping tab in browser), reset logical point | Input `(0.25,−0.30)` maps to **`(657.5,708.0)`** in the illustrative phone rectangle. |
| **3:30–4:00** | Return to full-room view, summarize limits | The assignment demonstrates graphics foundations, not tracked camera-based AR. |

**Controls differ across platforms.** Unity uses letter shortcuts; the browser provides touch-accessible panels and buttons. Follow the [Unity-specific guide](../CASE%20STUDY%20CIE3/Unity_Retail_AR_Demo/README.md) or [browser guide](../CASE%20STUDY%20CIE3/mobile-web/README.md) for actual controls.

## Evidence sequence: capture pairs, not random images

| Comparison | Hold constant | Change only |
|---|---|---|
| Ambient vs full Phong | Camera, furniture selection, viewport | Lighting mode |
| Albedo OFF vs ON | Camera distance/angle and bump state | Texture switch |
| Bump OFF vs ON | Camera and lighting mode | Bump switch |
| Orthographic vs perspective (Lab 10) | Cube, geometry and viewpoint | Projection matrix |
| Viewport mapping | Source window + phone pixel rectangle | Logical input position |

The [CIE3 nine-image guide](../CASE%20STUDY%20CIE3/outputs/README.md) lists exact suggested filenames. An AI concept poster is not suitable evidence of application behaviour.

## Short lab-by-lab explanation

| Lab | What to say in one sentence |
|---|---|
| 1 | “DDA interpolates positions using fractional increments; Bresenham uses an error term.” |
| 2 | “The midpoint circle method uses eight-way symmetry to reduce calculations.” |
| 3 | “Homogeneous 3×3 matrices implement standard 2D transformations.” |
| 4 | “Composing matrices lets us apply scale, rotation and translation in one operation; order matters.” |
| 5 | “Outcodes quickly reject or accept segments against a clipping region.” |
| 6 | “The depth buffer ensures closer fragments occlude farther ones.” |
| 7 | “Phong components approximate ambient, diffuse and view-dependent reflections.” |
| 8 | “The vertex stage positions geometry and the fragment stage colours its pixels.” |
| 9 | “Player input and scene logic connect camera, physics and runtime interaction.” |
| 10 | “Orthographic and perspective projections use different matrices for the same 3D cube.” |

## Before you present

- Open each project in the expected environment and verify its console is free of errors.
- Use a landscape Game view with readable controls, especially for Unity.
- Keep a printed or local copy of the [formula sheet](GRAPHICS_THEORY.md).
- If asked about phone support, demonstrate the **browser companion**, not a simulated Unity phone viewport.
- If asked about camera AR, state clearly that the prototype does **not** perform plane detection or physical furniture placement.

## Submission checklist

See the [evidence ledger](EVIDENCE_STATUS.md) for current capture status and the [case-study report](../CASE%20STUDY%20CIE3/UNITY_CASE_STUDY_REPORT.md) for the written technical explanation. A successful live presentation and committed evidence are separate milestones.
