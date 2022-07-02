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

        public MonoScript ClassGameInstance { get { return classGameInstance; } }
        public WorldConfig WorldConfigObject { get { return worldConfigObject; } }

        [RuntimeInitializeOnLoadMethod]
        private static void WorldBuilderStart()
        {
            new GameWorldFactory();
        }

        private void OnValidate() {
            if (classGameInstance.GetClass() != typeof(GameInstance))
                Debug.Log("This Is Not Game Instance");
        }
    }

    public sealed class GameWorldFactory {
        public GameWorldFactory() {
            
            var objs = Resources.FindObjectsOfTypeAll<GameWorldSettings>();

            if (objs.Length > 0) {
                var obj = objs[0];

                var gameInstance = Activator.CreateInstance(obj.ClassGameInstance.GetClass()) as GameInstance;
                ServiceLocator.Register<GameInstance>(gameInstance);
            }
            else {
                Debug.LogError("You don't have world settings, please create the world setting first");
            }


            var a = ServiceLocator.Resolve<GameInstance>();
        }
    }
}
