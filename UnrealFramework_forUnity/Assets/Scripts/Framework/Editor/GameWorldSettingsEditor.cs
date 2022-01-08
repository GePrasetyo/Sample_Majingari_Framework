using UnityEngine;
using UnityEditor;

namespace Majingari.Framework
{
    [CustomEditor(typeof(GameWorldSettings))]
    public class GameWorldSettingsEditor : Editor
    {
        private GameWorldSettings _target;

        [MenuItem("Window/Game Word Settings")]
        public static void Getter()
        {
            /* 
            ** You would naturally get the existing Settings rather 
            ** than create a new one. E.g. using 
            ** Resources.FindObjectsOfTypeAll or
            ** a manager that maintains a reference
            */

            Selection.activeObject = ScriptableObject.CreateInstance<GameWorldSettings>();
        }
        void OnEnable()
        {
            _target = (GameWorldSettings)target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();


            //_target.MyGameInstance = EditorGUILayout.PropertyField()
            //_target.settingsValue = EditorGUILayout.IntField("Setting 1", _target.settingsValue);

            //EditorGUILayout.PropertyField(_gameInstanceProp, new GUIContent("My Game Instance"));
            //serializedObject.ApplyModifiedProperties();
        }

    }

}