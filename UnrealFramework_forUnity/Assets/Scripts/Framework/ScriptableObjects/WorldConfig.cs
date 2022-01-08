using UnityEngine;
using UnityEditor;

namespace Majingari.Framework.World
{
    [CreateAssetMenu(fileName = "Default World Config", menuName = "Config Object/World Config")]
    public class WorldConfig : ScriptableObject
    {
        [SerializeField] private SceneAsset _map;        
        [SerializeField] private GameModeManager _gameMode;
    }
}
