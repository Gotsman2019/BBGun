using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    private bool soundcheck;
    public GameObject plyr;
    public GameObject ThisAi;

    public Tairyoku2 tairyoku2;
    public AIDown AIDown;
    public TacticalAI.AnimationScript animationScript;

    private Animation Anime;
    private Animator animator;
    private int i;
    private bool deathcheckcount;
    private Transform child;
    private GameObject Doll;



    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
    }



    void OnCollisionEnter(Collision collision)
    {
        if (tairyoku > 0)
        {
            if (collision.gameObject.tag == "tama")
            {

                tairyoku -= 50;

                {
                   
                    backAI2();
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



        deathNo = 0;
        audioSource = GetComponent<AudioSource>();
        soundcheck = false;
        deathcheckcount = false;
        plyr = GameObject.Find("Player");
        tairyoku2 = plyr.GetComponent<Tairyoku2>();
        AIDown = ThisAi.GetComponent<AIDown>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
       
}



    private void LateUpdate()
    {
        if (tairyoku <= 0)

        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
           //agent.Stop();//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            if (!soundcheck )
            {

              //audioSource.PlayOneShot(KillSounds);
                soundcheck = true;


            }

           
                RigthtArm.localRotation = Quaternion.Euler(80, -50, RigthtArm.localRotation.z);
                LeftArm.localRotation = Quaternion.Euler(-50, 50, LeftArm.localRotation.z);
                RArmUPER2.localRotation = Quaternion.Euler(0, RArmUPER2.localRotation.y, 0);
               
                agent.destination = StartPoint.position;//startPoint Restart
            if (deathNo == 0)
            {
                if (!deathcheckcount)
                {
                    AIDown.DeathAnim();
                  // StartCoroutine("Wait");
                    deathcheckcount = true;
                }
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
        if (tairyoku <= 0)
        {
            if (!soundcheck)
            {
               audioSource.PlayOneShot(KillSounds);
                soundcheck = true;
            }
          audioSource.PlayOneShot(KillSounds);

            AIDown.DeathAnim();

            RigthtArm.localRotation = Quaternion.Euler(80, -50, RigthtArm.localRotation.z);
            LeftArm.localRotation = Quaternion.Euler(-50, 50, LeftArm.localRotation.z);
            RArmUPER2.localRotation = Quaternion.Euler(0, RArmUPER2.localRotation.y, 0);
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = StartPoint.position;//startPoint Restart
            if (deathNo == 0)
            {
               
              //  StartCoroutine("Wait");
             

                this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();
                this.GetComponent<TacticalAI.TargetScript>().RemoveMine();
                deathNo += 1;
            }
        }
    }
    public void backAI2()
    {
        if (tairyoku <= 0)
        {
            if (!soundcheck)
            {
              audioSource.PlayOneShot(KillSounds);
                soundcheck = true;
                tairyoku2.ScoreCount();
            }

           audioSource.PlayOneShot(KillSounds);

            AIDown.DeathAnim();

            //  Debug.Log(transform.name + tairyoku +"backAI");
            RigthtArm.localRotation = Quaternion.Euler(80, -50, RigthtArm.localRotation.z);
            LeftArm.localRotation = Quaternion.Euler(-50, 50, LeftArm.localRotation.z);
            RArmUPER2.localRotation = Quaternion.Euler(0, RArmUPER2.localRotation.y, 0);
           
           UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
           
           Debug.Log("AINav");

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