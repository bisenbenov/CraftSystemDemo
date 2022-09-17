using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR.InteractionSystem;

public class GrabObjectController : Throwable
{
    CraftRecipes craftRecipes;

    public delegate void OnItemAddInRecipesCheck();
    public static OnItemAddInRecipesCheck recipesCheckCallBack;

    void Start()
    {
        craftRecipes = CraftRecipes.instance;
    }
    
    protected override void OnAttachedToHand(Hand hand) 
    { 
        craftRecipes.objectsToCraft.Add(gameObject);
    
        if (recipesCheckCallBack != null)
        {
            recipesCheckCallBack.Invoke();
        }
    }
}

