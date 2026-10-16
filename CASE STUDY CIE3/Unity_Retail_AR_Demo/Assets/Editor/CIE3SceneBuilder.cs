using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>Opens the supplied scene on first import; rebuilds it if missing.</summary>
[InitializeOnLoad]
public static class CIE3SceneBuilder
{
    private const string ScenePath = "Assets/Scenes/CIE3_Retail_Furniture_Visualizer.unity";
    private const string OpenedKey = "CIE3.FurnitureSceneOpened";

    static CIE3SceneBuilder() { EditorApplication.delayCall += OpenOnFirstImport; }

    private static void OpenOnFirstImport()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode || Application.isBatchMode) return;
        if (EditorApplication.isCompiling || EditorApplication.isUpdating)
        {
            EditorApplication.delayCall += OpenOnFirstImport;
            return;
        }
        if (SessionState.GetBool(OpenedKey, false)) return;
        SessionState.SetBool(OpenedKey, true);
        // Never discard an existing scene edit on a domain reload.
        Scene active = SceneManager.GetActiveScene();
        if (active.isDirty || !string.IsNullOrEmpty(active.path)) return;
        EnsureScene();
        EditorSceneManager.OpenScene(ScenePath);
    }

    [MenuItem("CGVR CIE3/Open Furniture Visualizer")]
    public static void OpenScene()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode) return;
        if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;
        EnsureScene();
        EditorSceneManager.OpenScene(ScenePath);
    }

    [MenuItem("CGVR CIE3/Rebuild Furniture Scene")]
    public static void RebuildScene()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode) return;
        if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;
        BuildScene();
    }

    private static void EnsureScene()
    {
        if (AssetDatabase.LoadAssetAtPath<SceneAsset>(ScenePath) == null) BuildScene();
    }

    private static void BuildScene()
    {
        Directory.CreateDirectory("Assets/Scenes");
        AssetDatabase.Refresh();
        Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        GameObject root = new GameObject("CIE3 - Press Play to Build Furniture Studio");
        var demo = root.AddComponent<RetailARCaseStudyDemo>();
        demo.furnitureShader = AssetDatabase.LoadAssetAtPath<Shader>("Assets/Shaders/PhongFurniture.shader");
        EditorSceneManager.SaveScene(scene, ScenePath);
        EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(ScenePath, true) };
        AssetDatabase.SaveAssets();
        Debug.Log("CIE3 scene ready. Press Play for the room, furniture and graphics controls.");
    }
}
