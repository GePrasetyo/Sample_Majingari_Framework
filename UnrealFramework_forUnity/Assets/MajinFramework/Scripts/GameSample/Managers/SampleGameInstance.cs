using UnityEngine;

namespace Majingari.Framework {
    public class SampleGameInstance : GameInstance {
        public SampleGameInstance() : base() {
            
        }

        protected override void Tick() {
            base.Tick();

            //if (Input.GetKeyDown(KeyCode.A)) {
            //    ServiceLocator.Resolve<TickSignal>().RegisterObject(AAAAAAAAAAA);
            //}

            //if (Input.GetKeyDown(KeyCode.B)) {
            //    ServiceLocator.Resolve<TickSignal>().UnRegisterObject(AAAAAAAAAAA);
            //}
        }
    }
}