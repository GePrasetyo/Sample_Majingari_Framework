using UnityEngine;
using UnityEditor;

namespace Majingari.Framework
{
    [CustomEditor(typeof(GameWorldSettings))]
    public class GameWorldSettingsEditor : Editor
    {
        private GameWorldSettings _target;

        [MenuItem("Window/Game Word Settings/Get World Settings")]
        public static void GetTheInstance()
        {
            var obj = Resources.FindObjectsOfTypeAll<GameWorldSettings>();

            if (obj.Length > 0) {
                Selection.activeObject = obj[0];
            }
            else
            {
                var asset = ScriptableObject.CreateInstance<GameWorldSettings>();
                Selection.activeObject = asset;
                AssetDatabase.CreateAsset(asset, "Assets/GameWorldSettings.asset");
                AssetDatabase.SaveAssets();
            }
        }


        [MenuItem("Window/Game Word Settings/Restart Settings")]
        public static void ResetSettings()
        { 
            var obj = Resources.FindObjectsOfTypeAll<GameWorldSettings>();

            foreach (var o in obj)
                ScriptableObject.DestroyImmediate(o, true);
        }

        void OnEnable()
        {
            _target = (GameWorldSettings)target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        }

    }

}