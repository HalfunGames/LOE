using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentControl : MonoBehaviour
{
    public Transform trans;

    public Vector3 targetPos;

    public NavMeshAgent navAgent;

    public int speed = 5;

    public bool update = false;

    private void Start()
    {
        trans = this.GetComponent<Transform>();
        navAgent = this.GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
    }

    private void Update()
    {
        if (targetPos == Vector3.zero || targetPos == trans.position)
        {
            targetPos = navAgent.steeringTarget;
        }
        else if (update)
        {
            targetPos = navAgent.steeringTarget;
            update = false;
        }
        else
        {
            trans.LookAt(targetPos);
        }
    }

}
