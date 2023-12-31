﻿
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace MalbersAnimations
{
    [InitializeOnLoad]
    public static class SceneEditorManager
    {
        // constructor
        static SceneEditorManager()
        {
            EditorSceneManager.sceneOpened += SceneOpenedCallback;
        }

        static void SceneOpenedCallback(Scene _scene, UnityEditor.SceneManagement.OpenSceneMode _mode)
        {
            if (!string.IsNullOrEmpty(_scene.name))
            {

                var allGO = _scene.GetRootGameObjects();

                foreach (var go in allGO)
                {
                    var iscene = go.GetComponent<IScene>();

                    if (iscene != null)
                    {
                        iscene.SceneLoaded();
                        break;
                    }
                }
            }
        }
    }
}
#endif