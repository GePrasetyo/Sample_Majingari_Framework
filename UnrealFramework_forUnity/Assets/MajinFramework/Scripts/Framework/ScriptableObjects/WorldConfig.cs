using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Majingari.Framework.World {
    [CreateAssetMenu(fileName = "Default World Config", menuName = "Config Object/World Config")]
    public class WorldConfig : ScriptableObject {
        [SerializeField] private WorldAssetConfig[] mapList = new WorldAssetConfig[0];
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
}
