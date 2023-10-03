using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Majingari.Framework.World {
    public class LevelStreamer {
        public void LoadAddressableScene(AddressableSceneHandler sceneToLoad, Action<string> loadComplete) {
            RegisterLoadCallbacks(sceneToLoad, (scenePath) => LoadSceneComplete(scenePath, sceneToLoad, loadComplete));
            Addressables.LoadSceneAsync(sceneToLoad.sceneAddressable, LoadSceneMode.Additive).Completed += sceneToLoad.UpdateHandler;
        }

        public void UnloadAddressableScene(AddressableSceneHandler sceneToUnload, Action<string> unloadComplete) {
            RegisterUnloadCallbacks(sceneToUnload, (scenePath) => UnloadSceneComplete(scenePath, sceneToUnload, unloadComplete));
            Addressables.UnloadSceneAsync(sceneToUnload.streamHandler).Completed += sceneToUnload.UpdateHandler;
        }

        private void RegisterLoadCallbacks(AddressableSceneHandler sceneAddressableObject, Action<string> loadComplete) {
            sceneAddressableObject.streamHandlerCompleted = loadComplete;
        }

        private void RegisterUnloadCallbacks(AddressableSceneHandler sceneAddressableObject, Action<string> unloadComplete) {
            sceneAddressableObject.streamHandlerCompleted = unloadComplete;
        }

        private void LoadSceneComplete(string scenePath, AddressableSceneHandler loadedSceneObject, Action<string> loadCompleteCallback) {
            loadCompleteCallback?.Invoke(scenePath);

            Debug.Log(loadedSceneObject + "loaded");
        }

        private void UnloadSceneComplete(string scenePath, AddressableSceneHandler unloadedSceneObject, Action<string> unloadCompleteCallback) {
            unloadCompleteCallback?.Invoke(scenePath);

            Debug.Log(unloadedSceneObject + " unloaded");
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void InitService() {
            ServiceLocator.Register<LevelStreamer>(new ());
        }
    }
}