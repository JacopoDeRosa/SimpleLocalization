using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(LocalizedVariable))]
public class LocalizedVariableField : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        int languages = Enum.GetNames(typeof(Languages)).Length;

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int indent = EditorGUI.indentLevel;

        EditorGUI.indentLevel = 0;

        SerializedProperty localizations = property.FindPropertyRelative("_localizations");

        EditorGUI.EndProperty();
    }
}
