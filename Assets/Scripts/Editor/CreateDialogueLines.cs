using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateDialogueLines
{
    [MenuItem("Assets/Create dialogue line")]
    public static void Generate()
    {
        // Carpeta donde guardar los SO
        string outputFolder = "Assets/Theatre data";

        if (!AssetDatabase.IsValidFolder(outputFolder))
            AssetDatabase.CreateFolder("Assets", "Theatre data");

        // Recorremos solo la selección
        foreach (var obj in Selection.objects)
        {
            if (obj is AudioClip clip)
            {
                string soPath = Path.Combine(outputFolder, clip.name + ".asset");

                // Evita duplicados
                if (File.Exists(soPath))
                {
                    Debug.LogWarning($"Ya existe un SO para {clip.name}, saltando...");
                    continue;
                }

                // Crea el ScriptableObject
                DialogueLine so = ScriptableObject.CreateInstance<DialogueLine>();
                so.clip = clip;

                AssetDatabase.CreateAsset(so, soPath);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }


    // Habilita opción solo si hay AudioClips seleccionados
    [MenuItem("Assets/Generar SO desde selección", true)]
    public static bool ValidateGenerate()
    {
        foreach (var obj in Selection.objects)
            if (obj is AudioClip)
                return true;

        return false;
    }

}
