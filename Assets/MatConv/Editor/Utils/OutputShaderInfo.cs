using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

class OutputShaderInfo
{
    private static readonly string OutputDir = "./Assets/MatConv/Editor/ShaderInfo";

    [MenuItem("MatConv/Output ShaderInfo class file")]
    public static void OutputShaderInfoFromSelectedMaterial()
    {
        if (Selection.activeObject is not Material material)
        {
            Debug.LogError("Select a Material");
            return;
        }

        var shader = material.shader;
        var shaderName = ToPascal(shader.name);
        var sb = $"public class {shaderName}Info {{\n";
        sb += $" public const string ShaderName = \"{shader.name}\"; \n";

        for (int i = 0; i < shader.GetPropertyCount(); i++)
        {
            var propName = shader.GetPropertyName(i);
            var propType = shader.GetPropertyType(i);
            var variableName = ToPascal($"{propType}{propName}");
            sb += $" public const string {variableName} = \"{propName}\"; \n";
        }
        sb += "}";

        var outputPath = Path.Combine(OutputDir, $"{shaderName}Info.cs");
        File.WriteAllText(outputPath, sb);

        AssetDatabase.Refresh();

        Debug.Log($"Successful: {outputPath}");
    }

    public static string ToPascal(string str)
    {
        return Regex.Replace(str, @"(?:^|[\s_\/])(.)", m => m.Groups[1].Value.ToUpper());
    }
}
