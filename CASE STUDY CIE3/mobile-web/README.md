# Mobile Browser Furniture Studio — CGVR CIE3

An optional, responsive **web-browser companion** to the existing Unity 6000.3.0f1 desktop application. It implements the same three educational graphics demonstrations without modifying or replacing the Unity source or faculty report.

## Run / deploy

This is a static website. Deploy this folder directly on **Vercel** (Framework: Other, Root Directory: `CASE STUDY CIE3/mobile-web`) or serve it with any HTTP static server:

```bash
python -m http.server 8000 --directory "CASE STUDY CIE3/mobile-web"
```

Open `http://localhost:8000` on desktop. For phone access, use a public HTTPS deployment or a reachable local-network server. **Do not open index.html as a `file://` URL**: browser ES modules may fail. Requires network access to the pinned **Three.js 0.186.1** package on jsDelivr, a modern WebGL 2 capable browser and JavaScript enabled. No accounts or environment variables.

## Features

- **Mobile-friendly showroom:** procedural red velvet chair, brown leather sofa, room, plinths, window, plant, light and shadows.
- **Touch interaction:** drag to orbit, two-finger pinch to zoom; desktop drag/scroll and accessible zoom/reset buttons. Room/Chair/Sofa focus.
- **Phong lighting:** ambient-only, ambient+diffuse, ambient+diffuse+specular modes, daylight and specular intensity sliders. Uses Three.js MeshPhongMaterial and lighting.
- **Material mapping:** procedural 256×256 colour texture and height-based bump map; independently switch each effect without changing mesh geometry.
- **Window → viewport:** map logical `[-1,1]` coordinates onto example phone pixels x=70..1010, y=120..1800. Default `(0.25,-0.30)` gives `(657.5,708.0)`. Optional renderer viewport inset demonstrates a real viewport rectangle.
- **No camera access:** this is **not device-tracked AR**, does not use WebXR or place furniture into a live phone camera.

## Validation status

Static syntax/structure checks are provided during the repository integration. Browser visual verification on real iOS/Android hardware remains to be performed; do not report it as done without testing.

## Source relationship

- `../Unity_Retail_AR_Demo` — original Unity application, unchanged.
- `../UNITY_CASE_STUDY_REPORT.md` — written faculty case-study report, unchanged.
- `mobile-web/` — separate browser demonstration.

The original CIE3 case-study submission does not require the mobile companion; this is an optional enhancement.
