using System;
using UnityEngine;

/// <summary>
/// CS4104 / CIE3 - Case Study 3, Retail and Remote Commerce.
/// Generates a model room, a velvet chair, a leather sofa, and a live visualization
/// of Phong lighting, texture/normal mapping, and window-to-viewport conversion.
/// Built-in Render Pipeline; no external assets or packages required.
/// This is a 3D showroom / AR preparation demo, NOT a live phone camera AR app.
/// </summary>
public sealed class RetailARCaseStudyDemo : MonoBehaviour
{
    [SerializeField] public Shader furnitureShader;
    private Camera sceneCamera;
    private Camera backgroundCamera;
    private Vector3 cameraTarget = new Vector3(0f, 1.25f, 0f);
    private Vector2 logicalPoint = new Vector2(.25f, -.30f);
    private int viewportMode;
    private float GuiScale => Mathf.Min(Screen.width / 1280f, Screen.height / 720f);
    private float GuiWidth => Screen.width / Mathf.Max(.1f, GuiScale);
    private float GuiHeight => Screen.height / Mathf.Max(.1f, GuiScale);
    private Rect ControlsRect => new Rect(12, 12, 348, 546);
    private Rect MappingRect => new Rect(GuiWidth - 284, 12, 270, 468);
    private Rect FooterRect => new Rect(12, GuiHeight - 45, GuiWidth - 24, 36);
    private Light sun;
    private Transform chairRoot;
    private Transform sofaRoot;
    private Material chairMaterial;
    private Material sofaMaterial;
    private bool showTexture = true;
    private bool showBump = true;
    private int lightingMode = 2;
    private int selectedFurniture = 0;
    private float orbitYaw = 0f;
    private float orbitPitch = 19f;
    private float orbitDistance = 10.6f;
    private float roomBrightness = 1f;
    private float specularStrength = 0.20f;
    private bool showViewport = true;
    private bool isDragging;
    private Vector2 previousMouse;
    private GUIStyle headingStyle;
    private GUIStyle labelStyle;
    private Texture2D leatherAlbedo;
    private Texture2D leatherNormals;
    private Material interiorMaterial;

    private const float LogicalX = 0.25f;
    private const float LogicalY = -0.30f;
    private readonly Rect phoneViewportPixels = new Rect(70, 120, 940, 1680);

    public static Vector2 WindowToViewport(Vector2 point, Rect logicalWindow, Rect viewport)
    {
        if (logicalWindow.width <= 0f || logicalWindow.height <= 0f)
            throw new ArgumentException("Logical window must have positive width and height.");
        return new Vector2(
            viewport.xMin + (point.x - logicalWindow.xMin) * viewport.width / logicalWindow.width,
            viewport.yMin + (point.y - logicalWindow.yMin) * viewport.height / logicalWindow.height);
    }

    private void Start()
    {
        BuildMaterials();
        BuildRoom();
        BuildFurniture();
        BuildLightingAndCamera();
        ApplyGraphicsSettings();
    }

    private void BuildMaterials()
    {
        Shader phong = furnitureShader != null ? furnitureShader : Shader.Find("CGVR/PhongFurniture");
        if (phong == null)
        {
            Debug.LogError("Missing shader: Assets/Shaders/PhongFurniture.shader. Use the built-in render pipeline.");
            phong = Shader.Find("Standard");
        }
        if (phong == null) phong = Shader.Find("Diffuse");

        chairMaterial = new Material(phong) { name = "Red Velvet - Phong" };
        chairMaterial.SetColor("_Color", new Color(0.73f, 0.075f, 0.09f));
        chairMaterial.SetFloat("_AmbientStrength", 0.28f);
        chairMaterial.SetFloat("_DiffuseStrength", 1f);
        chairMaterial.SetFloat("_SpecularStrength", 0.14f);
        chairMaterial.SetFloat("_Shininess", 24f);

        sofaMaterial = new Material(phong) { name = "Brown Leather - Texture & Bump" };
        sofaMaterial.SetColor("_Color", new Color(0.86f, 0.72f, 0.62f));
        sofaMaterial.SetFloat("_AmbientStrength", 0.28f);
        sofaMaterial.SetFloat("_DiffuseStrength", 1f);
        sofaMaterial.SetFloat("_SpecularStrength", 0.30f);
        sofaMaterial.SetFloat("_Shininess", 46f);
        sofaMaterial.SetFloat("_BumpStrength", 1.2f);

        BuildLeatherTextures();
        sofaMaterial.SetTexture("_MainTex", leatherAlbedo);
        sofaMaterial.SetTexture("_BumpMap", leatherNormals);
        interiorMaterial = MakeStandard(new Color(0.82f, 0.79f, 0.72f));
    }

    private static Material MakeStandard(Color color)
    {
        Shader shader = Shader.Find("Standard");
        if (shader == null) shader = Shader.Find("Diffuse");
        return new Material(shader) { color = color };
    }

    // Deterministic procedural texture; a single rectangle mesh still gets detailed leather pores.
    private void BuildLeatherTextures()
    {
        const int size = 128;
        leatherAlbedo = new Texture2D(size, size, TextureFormat.RGBA32, true, false);
        leatherAlbedo.name = "Procedural Leather Albedo";
        leatherNormals = new Texture2D(size, size, TextureFormat.RGBA32, true, true);
        leatherNormals.name = "Procedural Leather Normal Map";
        float[,] height = new float[size, size];
        System.Random rng = new System.Random(4104);
        for (int y = 0; y < size; ++y)
        for (int x = 0; x < size; ++x)
        {
            float wx = (float)x / size;
            float wy = (float)y / size;
            height[x, y] = 0.50f + 0.14f * Mathf.Sin(wx * 87f + Mathf.Sin(wy * 35f)) * Mathf.Cos(wy * 91f)
                         + 0.06f * ((float)rng.NextDouble() - 0.5f);
            float c = Mathf.Clamp01(0.69f + (height[x, y] - 0.5f) * 0.23f);
            leatherAlbedo.SetPixel(x, y, new Color(c, c * 0.87f, c * 0.72f, 1f));
        }
        for (int y = 0; y < size; ++y)
        for (int x = 0; x < size; ++x)
        {
            float dx = (height[(x + 1) % size, y] - height[(x + size - 1) % size, y]);
            float dy = (height[x, (y + 1) % size] - height[x, (y + size - 1) % size]);
            Vector3 n = new Vector3(-dx * 4f, -dy * 4f, 1f).normalized;
            // Uncompressed, linear RGB tangent-space normals; decoded explicitly in our shader.
            leatherNormals.SetPixel(x, y, new Color(n.x * 0.5f + 0.5f, n.y * 0.5f + 0.5f,
                                                     n.z * 0.5f + 0.5f, 1f));
        }
        leatherAlbedo.wrapMode = TextureWrapMode.Repeat;
        leatherNormals.wrapMode = TextureWrapMode.Repeat;
        leatherAlbedo.filterMode = FilterMode.Trilinear;
        leatherNormals.filterMode = FilterMode.Trilinear;
        leatherAlbedo.Apply();
        leatherNormals.Apply();
    }

    private static GameObject Cube(string name, Vector3 position, Vector3 size, Material material, Transform parent = null)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = name;
        if (parent != null) cube.transform.SetParent(parent, false);
        cube.transform.localPosition = position;
        cube.transform.localScale = size;
        cube.GetComponent<Renderer>().sharedMaterial = material;
        return cube;
    }

    private static GameObject Sphere(string name, Vector3 position, Vector3 size, Material material, Transform parent = null)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.name = name;
        if (parent != null) sphere.transform.SetParent(parent, false);
        sphere.transform.localPosition = position;
        sphere.transform.localScale = size;
        sphere.GetComponent<Renderer>().sharedMaterial = material;
        return sphere;
    }

    private void BuildRoom()
    {
        Material floor = MakeStandard(new Color(0.58f, 0.62f, 0.64f));
        Material wall = MakeStandard(new Color(0.86f, 0.88f, 0.89f));
        Material trim = MakeStandard(new Color(0.35f, 0.39f, 0.42f));
        Material rug = MakeStandard(new Color(0.25f, 0.34f, 0.44f));
        Material glass = MakeStandard(new Color(0.72f, 0.86f, 0.93f));
        Material plant = MakeStandard(new Color(0.13f, 0.38f, 0.27f));
        Cube("Floor", new Vector3(0, -0.14f, 0), new Vector3(17f, 0.24f, 13f), floor);
        Cube("Back Wall", new Vector3(0, 3.1f, 4.6f), new Vector3(17f, 6.5f, 0.18f), wall);
        Cube("Left Wall", new Vector3(-8.35f, 3.1f, 0), new Vector3(.18f, 6.5f, 13f), wall);
        Cube("Rug", new Vector3(0, .01f, -.4f), new Vector3(10.7f, .025f, 5f), rug);
        Cube("Skirting Board", new Vector3(0, .10f, 4.46f), new Vector3(16.8f, .25f, .14f), trim);
        Cube("Window Glass", new Vector3(-4.9f, 3.15f, 4.43f), new Vector3(2.7f, 2.65f, .06f), glass);
        Cube("Window Vertical Trim", new Vector3(-4.9f, 3.15f, 4.33f), new Vector3(.07f, 2.75f, .1f), trim);
        Cube("Window Horizontal Trim", new Vector3(-4.9f, 3.15f, 4.33f), new Vector3(2.82f, .07f, .1f), trim);
        Cube("Plant Pot", new Vector3(6.0f, .38f, 2.7f), new Vector3(.7f, .74f, .7f), trim);
        for (int i = 0; i < 7; i++)
        {
            float a = i * 1.19f;
            Sphere("Plant Leaf", new Vector3(6f + Mathf.Cos(a) * .36f, 1.0f + i * .16f, 2.7f + Mathf.Sin(a) * .36f),
                new Vector3(.22f, .60f, .28f), plant);
        }
        Cube("Display Platform Chair", new Vector3(-2.9f, .08f, 0f), new Vector3(3.0f, .16f, 2.8f), interiorMaterial);
        Cube("Display Platform Sofa", new Vector3(2.3f, .08f, 0f), new Vector3(4.4f, .16f, 2.8f), interiorMaterial);
    }

    private void BuildFurniture()
    {
        Material wood = MakeStandard(new Color(.30f, .18f, .12f));
        chairRoot = new GameObject("Red Velvet Chair").transform;
        chairRoot.position = new Vector3(-2.9f, .16f, 0f);
        Cube("Chair Seat", new Vector3(0, 1.10f, 0), new Vector3(1.72f, .34f, 1.42f), chairMaterial, chairRoot);
        Cube("Chair Back", new Vector3(0, 1.82f, .54f), new Vector3(1.72f, 1.56f, .30f), chairMaterial, chairRoot);
        Cube("Chair Left Arm", new Vector3(-.82f, 1.40f, -.05f), new Vector3(.23f, .60f, 1.48f), chairMaterial, chairRoot);
        Cube("Chair Right Arm", new Vector3(.82f, 1.40f, -.05f), new Vector3(.23f, .60f, 1.48f), chairMaterial, chairRoot);
        for (int sx = -1; sx <= 1; sx += 2)
        for (int sz = -1; sz <= 1; sz += 2)
            Cube("Chair Leg", new Vector3(sx * .65f, .50f, sz * .5f), new Vector3(.18f, .90f, .19f), wood, chairRoot);
        Sphere("Chair Cushion", new Vector3(0, 1.30f, -.15f), new Vector3(1.5f, .16f, 1.10f), chairMaterial, chairRoot);

        sofaRoot = new GameObject("Leather Sofa").transform;
        sofaRoot.position = new Vector3(2.3f, .16f, 0f);
        Cube("Sofa Body", new Vector3(0, 0.93f, 0), new Vector3(3.58f, .65f, 1.52f), sofaMaterial, sofaRoot);
        Cube("Sofa Back", new Vector3(0, 1.60f, .57f), new Vector3(3.58f, 1.38f, .38f), sofaMaterial, sofaRoot);
        Cube("Left Arm", new Vector3(-1.67f, 1.25f, -.02f), new Vector3(.35f, .92f, 1.54f), sofaMaterial, sofaRoot);
        Cube("Right Arm", new Vector3(1.67f, 1.25f, -.02f), new Vector3(.35f, .92f, 1.54f), sofaMaterial, sofaRoot);
        for (int i = -1; i <= 1; ++i)
        {
            Cube("Leather Seat Cushion", new Vector3(i * 1.05f, 1.30f, -.13f), new Vector3(1.00f, .18f, 1.23f), sofaMaterial, sofaRoot);
            Cube("Leather Back Cushion", new Vector3(i * 1.05f, 1.78f, .34f), new Vector3(1.00f, .85f, .20f), sofaMaterial, sofaRoot);
        }
        for (int sx = -1; sx <= 1; sx += 2)
        for (int sz = -1; sz <= 1; sz += 2)
            Cube("Sofa Leg", new Vector3(sx * 1.45f, .32f, sz * .58f), new Vector3(.18f, .56f, .18f), wood, sofaRoot);
    }

    private void BuildLightingAndCamera()
    {
        // Clear pixels outside camera.rect so viewport changes never leave stale frames.
        backgroundCamera = new GameObject("Viewport Background").AddComponent<Camera>();
        backgroundCamera.depth = -10;
        backgroundCamera.cullingMask = 0;
        backgroundCamera.clearFlags = CameraClearFlags.SolidColor;
        backgroundCamera.backgroundColor = new Color(.035f, .055f, .075f);
        sun = new GameObject("Room Daylight - Directional").AddComponent<Light>();
        sun.type = LightType.Directional;
        sun.color = new Color(1f, .91f, .82f);
        sun.intensity = roomBrightness;
        sun.transform.rotation = Quaternion.Euler(49, -42, 0);
        GameObject go = new GameObject("Main Camera");
        go.tag = "MainCamera";
        sceneCamera = go.AddComponent<Camera>();
        sceneCamera.clearFlags = CameraClearFlags.SolidColor;
        sceneCamera.backgroundColor = new Color(.07f, .12f, .16f);
        sceneCamera.fieldOfView = 55f;
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (sceneCamera == null) return;
        float left = 370f * GuiScale / Screen.width;
        float right = showViewport ? 294f * GuiScale / Screen.width : 12f * GuiScale / Screen.width;
        Rect available = new Rect(left, 54f * GuiScale / Screen.height, 1f - left - right,
                                  1f - 70f * GuiScale / Screen.height);
        sceneCamera.rect = viewportMode == 0 ? available : new Rect(
            available.x + available.width * .1f, available.y + available.height * .15f,
            available.width * .8f, available.height * .7f);
        // Preserve a useful horizontal view even when the demonstration viewport narrows.
        sceneCamera.fieldOfView = Mathf.Clamp(2f * Mathf.Atan(Mathf.Tan(27.5f * Mathf.Deg2Rad) /
            Mathf.Min(1f, sceneCamera.aspect / 1.5f)) * Mathf.Rad2Deg, 40f, 95f);
        Vector3 target = cameraTarget;
        Quaternion orbit = Quaternion.Euler(orbitPitch, orbitYaw, 0);
        sceneCamera.transform.position = target + orbit * new Vector3(0f, 0f, -orbitDistance);
        sceneCamera.transform.LookAt(target);
    }

    private void ApplyGraphicsSettings()
    {
        if (chairMaterial == null || sofaMaterial == null) return;
        foreach (Material m in new[] { chairMaterial, sofaMaterial })
        {
            m.SetFloat("_AmbientStrength", lightingMode >= 0 ? .20f * roomBrightness : 0f);
            m.SetFloat("_DiffuseStrength", lightingMode >= 1 ? 1.05f : 0f);
            m.SetFloat("_SpecularStrength", lightingMode >= 2 ? (m == chairMaterial ? .12f : specularStrength) : 0f);
            m.SetFloat("_UseTexture", m == sofaMaterial && showTexture ? 1 : 0);
            m.SetFloat("_UseBump", m == sofaMaterial && showBump ? 1 : 0);
        }
        if (sun != null) sun.intensity = roomBrightness;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) lightingMode = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) lightingMode = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) lightingMode = 2;
        if (Input.GetKeyDown(KeyCode.T)) showTexture = !showTexture;
        if (Input.GetKeyDown(KeyCode.B)) showBump = !showBump;
        if (Input.GetKeyDown(KeyCode.V)) showViewport = !showViewport;
        if (Input.GetKeyDown(KeyCode.R)) ResetCamera();
        if (Input.GetKeyDown(KeyCode.F)) FocusSelected();
        if (Input.GetKey(KeyCode.LeftArrow)) TurnSelected(-48f * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow)) TurnSelected(48f * Time.deltaTime);
        Vector2 guiMouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y) / Mathf.Max(.1f, GuiScale);
        bool overUI = ControlsRect.Contains(guiMouse) || FooterRect.Contains(guiMouse) ||
                      (showViewport && MappingRect.Contains(guiMouse));
        if (!overUI) orbitDistance = Mathf.Clamp(orbitDistance - Input.mouseScrollDelta.y * .35f, 3.5f, 15f);
        if (Input.GetMouseButtonDown(0) && !overUI)
        {
            isDragging = true;
            previousMouse = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) isDragging = false;
        if (isDragging && Input.GetMouseButton(0))
        {
            Vector2 now = Input.mousePosition;
            Vector2 delta = now - previousMouse;
            orbitYaw = Mathf.Clamp(orbitYaw + delta.x * .20f, -65f, 65f);
            orbitPitch = Mathf.Clamp(orbitPitch - delta.y * .16f, 5f, 72f);
            previousMouse = now;
        }
        MoveCamera();
        ApplyGraphicsSettings();
    }

    private void ResetCamera()
    {
        cameraTarget = new Vector3(0f, 1.25f, 0f);
        orbitYaw = 0f; orbitPitch = 19f; orbitDistance = 10.6f;
    }

    private void FocusSelected()
    {
        Transform item = selectedFurniture == 0 ? chairRoot : sofaRoot;
        if (item == null) return;
        cameraTarget = item.position + Vector3.up * 1.2f;
        orbitDistance = 4.8f;
        orbitYaw = -12f;
        orbitPitch = 15f;
    }

    private void TurnSelected(float degrees)
    {
        Transform t = selectedFurniture == 0 ? chairRoot : sofaRoot;
        if (t != null) t.Rotate(Vector3.up, degrees, Space.World);
    }

    private void OnGUI()
    {
        if (headingStyle == null)
        {
            headingStyle = new GUIStyle(GUI.skin.label) { fontSize = 17, fontStyle = FontStyle.Bold, wordWrap = true };
            headingStyle.normal.textColor = Color.white;
            labelStyle = new GUIStyle(GUI.skin.label) { fontSize = 12, wordWrap = true };
            labelStyle.normal.textColor = Color.white;
        }
        Matrix4x4 previousMatrix = GUI.matrix;
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one * GuiScale);
        GUI.color = new Color(.12f, .20f, .27f, 1f);
        GUI.DrawTexture(ControlsRect, Texture2D.whiteTexture);
        GUI.color = Color.white;
        GUI.Label(new Rect(25, 24, 318, 45), "CIE3 | Furniture Studio", headingStyle);
        GUI.Label(new Rect(25, 62, 314, 33), "CASE STUDY 3 - Retail & Remote Commerce", labelStyle);

        GUI.Label(new Rect(25, 104, 315, 20), "1. PHONG ILLUMINATION", headingStyle);
        if (GUI.Button(new Rect(25, 130, 96, 29), "1 Ambient")) lightingMode = 0;
        if (GUI.Button(new Rect(127, 130, 97, 29), "2 + Diffuse")) lightingMode = 1;
        if (GUI.Button(new Rect(230, 130, 110, 29), "3 + Specular")) lightingMode = 2;
        GUI.Label(new Rect(25, 167, 310, 20), "Daylight intensity: " + roomBrightness.ToString("F2"), labelStyle);
        roomBrightness = GUI.HorizontalSlider(new Rect(28, 190, 300, 20), roomBrightness, .25f, 1.7f);
        GUI.Label(new Rect(25, 213, 310, 20), "Sofa specular: " + specularStrength.ToString("F2"), labelStyle);
        specularStrength = GUI.HorizontalSlider(new Rect(28, 235, 300, 18), specularStrength, 0f, .9f);

        GUI.Label(new Rect(25, 263, 310, 20), "2. LEATHER TEXTURE + BUMP", headingStyle);
        showTexture = GUI.Toggle(new Rect(25, 290, 310, 22), showTexture, "Apply texture mapping (color)");
        showBump = GUI.Toggle(new Rect(25, 318, 310, 22), showBump, "Apply bump / normal mapping");

        GUI.Label(new Rect(25, 346, 312, 20), "3. INTERACTION + VIEWPORT", headingStyle);
        if (GUI.Button(new Rect(25, 374, 153, 28), selectedFurniture == 0 ? "Chair selected" : "Select chair")) selectedFurniture = 0;
        if (GUI.Button(new Rect(186, 374, 154, 28), selectedFurniture == 1 ? "Sofa selected" : "Select sofa")) selectedFurniture = 1;
        showViewport = GUI.Toggle(new Rect(25, 413, 310, 22), showViewport, "Show viewport transformation");

        GUI.Label(new Rect(25, 441, 310, 24), new[] { "Ambient only", "Ambient + diffuse", "Ambient + diffuse + specular" }[lightingMode], labelStyle);
        if (GUI.Button(new Rect(25, 473, 151, 30), "Focus selected (F)")) FocusSelected();
        if (GUI.Button(new Rect(184, 473, 156, 30), "Room view (R)")) ResetCamera();
        GUI.Label(new Rect(25, 515, 310, 28), "I = ambient + diffuse + specular", labelStyle);
        if (showViewport) DrawViewportOverlay();
        GUI.color = new Color(.03f, .07f, .10f, .87f);
        GUI.DrawTexture(FooterRect, Texture2D.whiteTexture);
        GUI.color = Color.white;
        GUI.Label(new Rect(22, GuiHeight - 42, GuiWidth - 44, 34),
            "DRAG to orbit  |  SCROLL zoom  |  LEFT/RIGHT rotate selected  |  1/2/3 lighting  |  T texture  |  B bump  |  V mapping  |  R reset",
            labelStyle);
        GUI.matrix = previousMatrix;
    }

    private void DrawViewportOverlay()
    {
        const float panelWidth = 270f;
        float px = MappingRect.x;
        GUI.color = new Color(.04f, .08f, .12f, .93f);
        GUI.DrawTexture(MappingRect, Texture2D.whiteTexture);
        GUI.color = Color.white;
        GUI.Label(new Rect(px + 12, 24, panelWidth - 24, 30), "Window -> Viewport", headingStyle);
        Rect view = new Rect(px + 20, 64, 100, 180);
        GUI.color = new Color(.19f, .35f, .49f, 1f);
        GUI.DrawTexture(view, Texture2D.whiteTexture);
        GUI.color = Color.white;
        GUI.Box(view, GUIContent.none);

        Rect logicalWindow = new Rect(-1, -1, 2, 2);
        Vector2 pixel = WindowToViewport(logicalPoint, logicalWindow, phoneViewportPixels);
        float u = (pixel.x - phoneViewportPixels.xMin) / phoneViewportPixels.width;
        float v = (pixel.y - phoneViewportPixels.yMin) / phoneViewportPixels.height;
        Rect dot = new Rect(view.x + u * view.width - 6, view.y + (1 - v) * view.height - 6, 12, 12);
        GUI.color = new Color(1f, .32f, .28f, 1f);
        GUI.DrawTexture(dot, Texture2D.whiteTexture);
        GUI.color = Color.white;
        GUI.Label(new Rect(px + 128, 64, panelWidth - 134, 160),
            "Logical window:\n[-1,1] x [-1,1]\n\nPoint (" + logicalPoint.x.ToString("F2") + ", " + logicalPoint.y.ToString("F2") + ")\n\nViewport (px):\nx: 70..1010\ny: 120..1800\n\nMapped:", labelStyle);
        GUI.Label(new Rect(px + 128, 228, panelWidth - 140, 29),
            "(" + pixel.x.ToString("F1") + ", " + pixel.y.ToString("F1") + ")", labelStyle);
        GUI.Label(new Rect(px + 20, 252, panelWidth - 30, 25), "Bottom-left origin; GUI Y is flipped", labelStyle);
        GUI.Label(new Rect(px + 20, 282, 228, 22), "Logical X: " + logicalPoint.x.ToString("F2"), labelStyle);
        logicalPoint.x = GUI.HorizontalSlider(new Rect(px + 20, 306, 228, 18), logicalPoint.x, -1f, 1f);
        GUI.Label(new Rect(px + 20, 328, 228, 22), "Logical Y: " + logicalPoint.y.ToString("F2"), labelStyle);
        logicalPoint.y = GUI.HorizontalSlider(new Rect(px + 20, 352, 228, 18), logicalPoint.y, -1f, 1f);
        if (GUI.Button(new Rect(px + 20, 379, 108, 28), "Reset point")) logicalPoint = new Vector2(LogicalX, LogicalY);
        if (GUI.Button(new Rect(px + 135, 379, 115, 28), viewportMode == 0 ? "Inset viewport" : "Fill viewport")) viewportMode = 1 - viewportMode;
        if (sceneCamera != null)
        {
            Rect actual = sceneCamera.pixelRect;
            Vector2 mapped = WindowToViewport(logicalPoint, logicalWindow, actual);
            GUI.Label(new Rect(px + 20, 414, 230, 57), "Actual camera viewport: " + actual.width.ToString("F0") + " x " + actual.height.ToString("F0") +
                " px\nMapped screen point: (" + mapped.x.ToString("F1") + ", " + mapped.y.ToString("F1") + ")", labelStyle);
            GUI.color = new Color(1f, .62f, .25f);
            GUI.DrawTexture(new Rect(mapped.x / GuiScale - 4f, (Screen.height - mapped.y) / GuiScale - 4f, 8f, 8f), Texture2D.whiteTexture);
            GUI.color = Color.white;
        }
    }

    private void OnDestroy()
    {
        if (chairMaterial != null) Destroy(chairMaterial);
        if (sofaMaterial != null) Destroy(sofaMaterial);
        if (leatherAlbedo != null) Destroy(leatherAlbedo);
        if (leatherNormals != null) Destroy(leatherNormals);
    }
}
