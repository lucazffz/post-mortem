using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(DropDown))]
public class DropDownEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DropDown script = (DropDown)target;

        GUIContent arrayLabel = new GUIContent("MyArray");
        script.arrayIdx = EditorGUILayout.Popup(arrayLabel, script.arrayIdx, script.MyArray);


    }
}
