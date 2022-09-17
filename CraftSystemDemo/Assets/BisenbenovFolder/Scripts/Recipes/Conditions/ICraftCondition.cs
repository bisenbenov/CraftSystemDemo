using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public abstract class ICraftCondition 
//{
//    public virtual bool CheckCompatibility(GameObject objectToCraft) {
//        return true;
//    }
//}

public interface ICraftCondition
{
    public bool CheckCompatibility(GameObject objectToCraft);
}




