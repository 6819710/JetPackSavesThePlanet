using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(dropsLootOnDestruction))]
[CanEditMultipleObjects]
public class dropsLootOnDestructionEditor : Editor {

	SerializedProperty lootTable;

	void OnEnable()
	{
		lootTable = serializedObject.FindProperty("lootTable");
	}
	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.PropertyField(lootTable);
		serializedObject.ApplyModifiedProperties();
	}
}
