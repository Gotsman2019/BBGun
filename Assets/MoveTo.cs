using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MoveTo : MonoBehaviour
{
    public Transform FirstPoint;
    public Transform StartPoint;
    public Transform NextPoint;
    public Transform Next2Point;
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "route")
        {

            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = NextPoint.position; //No2Point
        }

        if (other.gameObject.tag == "route2")
        {

            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = Next2Point.position;//No3Point

        }
        if (other.gameObject.tag == "route3")
        {
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = StartPoint.position;//startPoint Restart

        }
        if (other.gameObject.tag == "route4")
        {

            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = FirstPoint.position;//No1Point


        }

        if (other.gameObject.tag == "route4")
        {

            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = FirstPoint.position;//No1Point
            this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();
            this.GetComponent<TacticalAI.TargetScript>().SetMine();



        }
    }

       void Start()
        {
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = FirstPoint.position;
        }
    }

