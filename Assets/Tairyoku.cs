using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tairyoku : MonoBehaviour
{
    public int tairyoku = 100;
    public Transform StartPoint;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(tairyoku);
        if (collision.gameObject.tag == "tama")
        {

            tairyoku -= 50;
            Debug.Log("ATARI" + tairyoku);
            if (tairyoku <= 0)
            {
                UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                agent.destination = StartPoint.position;

            }
        }


    }
    void Start()
    {

    }

    // Update is called once per frame


}

