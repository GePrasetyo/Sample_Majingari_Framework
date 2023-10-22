using Majingari.Network;
using UnityEngine;

namespace Majingari.Framework {
    public class NetworkGameInstance : GameInstance {
        protected override void Start() {
            base.Start();
        }

        protected override void Tick() {
            base.Tick();

            if (Input.GetKeyDown(KeyCode.H)) {
                ServiceLocator.Resolve<ConnectionLANSupport>()?.StartLocalSesssionHost();
            }

            if (Input.GetKeyDown(KeyCode.S)) {
                ServiceLocator.Resolve<ConnectionLANSupport>()?.AutoJoinLocalSession();
            }

            if (Input.GetKeyDown(KeyCode.J)) {
                ServiceLocator.Resolve<ConnectionHandler>()?.StartGameSesssionClient();
            }
        }
    }
}