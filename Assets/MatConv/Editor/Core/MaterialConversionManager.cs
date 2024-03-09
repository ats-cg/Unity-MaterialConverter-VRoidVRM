using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MatConv
{
    public class MaterialConversionManager : MonoBehaviour
    {
        public static MaterialConverter FindConverter(string converterId)
        {
            foreach (MaterialConverter converter in MaterialConvertersSettings.Converters)
            {
                if (converter.Id == converterId)
                {
                    return converter;
                }
            }
            throw new Exception($"{converterId} Converter not found.");
        }

        public static Material ConvertMaterial(Material material, string converterId)
        {
            MaterialConverter converter = FindConverter(converterId);
            try
            {
                return converter.Convert(material);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                return new Material(material);
            }
        }

        public static Material[] ConvertMaterials(Material[] materials, string converterId)
        {
            Material[] newMaterials = new Material[materials.Length];
            for (int i = 0; i < materials.Length; i++)
            {
                newMaterials[i] = ConvertMaterial(materials[i], converterId);
            }
            return newMaterials;
        }

        public static void ConvertMaterialsOfGameObject(GameObject gameObject, string converterId)
        {
            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
            if (renderers.Length == 0)
            {
                throw new Exception("No Renderer found in the GameObject.");
            }
            foreach (Renderer renderer in renderers)
            {
                renderer.sharedMaterials = ConvertMaterials(renderer.sharedMaterials, converterId);
            }
        }


        public static void ConvertMaterialsOfSelectedGameObjectsAndCreateAssets(string converterId)
        {
            GameObject[] targetGameObjects = EditorUtils.LoadSelectedObjects();

            if (targetGameObjects.Length == 0)
            {
                Debug.LogWarning("No GameObject selected.");
                return;
            }

            foreach (GameObject targetGameObject in targetGameObjects)
            {
                GameObject targetGameObjectCopy = Instantiate(targetGameObject, Vector3.zero, Quaternion.identity);
                try
                {
                    ConvertMaterialsOfGameObject(targetGameObjectCopy, converterId);
                    (string outputDirPath, string outputDirSuffix) = EditorUtils.CreateDirectoryInActiveSceneDirectoryAndReturnPath($"{targetGameObject.name}_{converterId}");

                    foreach (Renderer renderer in targetGameObjectCopy.GetComponentsInChildren<Renderer>())
                    {
                        foreach (Material material in renderer.sharedMaterials)
                        {
                            string newMaterialPath = Path.Combine(outputDirPath, $"{material.name}.mat");
                            AssetDatabase.CreateAsset(material, newMaterialPath);
                        }
                    }

                    string prefabPath = Path.Combine(outputDirPath, $"{targetGameObject.name}_{converterId}.prefab");
                    PrefabUtility.SaveAsPrefabAsset(targetGameObjectCopy, prefabPath);

                    GameObject prefabInstance = PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath)) as GameObject;
                    prefabInstance.name += outputDirSuffix != null ? $"_{outputDirSuffix}" : "";
                    prefabInstance.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                finally
                {
                    DestroyImmediate(targetGameObjectCopy);
                    AssetDatabase.Refresh();
                }
            }
        }
    }
}