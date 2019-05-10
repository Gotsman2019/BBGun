using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tairyoku : MonoBehaviour
{
    public int tairyoku ;
    public Transform StartPoint;
    public Transform NextPoint;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "tama")
        {

            tairyoku -= 50;

            if (tairyoku <= 0)
            {
                UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                agent.destination = StartPoint.position;

            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (tairyoku > 0)
        {
            if (other.gameObject.tag == "route")
            {
                UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                agent.destination = NextPoint.position;
            }

        }
    }

    void Start()
    {

    }

    // Update is called once per frame


}

