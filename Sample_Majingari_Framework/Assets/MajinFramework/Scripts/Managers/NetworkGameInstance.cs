using Majingari.Network;
using UnityEngine;

namespace Majingari.Framework {
    public class NetworkGameInstance : GameInstance {
        protected override void Start() {
            base.Start();
        }

        protected override void Tick() {
            base.Tick();


            //if (Input.GetKey(KeyCode.LeftShift)){
            //    if (Input.GetKeyDown(KeyCode.H)) {
            //        ServiceLocator.Resolve<ConnectionLANSupport>()?.StartLocalSesssionHost();
            //        return;
            //    }

            //    if (Input.GetKeyDown(KeyCode.S)) {
            //        ServiceLocator.Resolve<ConnectionLANSupport>()?.AutoJoinLocalSession();
            //        return;
            //    }
            //}

            //if (Input.GetKeyDown(KeyCode.H)) {
            //    ServiceLocator.Resolve<UNetcodeConnectionHandler>()?.StartGameSessionHost();
            //    return;
            //}

            //if (Input.GetKeyDown(KeyCode.J)) {
            //    ServiceLocator.Resolve<UNetcodeConnectionHandler>()?.StartGameSesssionClient();
            //    return;
            //}
        }
    }
}