using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

namespace Majingari.Framework.World
{
    [CreateAssetMenu(fileName = "Default World Config", menuName = "Config Object/World Config")]
    public class WorldConfig : ScriptableObject
    {
        private WorldConfigList[] mapList;
        public Dictionary<SceneAsset, GameModeManager> MapConfigList = new Dictionary<SceneAsset, GameModeManager>();

        private void OnValidate() {
            MapConfigList.Clear();

            for (int x=0; x<mapList.Length; x++) {
                MapConfigList.Add(mapList[x].Map, mapList[x].TheGameMode);
            }
        }
    }

    [Serializable]
    public struct WorldConfigList {
        public SceneAsset Map;
        public GameModeManager TheGameMode;
    }
}
