using UnityEngine;

namespace MatConv
{
    public class LiltoonMultiConveter : MaterialConverter
    {
        public const string CONVERTER_ID = "LilMulti";

        public override string Id => CONVERTER_ID;

        public override Material Convert(Material material)
        {
            if (material.shader.name == MToon10Info.ShaderName || material.shader.name == URPLitInfo.ShaderName)
            {
                return Convert(MaterialConversionManager.ConvertMaterial(material, URPMToon10Converter.CONVERTER_ID));
            }

            Material newMaterial = new(material);

            Shader targetShader = ShaderUtils.FindShader(LiltoonMultiInfo.ShaderName);
            newMaterial.shader = targetShader;

            if (material.shader.name == URPMToon10Info.ShaderName)
            {
                var alphaToMask = material.GetFloat(URPMToon10Info.FloatMAlphaToMask);
                var blendMode = material.GetFloat(URPMToon10Info.FloatAlphaMode);
                if (blendMode == 0)
                {
                    newMaterial.SetFloat(LiltoonMultiInfo.FloatTransparentMode, 0 /*(float)lilToon.RenderingMode.Opaque*/);
                }
                else if (alphaToMask == 0)
                {
                    newMaterial.SetFloat(LiltoonMultiInfo.FloatTransparentMode, 2 /*(float)lilToon.RenderingMode.Transparent*/);
                }
                else
                {
                    newMaterial.SetFloat(LiltoonMultiInfo.FloatTransparentMode, 1 /*(float)lilToon.RenderingMode.Cutout*/);
                }

                newMaterial.SetFloat(LiltoonMultiInfo.FloatCull, material.GetFloat(URPMToon10Info.FloatMCullMode));
            }

            newMaterial.renderQueue = material.renderQueue;

            return newMaterial;
        }
    }
}
