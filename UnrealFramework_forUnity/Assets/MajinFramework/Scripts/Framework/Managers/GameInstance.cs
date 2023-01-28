/*
 Please derived this class in 1 level only. and there is only 1 game instance running per game. and this is Live the whole game.
 */
using UnityEngine;

namespace Majingari.Framework
{
    public class GameInstance
    {
        public GameInstance() {
            Debug.Log($"Game Instance generated : {this.GetType()}");
        }
    }
}