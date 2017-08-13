using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LootTable))]
public class LootTableEditor : Editor {

	void onEnable(){
	}
	
	void OnInspectorGUI() {
		EditorGUILayout.LabelField("Working");
		serializedObject.Update();
		LootTable lt;
		try {
			lt = serializedObject.targetObject as LootTable;
			if(lt!=null){
				for(int i=0;i<lt.Keys.Count;i++){
					EditorGUILayout.BeginHorizontal();
					KeyValuePair<GameObject, float> row = lt[i];
					EditorGUILayout.LabelField("#"+i,GUILayout.MaxWidth(20));
					GameObject updatedLoot = (GameObject) EditorGUILayout.ObjectField(row.Key,typeof(GameObject),true,  GUILayout.MaxWidth(100));
					float updatedChance = (float) EditorGUILayout.FloatField(row.Value,GUIStyle.none, GUILayout.MaxWidth(150));
					if (GUILayout.Button("x", GUILayout.Width(20))) {
						lt.Remove(i);
					}
					lt.SetLootAt(i,updatedLoot,updatedChance);
					EditorGUILayout.EndHorizontal();
				}
			}
		} catch(UnityException e){
			Debug.Log (e);
		}

		GUILayout.BeginHorizontal ();
		if (GUILayout.Button("+ Add loot", GUILayout.Width(100))) {
			//lt.Add(lt.Count,null,0.0f);
		}
		if (GUILayout.Button("x Clear", GUILayout.Width(100))) {
			lt = new LootTable ();
			lt.Clear ();
		}

		if (GUILayout.Button("Save", GUILayout.Width(100))) {
		}

		EditorGUILayout.EndHorizontal();
		serializedObject.ApplyModifiedProperties();

		serializedObject.ApplyModifiedProperties();
	}

}