using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Crafting/Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    string resultRecipes;

    [System.Serializable]
    public class Recipes
    {
        public List<ICraftCondition> craftConditions;
    }

    public string GetCraftingRecipes()
    {
        return resultRecipes;
    }
}
