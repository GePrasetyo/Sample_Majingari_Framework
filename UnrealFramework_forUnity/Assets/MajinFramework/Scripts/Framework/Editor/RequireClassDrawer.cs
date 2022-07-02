///Source : https://www.patrykgalach.com/2020/01/27/assigning-interface-in-unity-inspector/

using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;
/// <summary>
/// Drawer for the RequireInterface attribute.
/// </summary>
[CustomPropertyDrawer(typeof(RequireClassAttribute))]
public class RequireClassDrawer : PropertyDrawer {
    /// <summary>
    /// Overrides GUI drawing for the attribute.
    /// </summary>
    /// <param name="position">Position.</param>
    /// <param name="property">Property.</param>
    /// <param name="label">Label.</param>

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

        // Check if this is reference type property >> ObjectReference : Is a reference to an object that derives from UnityEngine.Object.
        if (property.propertyType == SerializedPropertyType.ObjectReference) {
            var requiredAttribute = this.attribute as RequireClassAttribute;

            // Begin drawing property field.
            EditorGUI.BeginProperty(position, label, property);

            // Draw property field.
            var reference = EditorGUI.ObjectField(position, label, property.objectReferenceValue, requiredAttribute.requiredType, false);

            if(reference is null) {
                var obj = EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(Object), false);

                if (obj is GameObject gO)
                    reference = gO.GetComponent(requiredAttribute.requiredType);
            }

            property.objectReferenceValue = reference;

            // Finish drawing property field.
            EditorGUI.EndProperty();
        }
        //else {
        //    // If field is not reference, show error message.
        //    // Save previous color and change GUI to red.
        //    var previousColor = GUI.color;
        //    GUI.color = Color.red;

        //    // Display label with error message.
        //    EditorGUI.LabelField(position, label, new GUIContent("Property is not a reference type"));

        //    // Revert color change.
        //    GUI.color = previousColor;
        //}
    }
}
