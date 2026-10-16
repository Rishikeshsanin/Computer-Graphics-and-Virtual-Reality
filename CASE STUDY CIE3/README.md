# CASE STUDY CIE3 - Retail and Remote Commerce

**Course:** CS4104 Computer Graphics & Virtual Reality  
**Student:** Munnaluri Rishikesh  
**USN:** 1RVU23CSE291

## Unity demo — open this for the live presentation

The supplied unfinished Unity draft has been continued in **[Unity_Retail_AR_Demo](Unity_Retail_AR_Demo/README.md)** using **Unity 6000.3.0f1**.

In Unity Hub, add `CASE STUDY CIE3/Unity_Retail_AR_Demo`, open it, choose **CGVR CIE3 → Open Furniture Visualizer**, and press **Play**. The saved scene generates a furnished room with an interactive Phong shader, independently controlled texture/bump mapping, and window-to-viewport sliders plus a real camera viewport toggle.

**Faculty demo:** `1/2/3` for lighting; select sofa and **F**, then `T/B` for texture/bump; `V` for mapping, **Reset point** for `(657.5, 708.0)`, then **Inset viewport**. Drag to orbit, scroll to zoom, `R` to return to the room.

**Unity runtime verification and real screenshots remain pending on your machine:** Unity is not installed in the preparation environment. No screenshots were fabricated. The Python verification below applies only to the earlier Python submission, not Unity.

## Generated visual previews

These **AI-generated illustrations are not Unity screenshots or runtime evidence**. They illustrate the room and leather-material concept; geometry, lighting and detail may differ from the actual project. Real Play-mode captures remain pending.

![AI-generated room illustration; not a Unity screenshot](Previews/generated-room-preview.png)

![AI-generated sofa material illustration; not a Unity screenshot](Previews/generated-material-preview.png)

## Existing Python case-study materials

## Selected Case Study

**Case Study 3: Retail and Remote Commerce** - WebXR furniture visualization for AR/VR.

This folder contains the complete CIE3 case-study submission and runnable demonstrations for the three concepts asked in the assignment:

1. **Illumination & Color Models** - ambient, diffuse and specular reflection using a simplified Phong model.
2. **Texture & Bump Mapping** - leather surface detail without increasing polygon count.
3. **Window-to-Viewport Transformation** - mapping logical AR interaction coordinates to smartphone/VR display coordinates.

## Files

```text
CASE STUDY CIE3/
├── README.md
├── CASE_STUDY_REPORT.md
├── case_study_3_retail_ar.py
├── case_study_3_retail_ar.ipynb
├── requirements_case_study.txt
└── outputs/
    └── README.md
```

The Python program generates these verified outputs when run:

- `outputs/illumination_models.png`
- `outputs/texture_bump_mapping.png`
- `outputs/viewport_mapping.png`
- `outputs/viewport_example.txt`

## Run

```bash
pip install -r requirements_case_study.txt
python case_study_3_retail_ar.py
```

You can also open `case_study_3_retail_ar.ipynb` in Jupyter Notebook or VS Code.

## Key Formulas

### Phong illumination

```text
I = Ia*ka + Ip[kd*max(N.L,0) + ks*max(R.V,0)^n]
```

### Window-to-viewport transformation

```text
xv = xv_min + (xw - xw_min)(xv_max - xv_min)/(xw_max - xw_min)
yv = yv_min + (yw - yw_min)(yv_max - yv_min)/(yw_max - yw_min)
```

## Verification

- Python script executed successfully.
- Jupyter notebook executed successfully with no error cells before the clean GitHub copy was saved.
- Three output figures were generated successfully.
- Numerical viewport example: `(0.25, -0.30) -> (657.5, 708.0)` pixels.

## Conclusion

The implementation demonstrates how core CG concepts can be combined in a practical WebXR furniture-preview application while balancing visual realism and real-time performance.
