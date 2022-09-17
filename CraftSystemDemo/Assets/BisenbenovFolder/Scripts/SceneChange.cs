using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    ButtonText buttonText;

    public void ChangeScene()
    {
        var recipesFunc = RecipesList.instance;
        buttonText = gameObject.GetComponent<ButtonText>();
        //SceneManager.LoadScene(recipesFunc.resultRecipesString[0]);
        SceneManager.LoadScene(buttonText.textField.text);
    }
}
