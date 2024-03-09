using UnityEditor;
using UnityEngine;

namespace MatConv
{
    public class MaterialConvertMenu : MonoBehaviour
    {
        [MenuItem("MatConv/Convert Materials/into URPMToon10 Materials")]
        public static void ConvertIntoURPMToonMenu()
        {
            MaterialConversionManager.ConvertMaterialsOfSelectedGameObjectsAndCreateAssets(URPMToon10Converter.CONVERTER_ID);
        }

        [MenuItem("MatConv/Convert Materials/into URPLit Materials")]
        public static void ConvertIntoURPLitMenu()
        {
            MaterialConversionManager.ConvertMaterialsOfSelectedGameObjectsAndCreateAssets(URPLitConverter.CONVERTER_ID);
        }

        [MenuItem("MatConv/Convert Materials/into URPUnit Materials")]
        public static void ConvertIntoURPUnlitMenu()
        {
            MaterialConversionManager.ConvertMaterialsOfSelectedGameObjectsAndCreateAssets(URPUnlitConverter.CONVERTER_ID);
        }

        [MenuItem("MatConv/Convert Materials/into LiltoonMulti Materials")]
        public static void ConvertIntoLiltoonMultiMenu()
        {
            MaterialConversionManager.ConvertMaterialsOfSelectedGameObjectsAndCreateAssets(LiltoonMultiConveter.CONVERTER_ID);
        }
    }
}