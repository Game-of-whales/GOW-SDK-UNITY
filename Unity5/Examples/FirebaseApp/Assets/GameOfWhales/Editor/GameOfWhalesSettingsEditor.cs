using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameOfWhalesSettings))]
public class GameOfWhalesSettingsEditor : UnityEditor.Editor {

	
    private GameOfWhalesSettings _settings;

    public override void OnInspectorGUI()
    {
        _settings = (GameOfWhalesSettings)target;

        if (_settings == null)
            return;

        _settings.gameID = EditorGUILayout.TextField("Game ID", _settings.gameID);
        _settings.androidProjectID = EditorGUILayout.TextField("Android Project ID", _settings.androidProjectID);
        _settings.debugLogging = EditorGUILayout.Toggle("Debug Logging", _settings.debugLogging);
        _settings.notificationsEnabled = EditorGUILayout.Toggle("Enable notifications", _settings.notificationsEnabled); 



        SerializedObject serializedSettings = new UnityEditor.SerializedObject(_settings);
        serializedSettings.ApplyModifiedProperties();
        if (GUI.changed) {
            EditorUtility.SetDirty(_settings);
        }
    }


}
