using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Majingari.Framework.World {
    [CreateAssetMenu(fileName = "Default World Config", menuName = "Config Object/World Config")]
    public class WorldConfig : ScriptableObject {
        [SerializeField] private bool playFromStart;
#if UNITY_EDITOR
        [SerializeField] private SceneAsset startMap;
#endif
        private string startMapName;
        
        [SerializeField] private WorldConfigList[] mapList = new WorldConfigList[0];
        public Dictionary<string, WorldConfigList> MapConfigList = new Dictionary<string, WorldConfigList>();

        public void SetupMapConfigList() {
            MapConfigList.Clear();

            if (mapList.Length == 0)
                return;

            for (int i = 0; i < mapList.Length; i++) {
                MapConfigList[mapList[i].mapName] = mapList[i];
            }

            if (!playFromStart)
                return;

            SceneManager.LoadScene(startMapName);
        }

#if UNITY_EDITOR
        private void OnValidate() {
            startMapName = startMap == null ? "" : startMap.name;

            for (int i = 0; i < mapList.Length; i++) {
                mapList[i].mapName = mapList[i].Map == null ? "" : mapList[i].Map.name;
            }

            //EditorUtility.SetDirty(this);
        }
#endif
    }

    [Serializable]
    public struct WorldConfigList {
#if UNITY_EDITOR
        public SceneAsset Map;
#endif
        [HideInInspector] public string mapName;
        public GameModeManager TheGameMode;
    }
}
