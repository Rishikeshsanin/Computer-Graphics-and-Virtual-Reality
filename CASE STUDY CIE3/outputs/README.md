# Generated Outputs

Run:

```bash
python ../case_study_3_retail_ar.py
```

The script generates:

- `illumination_models.png` - Ambient vs diffuse vs specular lighting comparison.
- `texture_bump_mapping.png` - Flat material vs texture mapping vs texture + bump mapping.
- `viewport_mapping.png` - Logical AR window mapped to smartphone viewport coordinates.
- `viewport_example.txt` - Numerical mapping example.

Verified local run:

```text
Window = [-1,1] x [-1,1]
Viewport = x:[70,1010], y:[120,1800]
Example point (0.25, -0.3) maps to (657.5, 708.0) pixels.
```
