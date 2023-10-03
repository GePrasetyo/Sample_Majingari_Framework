using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Majingari.Framework.World {
    [CreateAssetMenu(fileName = "Default World Config", menuName = "Config Object/World Config")]
    public class WorldConfig : ScriptableObject {
        [SerializeField] private WorldAssetConfig[] mapList = new WorldAssetConfig[0];
        [SerializeField] private AddressableSceneHandler[] levelStreamCollection = Array.Empty<AddressableSceneHandler>();

        public Dictionary<string, WorldAssetConfig> MapConfigList = new Dictionary<string, WorldAssetConfig>();

        public void SetupMapConfigList() {
            MapConfigList.Clear();

            if (mapList.Length == 0)
                return;

            for (int i = 0; i < mapList.Length; i++) {
                MapConfigList[mapList[i].mapName] = mapList[i];
            }
        }
    }

    [Serializable]
    public class WorldAssetConfig {
#if UNITY_EDITOR
        public SceneAsset Map;
#endif
        public string mapName;
        public GameModeManager TheGameMode;
    }

    [Serializable]
    public class AddressableSceneHandler {
        public string sceneName;
        public AssetReference sceneAddressable;
        public AsyncOperationHandle<SceneInstance> streamHandler;
        public Action<string> streamHandlerCompleted;

        public void UpdateHandler(AsyncOperationHandle<SceneInstance> obj) {
            Debug.Log($"Handler Scene {obj.Status}");

            if (obj.Status == AsyncOperationStatus.Failed) {
                goto Reset;
            }

            LightProbes.TetrahedralizeAsync();
            streamHandler = obj;
            streamHandlerCompleted?.Invoke(obj.Result.Scene.path);

            Reset:
            streamHandlerCompleted = null;
        }
    }
}
