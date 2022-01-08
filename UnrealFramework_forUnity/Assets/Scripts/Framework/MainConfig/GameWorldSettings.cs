using UnityEngine;
using System.Reflection;

namespace Majingari.Framework
{
    public class GameWorldSettings : ScriptableObject
    {
        [SerializeField]private GameInstance _myGameInstance;

        private static GameObject _gameObject = default;

        [RuntimeInitializeOnLoadMethod]
        private static void WorldBuilderStart()
        {
            var obj = new GameObject("World_Settings");
           
            obj.AddComponent<GameInstance>();
        }
    }
}
