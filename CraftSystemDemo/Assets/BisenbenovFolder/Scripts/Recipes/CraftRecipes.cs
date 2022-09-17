using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftRecipes : MonoBehaviour
{
    public static CraftRecipes instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of CraftRecipes found!");
            return;
        }

        instance = this;
    }

    [HideInInspector] public List<GameObject> objectsToCraft;

    public void ClearListOfObjects()
    {
        objectsToCraft.Clear();
    }
}











