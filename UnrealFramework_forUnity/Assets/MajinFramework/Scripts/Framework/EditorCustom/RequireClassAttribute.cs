///Source : https://www.patrykgalach.com/2020/01/27/assigning-interface-in-unity-inspector/

using UnityEngine;

/// <summary>
/// Attribute that require implementation of the provided interface.
/// </summary>
public class RequireClassAttribute : PropertyAttribute {
    
    public System.Type requiredType { get; private set; }

    /// <summary>
    /// Requiring implementation of the <see cref="T:RequireInterfaceAttribute"/> interface.
    /// </summary>
    /// <param name="type">Interface type.</param>
    public RequireClassAttribute(System.Type type) {
        this.requiredType = type;
    }
}

