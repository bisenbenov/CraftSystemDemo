using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueConditionItem : ICraftCondition
{
    GameObject objectToCraft;

    private string type;

    public UniqueConditionItem(string type)
    {
        this.type = type;
    }

    public bool CheckCompatibility(GameObject objectToCraft)
    {
        this.objectToCraft = objectToCraft;

        if (objectToCraft.CompareTag(type))
        {
            return true;
        }

        return false;
    }
}
