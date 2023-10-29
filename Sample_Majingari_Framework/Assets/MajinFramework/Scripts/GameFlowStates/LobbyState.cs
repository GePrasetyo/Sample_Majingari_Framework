using Majingari.Network;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Majingari.FSM {
    public class LobbyState : LevelState {
        [SerializeField] private UNetcodeConnectionHandler connectionPrefab;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            base.OnStateEnter(animator, stateInfo, layerIndex);
        }

        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            base.OnSceneLoaded(scene, mode);

            if(ServiceLocator.Resolve<UNetcodeConnectionHandler>() != null) {
                return;
            }

            var handler = Instantiate(connectionPrefab);
            handler.name = "[Service] Connection Handler";
            DontDestroyOnLoad(handler.gameObject);
            ServiceLocator.Register<UNetcodeConnectionHandler>(handler);
        }
    }
}