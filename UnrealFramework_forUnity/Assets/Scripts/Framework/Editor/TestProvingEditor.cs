using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestProving))]
public class TestProvingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var theClass = (TestProving)target;

        if (GUILayout.Button("Validate"))
        {
            theClass.ValidateThings();
        }        
    }
}
