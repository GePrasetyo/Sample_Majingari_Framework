using System;
using System.Collections.Generic;
using UnityEngine;

namespace Majingari.Framework.World
{
    [Serializable]
    [CreateAssetMenu(fileName = "Default Game Mode Config", menuName = "Config Object/Game Mode Config")]
    public class GameModeManager : ScriptableObject
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private HUDManager _hudManager;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private PlayerState _playerState;
        [SerializeField] private PlayerPawn _playerPawn;
    }

}