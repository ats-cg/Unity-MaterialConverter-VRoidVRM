using System;
using UnityEngine;

namespace MatConv
{
    public class ShaderUtils
    {
        public static Shader FindShader(string shaderName)
        {
            Shader shader = Shader.Find(shaderName);
            return shader == null ? throw new Exception($"{shaderName} Shader is not found on this project.") : shader;
        }
    }
}