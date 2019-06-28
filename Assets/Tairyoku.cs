using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tairyoku : MonoBehaviour
{
    public Transform LeftArm;
    public Transform RigthtArm;
    public Transform RArmUPER2;
    public int teamid;
    public int tairyoku;
    public Transform FirstPoint;
    public Transform StartPoint;
    public Transform NextPoint;
    public Transform Next2Point;
    public AudioClip KillSounds;
    private AudioSource audioSource;

    // Start is called before the first frame update

    private Animation Anime;


    void OnCollisionEnter(Collision collision)
    {
        if (tairyoku > 0)
        {
            if (collision.gameObject.tag == "tama")
            {

                tairyoku -= 50;

                {
                    backAI();
                }
            }

            if (collision.gameObject.tag == "tama2")
                tairyoku -= 30;
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
     deathNo = 0;
        audioSource = GetComponent<AudioSource>();

    }



    private void LateUpdate()
    {

        if (tairyoku <= 0)

        {
            audioSource.PlayOneShot(KillSounds);
            RigthtArm.localRotation = Quaternion.Euler(80, -50, RigthtArm.localRotation.z);
                LeftArm.localRotation = Quaternion.Euler(-50, 50, LeftArm.localRotation.z);
                RArmUPER2.localRotation = Quaternion.Euler(0, RArmUPER2.localRotation.y, 0);
                UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                agent.destination = StartPoint.position;//startPoint Restart
            if (deathNo == 0)
            {
                this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();
                this.GetComponent<TacticalAI.TargetScript>().RemoveMine();
                deathNo += 1;
            }
        }
    }
    public int GetTairyoku()
    {
        return tairyoku;
    }
    public void backAI()
    {
        audioSource.PlayOneShot(KillSounds);
        if (tairyoku <= 0)
        {

            //  Debug.Log(transform.name + tairyoku +"backAI");
            RigthtArm.localRotation = Quaternion.Euler(80, -50, RigthtArm.localRotation.z);
            LeftArm.localRotation = Quaternion.Euler(-50, 50, LeftArm.localRotation.z);
            RArmUPER2.localRotation = Quaternion.Euler(0, RArmUPER2.localRotation.y, 0);
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = StartPoint.position;//startPoint Restart
            if (deathNo == 0)
            {
                this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();
                this.GetComponent<TacticalAI.TargetScript>().RemoveMine();
                deathNo += 1;
            }
        }
    }
}