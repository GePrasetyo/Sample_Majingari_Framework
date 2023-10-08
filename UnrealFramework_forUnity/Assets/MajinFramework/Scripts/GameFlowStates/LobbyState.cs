using Majingari.Network;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Majingari.FSM {
    public class LobbyState : LevelState {
        [SerializeField] private ConnectionHandler connectionPrefab;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            base.OnStateEnter(animator, stateInfo, layerIndex);
        }

        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            base.OnSceneLoaded(scene, mode);

            if(ServiceLocator.Resolve<ConnectionHandler>() != null) {
                return;
            }

            var handler = Instantiate(connectionPrefab);
            handler.name = "[Service] Connection Handler";
            DontDestroyOnLoad(handler);
            ServiceLocator.Register<ConnectionHandler>(handler);
        }
    }
}