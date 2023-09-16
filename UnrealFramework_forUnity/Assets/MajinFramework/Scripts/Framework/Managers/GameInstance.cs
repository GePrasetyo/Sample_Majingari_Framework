using Majingari.Framework.World;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Majingari.Framework {
    [Serializable]
    public class GameInstance {
        protected WorldConfig worldSetting;
        public GameInstance() {
            Debug.Log($"Game Instance generated : {this.GetType()}");

            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }

        public void Construct(WorldConfig _worldSetting) {
            worldSetting = _worldSetting;
        }


        protected void OnActiveSceneChanged(Scene prevScene, Scene nextScene) {

        }

        protected void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            if(mode != LoadSceneMode.Single) {
                return;
            }

            if (worldSetting.MapConfigList.ContainsKey(scene.name)) {
                worldSetting.MapConfigList[scene.name].TheGameMode.InitiateGameManager();
                worldSetting.MapConfigList[scene.name].TheGameMode.InstantiatePlayer();
            }
        }
    }
}