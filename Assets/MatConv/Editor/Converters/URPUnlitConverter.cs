using UnityEngine;

namespace MatConv
{
    public class URPUnlitConverter : MaterialConverter
    {
        public const string CONVERTER_ID = "URPUnlit";

        public override string Id => CONVERTER_ID;

        public override Material Convert(Material material)
        {
            if (material.shader.name != URPLitInfo.ShaderName)
            {
                return Convert(MaterialConversionManager.ConvertMaterial(material, URPLitConverter.CONVERTER_ID));
            }

            Material newMaterial = new(material);

            var targetShader = ShaderUtils.FindShader(URPUnlitInfo.ShaderName);
            newMaterial.shader = targetShader;

            newMaterial.renderQueue = material.renderQueue;

            return newMaterial;
        }
    }
}
