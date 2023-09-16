using UnityEngine;
using System;
using Majingari.Framework.World;
using Object = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Majingari.Framework
{
    public sealed class GameWorldSettings : ScriptableObject
    {
        [SerializeReference] public GameInstance classGameInstance;
        [SerializeField] private WorldConfig worldConfigObject;

        [RuntimeInitializeOnLoadMethod]
        private static void WorldBuilderStart()
        {
            var objs = Resources.FindObjectsOfTypeAll<GameWorldSettings>();

            if (objs.Length > 0) {
                var obj = objs[0];

                if (obj.worldConfigObject == null) {
                    Debug.LogError("You don't have World Config, please attach World Config first");
                }

                obj.worldConfigObject.SetupMapConfigList();
                var gameInstance = Activator.CreateInstance(obj.classGameInstance.GetType()) as GameInstance;
                ServiceLocator.Register<GameInstance>(gameInstance);
            }
            else {
                Debug.LogError("You don't have world settings, please create the world setting first");
            }
        }

#if UNITY_EDITOR
        [InitializeOnLoadMethod]
        private static void OnEditorLoad() {
            var obj = Resources.FindObjectsOfTypeAll<GameWorldSettings>();

            if (obj.Length > 1) {
                Debug.LogError("WARNING : You have duplicated GameWorldSettings");
                return;
            }

            if (obj.Length == 0) {
                CreateGameWorldAsset();
            }

        }

        [MenuItem("Game Word Settings/Get World Settings")]
        public static void GetTheInstance() {
            var obj = Resources.FindObjectsOfTypeAll<GameWorldSettings>();

            if (obj.Length > 0) {
                Selection.activeObject = obj[0];
            }
            else {
                CreateGameWorldAsset();
            }
        }

        private static void CreateGameWorldAsset() {
            var asset = ScriptableObject.CreateInstance<GameWorldSettings>();
            Selection.activeObject = asset;
            AssetDatabase.CreateAsset(asset, "Assets/GameWorldSettings.asset");
            AssetDatabase.SaveAssets();
        }
#endif
    }
}
