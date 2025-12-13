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

    [StringReference(typeof(StringOptionsLookUp), nameof(StringOptionsLookUp.TestLookUp))]
    public string[] selectedStrings;

    public SampleUITListener selected;

    public string tesString;

    void OnEnable() {
        sample.uiDocument.rootVisualElement.Q<Button>(sample.testButton).clicked += () => { Lala(sample.testButton); };
    }

    private void Lala(string nameBtn) {
        Debug.LogError($"aaaaa {nameBtn}");
    }

    [ContextMenu("Test String")]
    void Check() {
        //Debug.LogError($"included : {selectedStrings.Contains(tesString)}");
        Debug.LogError($"list of string : {selectedStrings}");
    }
}

public class StringOptionsLookUp {
    public static string[] TestLookUp = { "aaa", "bbb", "dadsa", "gggg" };
}