#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Game.Scripts
{
    public static class PlayModeStartScene
    {
        private const string ScenePath = "Assets/Game/Scenes/_boot.unity";

        [MenuItem("Tools/Set Bootstrap Scene")]
        public static void SetBootstrapScene()
        {
            var scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(ScenePath);
            EditorSceneManager.playModeStartScene = scene;
            Debug.Log($"Play Mode start scene set to: {ScenePath}");
        }

        [MenuItem("Tools/Clear Bootstrap Scene")]
        public static void ClearBootstrapScene()
        {
            EditorSceneManager.playModeStartScene = null;
            Debug.Log("Play Mode start scene cleared");
        }
    }
}
#endif