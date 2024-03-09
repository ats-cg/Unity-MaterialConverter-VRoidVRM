using UnityEngine;

namespace MatConv
{
    public class URPLitConverter : MaterialConverter
    {
        public const string CONVERTER_ID = "URPLit";

        public override string Id => CONVERTER_ID;

        public override Material Convert(Material material)
        {
            if (material.shader.name == MToon10Info.ShaderName)
            {
                return Convert(MaterialConversionManager.ConvertMaterial(material, URPMToon10Converter.CONVERTER_ID));
            }

            Material newMaterial = new(material);

            var targetShader = ShaderUtils.FindShader(URPLitInfo.ShaderName);
            newMaterial.shader = targetShader;

            if (material.shader.name == URPMToon10Info.ShaderName)
            {
                newMaterial.SetTexture(URPLitInfo.TextureBaseMap, material.GetTexture(URPMToon10Info.TextureMainTex));
                newMaterial.SetColor(URPLitInfo.ColorBaseColor, material.GetColor(URPMToon10Info.ColorColor));
                newMaterial.SetTexture(URPLitInfo.TextureBumpMap, material.GetTexture(URPMToon10Info.TextureBumpMap));
                newMaterial.SetTexture(URPLitInfo.TextureEmissionMap, material.GetTexture(URPMToon10Info.TextureEmissionMap));
                newMaterial.SetColor(URPLitInfo.ColorEmissionColor, material.GetColor(URPMToon10Info.ColorEmissionColor));
                newMaterial.SetFloat(URPLitInfo.FloatAlphaClip, 1.0f - material.GetFloat(URPMToon10Info.FloatMAlphaToMask));
                newMaterial.SetFloat(URPLitInfo.FloatZWrite, material.GetFloat(URPMToon10Info.FloatMZWrite));
                newMaterial.SetFloat(URPLitInfo.FloatCull, material.GetFloat(URPMToon10Info.FloatMCullMode));
                newMaterial.SetFloat(URPLitInfo.FloatAlphaClip, 1f);
            }

            newMaterial.renderQueue = material.renderQueue;

            return newMaterial;
        }
    }
}
