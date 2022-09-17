using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RecipesList : MonoBehaviour
{
    #region Singleton
    public static RecipesList instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of RecipesList found!");
            return;
        }

        instance = this;

        FillConditions();
    }
    #endregion

    public List<string> resultRecipesString = new List<string>();

    public RecipesDataBase database;

    List<RecipesDataBase.RecipeData> recipeData;

    public delegate void OnConditionsCheck();
    public OnConditionsCheck recipesFillCallBack;

    public delegate void OnRecipesClear();
    public OnRecipesClear recipesClearCallBack;

    List<UniqueConditionItem> itemsTypes = new List<UniqueConditionItem>();

    List<LabelConditionType> itemsLabels = new List<LabelConditionType>();

    Dictionary<string, List<ICraftCondition>> recipesConditions = new Dictionary<string, List<ICraftCondition>>();

    Dictionary<string, UniqueConditionItem> recipesOnTypes = new Dictionary<string, UniqueConditionItem>();

    Dictionary<string, LabelConditionType> recipesOnLabels = new Dictionary<string, LabelConditionType>();

    void StoreItemsTypes()
    {
        for (int i = 0; i < database.recipesCount; i++)
        {
            recipesOnTypes.Add(database[i].RecipeName, new UniqueConditionItem(database[i].ItemType));
        }
    }

    List<string> firstLabels = new List<string>();
    List<string> secondLabels = new List<string>();

    void StoreItemsLabels()
    {
        for (int i = 0; i < database.recipesCount; i++)
        {
            recipesOnLabels.Add(database[i].RecipeName, new LabelConditionType(new string[] {
                database[i].FirstItemLabel,
                database[i].SecondItemLabel}));
        } 
        
        for (int i = 0; i < database.recipesCount; i++)
        {
            firstLabels.Add(database[i].FirstItemLabel);
            secondLabels.Add(database[i].SecondItemLabel);
        }
    }

    void FillConditions()
    {
        database.recipesCount++;

        StoreItemsTypes();
        StoreItemsLabels();

    }

    public void ClearRecipes()
    {
        resultRecipesString.Clear();
        recipesClearCallBack.Invoke();
    }

    public void CheckConditionsGiveRecipes(List<GameObject> objectsToCraft) 
    {
        if (objectsToCraft.Count > 1) // for tool
        {
            if (resultRecipesString.Count != 0)
            {
                ClearRecipes();
            }

            GiveRecipesForSeveralObjects(objectsForTool: objectsToCraft);
        }

        else // single object
        {
            Dictionary<string, List<ICraftCondition>>.ValueCollection vs = recipesConditions.Values;
            GameObject singleObjectToCraft = objectsToCraft[0];

            //TEST - works
            Dictionary<string, UniqueConditionItem>.ValueCollection rtV = recipesOnTypes.Values;
            Dictionary<string, UniqueConditionItem>.KeyCollection rtK = recipesOnTypes.Keys;

            for (var i = 0; i < rtV.Count; i++)
            {
                var conditToCheck = rtV.ElementAt(i);
                string recipeName = rtK.ElementAt(i);
                if (conditToCheck.CheckCompatibility(singleObjectToCraft) == true)
                {
                    resultRecipesString.Add(recipeName);
                }
            }
        }

        recipesFillCallBack.Invoke();
    }

    // several objects
    public void GiveRecipesForSeveralObjects(List<GameObject> objectsForTool)
    {
        GameObject objectInTheWindow = objectsForTool[0]; 
        GameObject comparableObject = objectsForTool[1];
    
        MatchLabelsGiveTool(objectInTheWindow, comparableObject);
    }
    
    void MatchLabelsGiveTool(GameObject alreadyAdded, GameObject newObject)
    {
        Dictionary<string, LabelConditionType>.ValueCollection ltV = recipesOnLabels.Values;
        Dictionary<string, LabelConditionType>.KeyCollection ltK = recipesOnLabels.Keys;

        string label1 = alreadyAdded.GetComponent<Label>().label;
        string label2 = newObject.GetComponent<Label>().label;

        // test -- works
        for (int i = 0; i < ltV.Count; i++)
        {
            string recipeName = ltK.ElementAt(i);
            if (label1 == database[i].FirstItemLabel && label2 == database[i].SecondItemLabel)
            {
                // for test
                Debug.Log(resultRecipesString.Count);

                resultRecipesString.Add(recipeName);
            }
        }
    }
}
