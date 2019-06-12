using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanIdou : MonoBehaviour
{

    public int tairyoku;
    public Transform FirstPoint;
    public Transform StartPoint;
    public Transform NextPoint;
    public Transform Next2Point;

    // Start is called before the first frame update

    private Animation Anime;


    void OnCollisionEnter(Collision collision)
    {
        if (tairyoku > 0)
        {
            if (collision.gameObject.tag == "tama")
            {

                tairyoku -= 30;

                {


                    backAI();

                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (tairyoku > 0)
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
        }
        if (other.gameObject.tag == "route4")
        {
            tairyoku = 80;
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = FirstPoint.position;//No1Point
            this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();
            this.GetComponent<TacticalAI.TargetScript>().SetMine();
            deathNo = 0;


        }

    }
    private int deathNo;
    void Start()
    {
        Anime = GetComponent<Animation>();
       
    }



    private void LateUpdate()
    {

        if (tairyoku <= 0)

        {


            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = StartPoint.position;//startPoint Restart
            this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();
            this.GetComponent<TacticalAI.TargetScript>().RemoveMine();

        }
    }
    public int GetTairyoku()
    {
        return tairyoku;
    }
    public void backAI()
    {
        if (tairyoku <= 0)
        {
            Debug.Log(transform.name + tairyoku + "CanIdou");

            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = StartPoint.position;//startPoint Restart
            this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();
            this.GetComponent<TacticalAI.TargetScript>().RemoveMine();

        }
    }
}