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
	}

	public override void OnInspectorGUI()
	{
		dropsLootOnDestruction handler = (dropsLootOnDestruction) target;
		LootTable lt = handler.loots; 
		try {
			for(int i=0;i<lt.Keys.Count;i++){
				EditorGUILayout.BeginHorizontal();
				KeyValuePair<GameObject, float> row = lt[i];
				GameObject updatedLoot = (GameObject) EditorGUILayout.ObjectField("Loot",row.Key,typeof(GameObject),true, new GUILayoutOption[0]);
				float updatedChance = (float) EditorGUILayout.FloatField("Chance",row.Value,GUIStyle.none, new GUILayoutOption[0]);
				lt.SetLootAt(i,updatedLoot,updatedChance);
				EditorGUILayout.EndHorizontal();
			}
		} catch(UnityException e){
			Debug.Log (e);
		}

		GUILayout.BeginHorizontal ();
		if (GUILayout.Button("+ Add loot", GUILayout.Width(100))) {
			lt.Add(null,1.0f);
		}
		if (GUILayout.Button("x Clear", GUILayout.Width(100))) {
			lt.Clear ();
		}
		EditorGUILayout.EndHorizontal();
		serializedObject.ApplyModifiedProperties();
	}
}
