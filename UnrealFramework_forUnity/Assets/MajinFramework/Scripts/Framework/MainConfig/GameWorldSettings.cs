using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using Majingari.Framework.World;

using Object = UnityEngine.Object;

namespace Majingari.Framework
{
    public sealed class GameWorldSettings : ScriptableObject
    {
        [SerializeField] private MonoScript classGameInstance;
        [SerializeField] private WorldConfig worldConfigObject;

        [RuntimeInitializeOnLoadMethod]
        private static void WorldBuilderStart()
        {
            var objs = Resources.FindObjectsOfTypeAll<GameWorldSettings>();

            if (objs.Length > 0) {
                var obj = objs[0];

                obj.worldConfigObject.SetupMapConfigList();

                if(obj.classGameInstance == null)
                    Debug.LogError("You don't have Game Instance, please attach Game Instance first");

                var gameInstance = Activator.CreateInstance(obj.classGameInstance.GetClass()) as GameInstance;
                ServiceLocator.Register<GameInstance>(gameInstance);
            }
            else {
                Debug.LogError("You don't have world settings, please create the world setting first");
            }
        }

        private void OnValidate() {
            if (classGameInstance.GetClass().BaseType != typeof(GameInstance)) {
                Debug.LogError("This Is Not Game Instance, please attach game instance");
                classGameInstance = null;
            }
        }
    }
}
