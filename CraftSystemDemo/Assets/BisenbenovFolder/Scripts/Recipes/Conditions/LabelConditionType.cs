using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelConditionType : ICraftCondition
{
    Label label;
    GameObject objectToCraft;

    private string[] types;

    private string type;

    public LabelConditionType(string[] types)
    {
        this.types = types;
    }

    public LabelConditionType(string type)
    {
        this.type = type;
    }

    public bool CheckCompatibility(GameObject objectToCraft)
    {
        this.objectToCraft = objectToCraft;

        label = objectToCraft.GetComponent<Label>();

        foreach (var type in types)
        {
            if (label.label == type)
            {
                return true;
            }
        }

        return false;
    }
}




