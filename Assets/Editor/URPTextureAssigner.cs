using UnityEditor;
using UnityEngine;
using System.IO;

public class URPTextureAssignerV2 : EditorWindow
{
    [MenuItem("Tools/Atribuir Texturas URP (por pasta)")]
    public static void AssignTextures()
    {
        string[] materialGUIDs = AssetDatabase.FindAssets("t:Material");

        foreach (string matGUID in materialGUIDs)
        {
            string matPath = AssetDatabase.GUIDToAssetPath(matGUID);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(matPath);

            if (mat.shader.name != "Universal Render Pipeline/Lit")
                continue;

            string folder = Path.GetDirectoryName(matPath);
            string matName = Path.GetFileNameWithoutExtension(matPath).ToLower();

            string[] texturesInFolder = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
            Texture2D baseMap = null;

            foreach (string texPath in texturesInFolder)
            {
                if (!texPath.EndsWith(".png") && !texPath.EndsWith(".jpg"))
                    continue;

                string texFileName = Path.GetFileNameWithoutExtension(texPath).ToLower();

                if (texFileName.Contains(matName))
                {
                    baseMap = AssetDatabase.LoadAssetAtPath<Texture2D>(texPath);
                    break;
                }
            }

            if (baseMap != null)
            {
                mat.SetTexture("_BaseMap", baseMap);
                Debug.Log($"✅ Textura associada a {mat.name}: {baseMap.name}");
            }
            else
            {
                Debug.LogWarning($"⚠️ Sem textura correspondente encontrada para: {mat.name}");
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("✔️ Atribuição de texturas concluída (por pasta)!");
    }
}
