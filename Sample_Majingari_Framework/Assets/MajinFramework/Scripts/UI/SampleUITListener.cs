using Majingari.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class SampleUITListener : MonoBehaviour {
    public SampleUITModel sample;
    public string aaa;

    void OnEnable() {
        sample.uiDocument.rootVisualElement.Q<Button>(sample.testButton).clicked += () => { Lala(sample.testButton); };
    }

    private void Lala(string nameBtn) {
        Debug.LogError($"aaaaa {nameBtn}");
    }
}
