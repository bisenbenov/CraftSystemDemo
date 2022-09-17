using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    // Управление игроком и инвентарной системой
    // Версия 1. 
    // Проблемы: обязательно (?) перемещение игрока, некликабельные кнопки

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
       if (target != null)
       {
           agent.SetDestination(target.position);
       }
    }

    //public void MoveToPoint(Vector3 point)
    //{
    //    agent.SetDestination(point);
    //}

    public void FollowTarget(InteractableForScene newTarget)
    {
        //agent.stoppingDistance = newTarget.radius * .8f;
        agent.stoppingDistance = 0f;
        agent.updateRotation = false;
        
        target = newTarget.interactionTransform;
    }   

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }

}
