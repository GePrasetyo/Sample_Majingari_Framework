using Majingari.Toolkit;
using Majingari.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class SampleUITListener : MonoBehaviour {
    public SampleUITModel sample;
    public string aaa;
    [MinMaxRange(1f, 40f)] public RangedFloat testFloat;
    [ReadOnly] public string lala = "aaaaaaa";
    [ReadOnly] public int score = 3;

    void OnEnable() {
        sample.uiDocument.rootVisualElement.Q<Button>(sample.testButton).clicked += () => { Lala(sample.testButton); };
    }

    private void Lala(string nameBtn) {
        Debug.LogError($"aaaaa {nameBtn}");
    }
}
