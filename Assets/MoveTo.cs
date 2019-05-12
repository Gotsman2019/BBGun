using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MoveTo : MonoBehaviour
{

    public Transform FirstPoint;

    void Start()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = FirstPoint.position;
    }
}
