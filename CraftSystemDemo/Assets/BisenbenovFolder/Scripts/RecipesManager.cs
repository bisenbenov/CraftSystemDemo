using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesManager : MonoBehaviour
{
    CraftRecipes craftRecipes;
    RecipesList recipesFunc;

    void Start()
    {
        craftRecipes = CraftRecipes.instance;
        recipesFunc = RecipesList.instance;

        GrabObjectController.recipesCheckCallBack += CheckObject;
    }

    void CheckObject()
    {
        recipesFunc.CheckConditionsGiveRecipes(craftRecipes.objectsToCraft);
    }
}
