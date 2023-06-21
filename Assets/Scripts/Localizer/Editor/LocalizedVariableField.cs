using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Codice.Client.BaseCommands;

[CustomPropertyDrawer(typeof(LocalizedVariable), true)]
public class LocalizedVariableField : PropertyDrawer
{
    private const float Offset = 25;

    private int numberOfChildren; 
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        label.text += ":";

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label, new GUIStyle(){fontSize = 13, fontStyle = FontStyle.Bold, alignment = TextAnchor.LowerLeft, normal = new GUIStyleState(){textColor = Color.white}});

        EditorGUI.indentLevel = -1;
        
        SerializedProperty localizations = property.FindPropertyRelative("_localizations");

        string[] names = Enum.GetNames(typeof(Languages));
        
        Rect rect = new Rect(position.x, position.y + Offset, position.width, 20);
        
        rect.xMin = 40;
        rect.xMax = 300;
        
        numberOfChildren = localizations.arraySize;
        
        EditorGUIUtility.labelWidth = 70;
        
        for (int i = 0; i < localizations.arraySize; i++)
        {
            EditorGUI.PropertyField(rect ,localizations.GetArrayElementAtIndex(i), new GUIContent(names[i]));
            rect.y += Offset;
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + (Offset * numberOfChildren ) + 1;
    }
}
