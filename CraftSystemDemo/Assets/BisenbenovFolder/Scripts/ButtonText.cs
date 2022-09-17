using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    RecipesList recipesFunc;
    public Text textField;

    private void Start()
    {
        recipesFunc = RecipesList.instance;
        recipesFunc.recipesFillCallBack += SetText;
        recipesFunc.recipesClearCallBack += ClearText;
    }

    public void SetText()
    {
        gameObject.GetComponent<Image>().enabled = true;

        string text = recipesFunc.resultRecipesString[0];
        textField.text = text;
    }

    public void ClearText()
    {
        textField.text = null;
    }
}
