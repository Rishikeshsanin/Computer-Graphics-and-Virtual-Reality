<p align="center"><img src="docs/assets/cgvr-banner.svg" width="100%" alt="Computer Graphics and Virtual Reality — an academic graphics laboratory and furniture studio"></p>

<h3 align="center">Computer Graphics & Virtual Reality — a visual lab manual</h3>

<p align="center">An organized collection of <strong>10 graphics experiments</strong>, multiple Unity demonstrations, and a live 3D furniture showroom.<br>Explore the algorithms, follow the implementation, inspect genuine screenshots, and reproduce each exercise.</p>

<p align="center">
<a href="docs/MANUAL.md"><img alt="Read technical manual" src="https://img.shields.io/badge/START%20HERE-Technical%20Manual-1f6686?style=for-the-badge"></a>
<a href="https://cgvr-furniture-studio.vercel.app/"><img alt="Launch live browser showroom" src="https://img.shields.io/badge/LIVE%20WEB%20DEMO-Furniture%20Studio-11796c?style=for-the-badge"></a>
<a href="docs/SCREENSHOT_GALLERY.md"><img alt="Browse genuine screenshots" src="https://img.shields.io/badge/OPEN-Gallery-454d83?style=for-the-badge"></a>
</p>

<p align="center">
<a href="#explore-the-collection">Explore</a> ·
<a href="#featured-case-study--furniture-studio">Case study</a> ·
<a href="#all-10-laboratory-chapters">All labs</a> ·
<a href="#visual-evidence">Screenshots</a> ·
<a href="#quick-start">Quick start</a> ·
<a href="#documentation-directory">Manual contents</a>
</p>

---

## Explore the collection

| **01 · Read the manual** | **02 · Learn the concepts** | **03 · Run the projects** |
|:---|:---|:---|
| [**Technical Manual →**](docs/MANUAL.md) | [**Theory & equations →**](docs/GRAPHICS_THEORY.md) | [**Installation guide →**](docs/GETTING_STARTED.md) |
| A guided path through every lab, the case study and evidence. | Rasterization, transforms, shaders, projection and worked examples. | Python, OpenGL, Unity 6000.3.0f1 and a static browser app. |

| **04 · Understand the architecture** | **05 · See authentic results** | **06 · Present to faculty** |
|:---|:---|:---|
| [**Architecture diagrams →**](docs/ARCHITECTURE.md) | [**Illustrated screenshot gallery →**](docs/SCREENSHOT_GALLERY.md) | [**Presentation walkthrough →**](docs/DEMONSTRATION_GUIDE.md) |
| Source map for Python, shader stages, Unity and Three.js. | 12 original lab outputs and real earlier-build Unity evidence. | Controls, discussion points and a repeatable demonstration order. |

## From pixels to immersive graphics

[![CGVR learning pathway from raster algorithms through shaders to furniture studio](docs/assets/graphics-pipeline.svg)](docs/MANUAL.md)

The collection progresses from drawing individual raster pixels to transforming geometry, resolving visibility, computing lighting and building interactive 3D scenes.

## Featured case study · Furniture Studio

**Retail and Remote Commerce · CIE3 Case Study 3**

The flagship exercise combines three essential CGVR topics in an interactive furniture room:

- **Illumination:** compare ambient, diffuse and specular contributions on a red chair.
- **Materials:** apply leather colour textures and bump/normal detail to a sofa without changing geometry.
- **Viewport transformation:** convert normalized coordinates to a defined phone-pixel rectangle.

| **Unity desktop** | **Mobile & desktop browser** |
|:---:|:---:|
| [![Real Unity showroom screenshot from earlier build](CASE%20STUDY%20CIE3/outputs/unity_room_earlier_build.jpg)](CASE%20STUDY%20CIE3/outputs/unity_room_overview_earlier_build.jpg) | **[Launch the live 3D Furniture Studio ↗](https://cgvr-furniture-studio.vercel.app/)** |
| **Genuine Unity Game-view capture**, earlier build | Touch-friendly 3D showroom with camera, lighting, material and mapping controls |
| [Unity project and controls →](CASE%20STUDY%20CIE3/Unity_Retail_AR_Demo/README.md) | [Web implementation and controls →](CASE%20STUDY%20CIE3/mobile-web/README.md) |

**[Explore the complete case-study manual →](CASE%20STUDY%20CIE3/README.md)**

> The Unity capture is from an earlier working version; it does not verify every recent UI update. The browser site is a 3D graphics demonstration, **not camera-based AR** or a tracked WebXR system. [Read the evidence ledger](docs/EVIDENCE_STATUS.md).

## All 10 laboratory chapters

Every chapter has a goal, core theory, worked example, source links, exact execution instructions, actual stored screenshots where available, interpretation and viva questions.

| Chapter | Topic | Visual / source | Deep-dive |
|:---:|---|---|---|
| **[01](lab1/README.md)** | DDA vs Bresenham lines | 4 original captures | [Algorithm & screenshots →](lab1/README.md) |
| **[02](lab2/README.md)** | Midpoint circle rasterization | 1 original capture | [Eight-way symmetry →](lab2/README.md) |
| **[03](lab3/README.md)** | 2D geometric transformations | 1 translation capture | [Homogeneous matrices →](lab3/README.md) |
| **[04](lab4/README.md)** | Composite transformations | Program; capture pending | [Transform order →](lab4/README.md) |
| **[05](lab5/README.md)** | Cohen–Sutherland clipping | 1 original capture | [Outcodes →](lab5/README.md) |
| **[06](lab6/README.md)** | Z-buffer visibility | 1 original capture | [Depth testing →](lab6/README.md) |
| **[07](lab7/README.md)** | Phong lighting | 1 original capture | [Light components →](lab7/README.md) |
| **[08](lab8/README.md)** | Vertex and fragment shaders | 1 OpenGL capture + Unity source | [Shader stages →](lab8/README.md) |
| **[09](lab9/README.md)** | Interactive Unity scene | Source archive; capture pending | [Controls & scene →](lab9/README.md) |
| **[10](lab10/README.md)** | Orthographic vs perspective | 2 OpenGL captures + Unity source | [Camera projections →](lab10/README.md) |

[**Read the full chapter-by-chapter manual →**](docs/MANUAL.md)

## Visual evidence

**Original lab outputs** — images shown below are the actual committed Pygame/PyOpenGL captures, not artificial renderings.

| Line rasterization · Lab 01 | Shader pipeline · Lab 08 |
|:---:|:---:|
| [![DDA lab output](lab1/dda_output_1_lab1.png)](lab1/dda_output_1_lab1.png) | [![OpenGL RGB triangle](lab8/vertex_fragment_shaders_output_lab8.png)](lab8/vertex_fragment_shaders_output_lab8.png) |
| [DDA & Bresenham chapter](lab1/README.md) | [OpenGL & Unity shader chapter](lab8/README.md) |
| Visibility · Lab 06 | Projections · Lab 10 |
| [![Z-buffer comparison](lab6/z_buffer_output_lab6.png)](lab6/z_buffer_output_lab6.png) | [![Two projection viewport screenshots](lab10/3d_viewing_pipeline_output_1_lab10.png)](lab10/3d_viewing_pipeline_output_1_lab10.png) |
| [Depth test chapter](lab6/README.md) | [Viewing pipeline chapter](lab10/README.md) |

**[View all 12 original lab screenshots and both earlier-build Unity captures →](docs/SCREENSHOT_GALLERY.md)**  
[What is verified, missing or illustrative? →](docs/EVIDENCE_STATUS.md)

## Quick start

### Run Python/OpenGL programs

```bash
git clone https://github.com/Rishikeshsanin/Computer-Graphics-and-Virtual-Reality.git
cd Computer-Graphics-and-Virtual-Reality
python -m pip install -r requirements.txt
python lab1/dda_line_lab1.py
```

Use a local graphical desktop; OpenGL labs require appropriate GPU drivers. [Complete setup & troubleshooting →](docs/GETTING_STARTED.md)

### Open Unity demonstrations

In Unity Hub, choose **Add project from disk** and select the exact project folder containing `Assets`, `Packages`, and `ProjectSettings`. Open the saved scene and **press Play**.

| Unity example | Open |
|---|---|
| **CIE3 Furniture Studio** | [Project folder](CASE%20STUDY%20CIE3/Unity_Retail_AR_Demo/README.md) |
| **Lab 8 Shader Triangle** | [Project folder](lab8/Unity_Vertex_Fragment_Shaders/README.md) |
| **Lab 10 Two-Camera Cube** | [Project folder](lab10/Unity_3D_Viewing_Pipeline/README.md) |
| **Lab 9 Interactive Scene** | [Standalone Unity source ↗](https://github.com/Rishikeshsanin/unity-interactive-3d-scene) |

**Unity version for CIE3, 8 and 10:** `6000.3.0f1`, Built-in Render Pipeline. Lab 9's folder in this collection is a source copy.

### Use the browser companion

**[Furniture Studio — live site ↗](https://cgvr-furniture-studio.vercel.app/)**. No Unity installation, API key or database. Requires JavaScript, WebGL-capable browser and an internet connection for the Three.js library.

## Documentation directory

| Manual section | Purpose |
|---|---|
| [**Start here**](docs/MANUAL.md) | Complete guided manual and progression map |
| [**Graphics theory**](docs/GRAPHICS_THEORY.md) | Formulas, algorithms and practical interpretation |
| [**Architecture**](docs/ARCHITECTURE.md) | Source structure, diagrams and application boundaries |
| [**Screenshot gallery**](docs/SCREENSHOT_GALLERY.md) | Original captures with explanatory captions |
| [**Evidence and validation**](docs/EVIDENCE_STATUS.md) | Captured / source-only / pending / concept distinctions |
| [**Demonstration guide**](docs/DEMONSTRATION_GUIDE.md) | Faculty presentation, stable comparison procedure |
| [**Getting started**](docs/GETTING_STARTED.md) | Installation and opening every project |
| [**Troubleshooting**](docs/TROUBLESHOOTING.md) | Error recovery for Python, OpenGL, Unity and browsers |
| [**Glossary**](docs/GLOSSARY.md) | Graphics vocabulary with links to implementations |
| [**Source provenance**](SOURCE_REPOS.md) | Original standalone lab repositories |

---

<p align="center">
<strong>Developed by Munnaluri Rishikesh</strong><br>
CS4104 · Computer Graphics & Virtual Reality · RV University, Bengaluru<br>
<sub>Student laboratory collection · Reproducible source · Authentic visual evidence · Practical reference manual</sub>
</p>
