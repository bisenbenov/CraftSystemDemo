using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Databases/Recipes", fileName = "Recipes")]
public class RecipesDataBase : ScriptableObject
{
    [SerializeField, HideInInspector] private List<RecipeData> recipesList;

    [SerializeField] private RecipeData currentRecipe = new RecipeData();

    private int currentIndex = 0;

    [HideInInspector] public int recipesCount;

    public void AddElement()
    {
        if (recipesList == null)
            recipesList = new List<RecipeData>();

        currentRecipe = new RecipeData();
        recipesList.Add(currentRecipe);
        currentIndex = recipesList.Count - 1;

        recipesCount++;
    }

    public RecipeData GetNext()
    {
        if (currentIndex < recipesList.Count - 1)
            currentIndex++;
        currentRecipe = this[currentIndex];
        return currentRecipe;
    }

    public RecipeData GetPrev()
    {
        if (currentIndex > 0)
            currentIndex--;
        currentRecipe = this[currentIndex];
        return currentRecipe;
    }

    public void ClearDatabase()
    {
        recipesList.Clear();
        recipesList.Add(new RecipeData());
        currentRecipe = recipesList[0];
        currentIndex = 0;

        recipesCount = 0;
    }

    public RecipeData GetRandomElement()
    {
        int random = Random.Range(0, recipesList.Count);
        return recipesList[random];
    }

    public void RemoveCurrentElement()
    {
        if (currentIndex > 0)
        {
            currentRecipe = recipesList[--currentIndex];
            recipesList.RemoveAt(++currentIndex);

            recipesCount--;
        }
        else
        {
            recipesList.Clear();
            currentRecipe = null;
        }
    }

    public RecipeData this[int index]
    {
        get
        {
            if (recipesList != null && index >= 0 && index < recipesList.Count)
                return recipesList[index];
            return null;
        }

        set
        {
            if (recipesList == null)
                recipesList = new List<RecipeData>();

            if (index >= 0 && index < recipesList.Count & value != null)
                recipesList[index] = value;

            else Debug.LogError("Out of array bounds, or entered value = null!");
        }
    }

    [System.Serializable]
    public class RecipeData
    {
        //[Tooltip("Number of required items")]
        //[SerializeField] private int numberOfItems;
        //public int NumberOfItems
        //{
        //    get { return numberOfItems; }
        //    protected set { }
        //}

        [Tooltip("Recipe name")]
        [SerializeField] private string recipeName;
        public string RecipeName
        {
            get { return recipeName; }
            protected set { }
        }

        [Tooltip("Type of the required item ('Wood', 'Stone', etc...)")]
        [SerializeField] private string itemType;
        public string ItemType
        {
            get { return itemType; }
            protected set { }
        }

        [Tooltip("Label of the first required item ('Already been processed')")]
        [SerializeField] private string firstItemLabel;
        public string FirstItemLabel
        {
            get { return firstItemLabel; }
            protected set { }
        }

        [Tooltip("Label of the second required item ('Already been processed')")]
        [SerializeField] private string secondItemLabel;
        public string SecondItemLabel
        {
            get { return secondItemLabel; }
            protected set { }
        }
    }
}
