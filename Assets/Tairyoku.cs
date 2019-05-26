using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tairyoku : MonoBehaviour
{
    public Transform LeftArm;
    public Transform RigthtArm;

    public int tairyoku;
    public Transform FirstPoint;
    public Transform StartPoint;
    public Transform NextPoint;
    public Transform Next2Point;
   
    // Start is called before the first frame update

   private Animation Anime;


    void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.tag == "tama")
        {

            tairyoku -= 50;
            Debug.Log("BigMan" + tairyoku);
            if (tairyoku <= 0)
            {
                UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                agent.destination = StartPoint.position;
               
                 RigthtArm.rotation = Quaternion.Euler(100, RigthtArm.transform.localRotation.y, RigthtArm.transform.localRotation.z);

            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (tairyoku > 0)
        {
            if (other.gameObject.tag == "route")
            {

                Debug.Log(tairyoku);
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

        }

    }

    void Start()
    {
        Anime = GetComponent<Animation>();

    }

    private void LateUpdate()
    {
        if (tairyoku <= 0)
        {
            RigthtArm.rotation = Quaternion.Euler(80, -50, RigthtArm.rotation.z);
            LeftArm.rotation = Quaternion.Euler(-50, 50, LeftArm.rotation.z);
        }
    }

}
