using UnityEngine;
using UnityEngine.InputSystem;

namespace Majingari {
    public class TestInput : MonoBehaviour {
        public InputActionReference input1;
        public InputActionReference input2;
        public InputActionReference input3;
        public InputActionReference input4;
        public InputActionReference input5;
        public InputActionReference input6;

        private void Start() {
            input1.action.Enable();
            input2.action.Enable();
            input3.action.Enable();
            input4.action.Enable();
            input5.action.Enable();
            input6.action.Enable();
        }

        private void Update() {
            if (input1.action.triggered) {
                DebugInput("input1");
                return;
            }

            if (input2.action.triggered) {
                DebugInput("input2");
                return;
            }

            if (input3.action.triggered) {
                DebugInput("input3");
                return;
            }

            if (input4.action.triggered) {
                DebugInput("input4");
                return;
            }

            if (input5.action.triggered) {
                DebugInput("input5");
                return;
            }

            if (input6.action.triggered) {
                DebugInput("input6");
                return;
            }
        }

        private void DebugInput(string msg) {
            Debug.LogError(msg);
        }
    }
}