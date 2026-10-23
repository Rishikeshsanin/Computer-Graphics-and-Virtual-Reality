# Getting started

[← Repository](../README.md) · [Screenshot gallery](SCREENSHOT_GALLERY.md)

## Requirements

- **Python:** a locally installed Python 3 interpreter.
- **Packages:** install from [requirements.txt](../requirements.txt).
- **OpenGL labs:** a compatible graphics driver and an environment that can open a Pygame window.
- **Unity projects:** **Unity Editor 6000.3.0f1** using the Built-in Render Pipeline.
- **Mobile/browser CIE3:** a modern browser with WebGL support, JavaScript and internet access to load the pinned Three.js dependency.

## Python labs

```bash
git clone https://github.com/Rishikeshsanin/Computer-Graphics-and-Virtual-Reality.git
cd Computer-Graphics-and-Virtual-Reality
python -m venv .venv

# Windows PowerShell
.venv\Scripts\Activate.ps1

python -m pip install -r requirements.txt
python lab1/dda_line_lab1.py
python lab2/midpoint_circle_lab2.py
python lab3/2d_transformations_lab3.py
python lab4/composite_transformations_lab4.py
python lab5/cohen_sutherland_line_clipping_lab5.py
python lab6/z_buffer_hidden_surface_removal_lab6.py
python lab7/phong_illumination_lab7.py
python lab8/vertex_fragment_shaders_lab8.py
python lab10/3d_viewing_pipeline_lab10.py
```

**Run each command separately.** The examples open graphical windows, and many exit using `Esc` or the window close button. A `.ipynb` is also supplied for each of the Python lab programs.

### Troubleshooting

| Problem | Check |
|---|---|
| `ModuleNotFoundError` | Activate the environment and reinstall `requirements.txt`. |
| No graphical display | Run locally in a desktop environment, not a headless notebook terminal. |
| Failed to create OpenGL context | Update GPU drivers; use a system that supports the requested OpenGL version. |
| Cannot find the project in Unity Hub | Select the **inner** project folder containing `Assets/`, `Packages/`, and `ProjectSettings/`. |
| Unity shows “No cameras rendering” before Play | Expected for the runtime-generated CIE3, Lab 8 and Lab 10 demonstrations. Press **Play**. |
| Unity package error | Check `Packages/manifest.json`; do not add the nonexistent `com.unity.modules.inputlegacy` package. |
| Browser page is blank after opening `index.html` directly | Serve with HTTP; do not use `file://` for the module-based app. |

## Unity lab directories

- [CIE3 Furniture Studio](../CASE%20STUDY%20CIE3/Unity_Retail_AR_Demo/README.md)
- [Lab 8 Vertex + Fragment Shaders](../lab8/Unity_Vertex_Fragment_Shaders/README.md)
- [Lab 10 Viewing Pipeline](../lab10/Unity_3D_Viewing_Pipeline/README.md)
- [Lab 9 standalone Unity project](https://github.com/Rishikeshsanin/unity-interactive-3d-scene) (source copy under `lab9/`)

## Browser Furniture Studio

**[Open the hosted version ↗](https://cgvr-furniture-studio.vercel.app/)**

To run locally:

```bash
python -m http.server 8000 --directory "CASE STUDY CIE3/mobile-web"
```

Open `http://localhost:8000/`. The browser demo is **3D, not camera-based AR**.

## Evidence and reports

Each lab's README points to its actual screenshots, when present. See [evidence status](EVIDENCE_STATUS.md) before claiming a Unity or browser run was visually verified. The official written CIE3 faculty report is managed separately from these runnable source examples.
