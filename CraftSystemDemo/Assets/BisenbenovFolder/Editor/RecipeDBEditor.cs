using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RecipesDataBase))]
public class RecipeDBEditor : Editor
{
    private RecipesDataBase database;

    private void Awake()
    {
        database = (RecipesDataBase)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("RemoveAll"))
        {
            database.ClearDatabase();
        }

        if (GUILayout.Button("Remove"))
        {
            database.RemoveCurrentElement();
        }

        if (GUILayout.Button("Add"))
        {
            database.AddElement();
        }

        if (GUILayout.Button("<"))
        {
            database.GetPrev();
        }

        if (GUILayout.Button(">"))
        {
            database.GetNext();
        }

        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}
