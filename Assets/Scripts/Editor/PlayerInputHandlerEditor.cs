using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerInputHandler))]
[CanEditMultipleObjects]
public class PlayerInputHandlerEditor : Editor {

	private readonly string[] controlOptions = new string[2] { "Keyboard", "Controller" };
	private readonly string[] playerNumOptions = new string[2] { "1", "2" };

	public override void OnInspectorGUI() {
		PlayerInputHandler script = (PlayerInputHandler)target;

		// Player Number Style
		GUIStyle centeredLabel = new GUIStyle(GUI.skin.label);
		centeredLabel.alignment = TextAnchor.MiddleCenter;
		centeredLabel.fontStyle = FontStyle.BoldAndItalic;

		// Player Number Label
		EditorGUILayout.LabelField(new GUIContent(
			controlOptions[script.UseController ? 1 : 0] + " Number",
			"The \"number\" of the controller this player uses. " +
			"Represents which controller or keyboard controls to use."), centeredLabel);

		// Control Method Select
		EditorGUILayout.BeginHorizontal();
		bool previousController = script.UseController;
		Undo.RecordObject(script, "Changed Control Method");
		script.UseController = GUILayout.SelectionGrid(script.UseController ? 1 : 0,
			controlOptions, 2) == 1 ? true : false;
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();

		if(!script.UseController) {
			GUI.enabled = false;	
		}
		// Player Select
		EditorGUILayout.BeginHorizontal();
		Undo.RecordObject(script, "Changed Control Number");
		script.PlayerIndex = GUILayout.SelectionGrid(script.PlayerIndex, playerNumOptions, 2);
		EditorGUILayout.EndHorizontal();

		GUI.enabled = true;
	}
}
