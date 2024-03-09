using UnityEngine;

namespace MatConv
{
    public class URPMToon10Converter : MaterialConverter
    {
        public const string CONVERTER_ID = "URPMToon10";

        public override string Id => CONVERTER_ID;

        public override Material Convert(Material material)
        {
            Material newMaterial = new(material);

            var targetShader = ShaderUtils.FindShader(URPMToon10Info.ShaderName);
            newMaterial.shader = targetShader;

            if (material.shader.name == URPLitInfo.ShaderName)
            {
                newMaterial.SetTexture(URPMToon10Info.TextureMainTex, material.GetTexture(URPLitInfo.TextureBaseMap));
                newMaterial.SetColor(URPMToon10Info.ColorColor, material.GetColor(URPLitInfo.ColorBaseColor));
                newMaterial.SetTexture(URPMToon10Info.TextureBumpMap, material.GetTexture(URPLitInfo.TextureBumpMap));
                newMaterial.SetTexture(URPMToon10Info.TextureEmissionMap, material.GetTexture(URPLitInfo.TextureEmissionMap));
                newMaterial.SetColor(URPMToon10Info.ColorEmissionColor, material.GetColor(URPLitInfo.ColorEmissionColor));
                newMaterial.SetFloat(URPMToon10Info.FloatMAlphaToMask, 1.0f - material.GetFloat(URPLitInfo.FloatAlphaClip));
                newMaterial.SetFloat(URPMToon10Info.FloatMZWrite, material.GetFloat(URPLitInfo.FloatZWrite));
                newMaterial.SetFloat(URPMToon10Info.FloatMCullMode, material.GetFloat(URPLitInfo.FloatCull));
            }

            newMaterial.renderQueue = material.renderQueue;

            return newMaterial;
        }
    }
}
