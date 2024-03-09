using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MatConv
{
    public class EditorUtils : MonoBehaviour
    {
        public static GameObject[] LoadSelectedObjects()
        {
            GameObject[] selectedObject = Selection.gameObjects;
            return selectedObject;
        }

        // Ensures the specified directory exists; creates it if it does not.
        public static (string, string) EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                AssetDatabase.Refresh();
                return (path, null);
            }
            else
            {
                int counter = 1;
                string newPath;
                do
                {
                    newPath = $"{path}_{counter++}";
                }
                while (Directory.Exists(newPath));

                Directory.CreateDirectory(newPath);
                AssetDatabase.Refresh();
                return (newPath, counter.ToString());
            }
        }

        public static (string, string) CreateDirectoryInActiveSceneDirectoryAndReturnPath(string directoryName)
        {
            var activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

            if (string.IsNullOrEmpty(activeScene.path))
            {
                bool saveSuccess = UnityEditor.SceneManagement.EditorSceneManager.SaveScene(activeScene);
                if (!saveSuccess)
                {
                    throw new Exception("Please save the scene first.");
                }
            }

            string sceneDirectory = Path.GetDirectoryName(activeScene.path);
            string targetDirectoryPath = Path.Combine(sceneDirectory, directoryName);

            return EnsureDirectoryExists(targetDirectoryPath);
        }
    }
}