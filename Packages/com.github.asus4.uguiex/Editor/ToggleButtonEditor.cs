using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

namespace Unity.UI.Ex.Editor
{
    [CustomEditor(typeof(ToggleButton), true)]
    [CanEditMultipleObjects]
    public class ToggleButtonEditor : ButtonEditor
    {
        SerializedProperty _isOn;

        protected override void OnEnable()
        {
            base.OnEnable();
            _isOn = serializedObject.FindProperty("_isOn");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_isOn);
            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();
        }
    }
}
