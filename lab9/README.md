[← All experiments](../README.md) · [Technical manual](../docs/MANUAL.md) · [Theory](../docs/GRAPHICS_THEORY.md) · [Screenshots](../docs/SCREENSHOT_GALLERY.md)

# LAB 09 · Interactive 3D Scene with Unity

> Connect movement, physics, camera and a game HUD

**Stack:** Unity / C# · **Course:** CS4104 Computer Graphics & Virtual Reality

## On this page

[Objective](#objective) · [Core concept](#core-concept) · [Worked example](#worked-example) · [How to run](#how-to-run) · [Captured outputs](#captured-outputs) · [Interpretation](#interpretation) · [Viva questions](#viva-questions)

## Objective

A scene becomes interactive when user controls update a player, the camera follows it, collectible objects register contact, and feedback is displayed on a HUD.

**Learning outcome:** Explain the method, locate its implementation in the supplied source, run the demonstration in the appropriate environment, and describe the observed output accurately.

## Core concept

The retained **PlayerController_lab9.cs** reads WASD/arrow keys, uses **Space** to jump, applies gravity, and uses **R** to reset the player. Other scripts manage camera following, rotating objects and collectibles.

![CGVR learning progression: where this lab fits](../docs/assets/graphics-pipeline.svg)

## Worked example

A typical play sequence is: enter scene → move with WASD → jump over an obstacle with Space → collect an item → observe score change. This describes the script architecture, not a captured tested session.

## Source & files

| File / folder | Purpose |
|---|---|
| [Retained Unity source files](unity_interactive_scene_lab9/Assets/Scripts/) | C# gameplay logic |
| [Original standalone Unity project ↗](https://github.com/Rishikeshsanin/unity-interactive-3d-scene) | Complete project source and intended Unity entry point |

## How to run

Open the [original standalone Unity project](https://github.com/Rishikeshsanin/unity-interactive-3d-scene) via Unity Hub. This consolidated folder contains retained C# source files, not a guaranteed complete Unity project.

## Captured outputs

**Capture pending:** This lab has source code but no verified screenshot committed to the repository. Do not use an AI-generated substitute.

**Evidence status:** Runtime capture is pending; the diagram above is a conceptual learning-path illustration, not a screenshot.

## Interpretation

1. The consolidated lab9 folder retains C# sources, not a complete Unity Hub project layout.
2. The original standalone Unity repository is the intended entry point.
3. There is no committed authentic Lab 9 screenshot in this repository.

### Common misunderstanding

Do not select the consolidated `lab9/unity_interactive_scene_lab9` copy in Unity Hub as though it were guaranteed to be a complete project. Use the linked standalone Unity repository instead.

## Viva questions

1. Why is CharacterController used for player movement?
2. How is jump velocity affected by gravity?
3. How can the UI reflect events triggered by scene objects?

For explanations, use the [graphics theory reference](../docs/GRAPHICS_THEORY.md) and refer to the actual source file rather than treating a screenshot as complete proof of correctness.

## Explore next

- [Original Lab 9 Unity repository](https://github.com/Rishikeshsanin/unity-interactive-3d-scene)
- [CIE3 interactive furniture project](../CASE%20STUDY%20CIE3/README.md)

[**← Lab index**](../README.md#laboratory-index) · [Manual](../docs/MANUAL.md) · [Evidence status](../docs/EVIDENCE_STATUS.md)

---

<sub>CGVR Laboratory · Munnaluri Rishikesh · RV University</sub>
