# Runtime evidence and screenshot checklist

[← Repository](../README.md) · [Captured outputs](SCREENSHOT_GALLERY.md) · [CIE3 hub](../CASE%20STUDY%20CIE3/README.md)

This table separates **existing source screenshots** from **Play-mode/browser screenshots that still need capture**. The repository's **12 original Python/OpenGL captures** are listed in the [gallery](SCREENSHOT_GALLERY.md).

| Application / lab | Source / implementation | Verified repository screenshot? | Notes |
|---|---|---|---|
| Labs 1, 2, 3, 5, 6, 7, 8 (OpenGL), 10 (OpenGL) | Python/Pygame/PyOpenGL | **Yes** | 12 images; see gallery. |
| Lab 4 | Python/Pygame | **No** | Program is present; local screenshot not committed. |
| Lab 8 (Unity) | Unity 6000.3.0f1 | **No** | Needs the RGB triangle in Game view. |
| Lab 9 (Unity) | Unity/C# project source copy | **No** | Use standalone Unity repo and capture local running scene. |
| Lab 10 (Unity) | Unity 6000.3.0f1 | **No** | Needs side-by-side orthographic/perspective cube screenshot. |
| CIE3 (Unity) | Unity 6000.3.0f1 | **No, not committed** | Owner previously shared real screenshots of the earlier running build in ChatGPT; they do **not** verify later presentation changes. |
| CIE3 (mobile browser) | Three.js, hosted on Vercel | **No** | HTTP 200 and static assets were checked; physical mobile appearance/touch still need a screenshot. |

## Suggested authentic capture set

Capture as PNG, without rearranging or adding synthetic interface elements.

**CIE3 Unity** — [complete 9-image capture guide](../CASE%20STUDY%20CIE3/outputs/README.md). At minimum, a clear overview, ambient vs full Phong lighting, sofa texture on/off, bump on/off and viewport mapping panel.

**Lab 8 Unity** — RGB triangle at two visibly different angles, ideally with shader labels and controls visible.

**Lab 10 Unity** — the single cube simultaneously rendered in left orthographic and right perspective camera viewports; one alternative FOV comparison.

**Lab 9 Unity** — the locally running interactive scene with player, environment and score HUD.

**Mobile browser** — opening [the live website](https://cgvr-furniture-studio.vercel.app/) in a real mobile browser, capture the room overview and one expanded graphics control; do not represent an illustration or browser mockup as a device screenshot.

**Lab 4** — capture the composite matrix-transformation window.

## Screenshot quality guide

1. Prefer clear, landscape composition for desktop applications and portrait for a phone.
2. Hide irrelevant desktop windows, pop-ups, personal notifications and sensitive information.
3. Keep enough interface context to identify the experiment and its expected result.
4. Use descriptive filenames and captions that name the platform and demonstration.
5. State if an image shows an older build, generated concept art, or an unverified screen.

**No performance numbers or live camera-AR operation are implied by the existence of screenshots.**
