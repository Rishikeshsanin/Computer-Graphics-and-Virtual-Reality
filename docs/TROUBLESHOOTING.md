[← Manual](MANUAL.md) · [Setup](GETTING_STARTED.md) · [Architecture](ARCHITECTURE.md)

# Troubleshooting & Frequently Asked Questions

Diagnose the **environment first**. Python/PyOpenGL, Unity and the browser demo are separate applications with different requirements.

## Python and OpenGL

| Symptom | Likely issue | What to try |
|---|---|---|
| `ModuleNotFoundError: pygame` or `OpenGL` | Python packages missing from active environment | Activate the virtual environment and run `python -m pip install -r requirements.txt`. |
| Window opens and exits unexpectedly | Runtime error, ESC pressed or process exited | Run from a terminal and read the traceback rather than double-clicking the script. |
| Pygame cannot create an OpenGL context | Drivers / remote desktop / unsupported GL version | Update GPU driver; run locally and check OpenGL support. Lab 8 Python requests **OpenGL 3.3 core**. |
| No visible graphics window in cloud notebook | No desktop display | Execute locally on Windows/macOS/Linux with desktop GUI and compatible graphics support. |
| Notebook has stale/missing results | Notebook saved without executed outputs | Run cells locally; saved `.ipynb` is source, not proof of a completed run. |

## Unity Editor

| Symptom | Why it happens | Recovery |
|---|---|---|
| Unity Hub says project is invalid | Selected the repository root instead of Unity project directory | Select the folder containing `Assets/`, `Packages/`, `ProjectSettings/`. |
| “No cameras rendering” before Play | CIE3 and new Lab 8/10 scenes create cameras during runtime | Open the saved scene and press **Play**. |
| Unity Package Manager cannot find `com.unity.modules.inputlegacy` | That package is not valid | Use the checked-in manifest; do not add `inputlegacy`. The old input system setting lives in Player settings. |
| Keyboard shortcuts do nothing | Game window not focused | Click in Game view before pressing keys; inspect Active Input Handling if necessary. |
| Shader renders pink | Shader failed to compile or incompatible render pipeline | Check the Console, use **Unity 6000.3.0f1** and the **Built-in Render Pipeline**; check the shader source and API. |
| UI is cropped | Game scale/aspect ratio and Editor window size | Maximize Game view (`Shift+Space`), select landscape view and fit the scale. |
| Lab 9 lacks a complete Unity Hub layout in this repo | `lab9/` is a preserved source copy | Use the original [standalone Unity repository](https://github.com/Rishikeshsanin/unity-interactive-3d-scene). |

**Do not erase or regenerate the working CIE3 scene just to fix camera framing.** First confirm you downloaded the latest source, pressed Play and opened the Game tab.

## Browser Furniture Studio

| Symptom | What to check |
|---|---|
| White/blank page when opening `index.html` | Use a local HTTP server rather than a `file://` URL. |
| Three.js import fails | Internet access / jsDelivr availability; the demo imports pinned Three.js **0.186.1**. |
| WebGL unavailable | Browser WebGL 2 support, GPU acceleration, browser privacy settings and graphics drivers. |
| Touch zoom/rotation feels unresponsive | Gesture starts over 3D canvas, not a sidebar control; try two-finger pinch for zoom. |
| Mapping value differs from **(657.5,708.0)** | Use Mapping → Reset; check logical point (0.25,−0.30) and fixed demo rectangle. |
| Website loads but furniture never appears | Open browser developer console; verify `scene.js` and Three.js load successfully. |

**Live app:** [cgvr-furniture-studio.vercel.app ↗](https://cgvr-furniture-studio.vercel.app/)

## Documentation and screenshots

**Where are the screenshots?** [Gallery](SCREENSHOT_GALLERY.md) contains original lab outputs and authentic older CIE3 Unity captures. Unity Lab 8/10, Lab 9, Lab 4 and physical-device screenshots remain listed separately as pending in the [evidence ledger](EVIDENCE_STATUS.md).

**Why are CIE3 illustrations labeled as AI?** They communicate a visual design concept. They are not captured application output and are intentionally isolated from verified evidence.

**Is the mobile website AR?** No. It is a responsive 3D/WebGL visualization. It does not access the phone camera or track the surrounding room.

**Is everything runtime tested?** No. Refer to the evidence ledger. Source presence, GitHub merge success and HTTP 200 are not substitutes for local Play-mode or hardware verification.

---

[Manual](MANUAL.md) · [Evidence](EVIDENCE_STATUS.md) · [Demonstration guide](DEMONSTRATION_GUIDE.md)
