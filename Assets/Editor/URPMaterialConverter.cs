using UnityEditor;
using UnityEngine;

public class URPMaterialConverter : EditorWindow
{
    [MenuItem("Tools/Converter para URP")]
    public static void ConvertToURP()
    {
        string[] materialGUIDs = AssetDatabase.FindAssets("t:Material");

        foreach (string guid in materialGUIDs)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat.shader.name != "Universal Render Pipeline/Lit")
            {
                mat.shader = Shader.Find("Universal Render Pipeline/Lit");
                Debug.Log($"Convertido: {mat.name}");
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Conversão para URP concluída!");
    }
}
