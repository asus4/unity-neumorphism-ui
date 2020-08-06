using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.UI;

namespace Unity.UI.Ex.Editor
{
    [CustomEditor(typeof(LongPressButton), true)]
    [CanEditMultipleObjects]
    public class LongPressButtonEditor : ButtonEditor
    {
        SerializedProperty longPressTime;
        SerializedProperty onLongPress;

        protected override void OnEnable()
        {
            base.OnEnable();

            longPressTime = serializedObject.FindProperty("longPressTime");
            onLongPress = serializedObject.FindProperty("onLongPress");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();
            EditorGUILayout.PropertyField(longPressTime);
            EditorGUILayout.PropertyField(onLongPress);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
