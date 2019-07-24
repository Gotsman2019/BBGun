using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuzzHit : MonoBehaviour
{
    private Rigidbody Rb;
    private NavMeshAgent navMeshAgent;

    private void OnCollisionEnter(Collision other)
    {
    if (other.gameObject.tag == "tama")
        {


            StartCoroutine(Waittime());
         

        }
    }




    IEnumerator Waittime()
    {
        Rb.isKinematic = false;
        navMeshAgent.isStopped = true;
        navMeshAgent.updatePosition = false;
        //taosu

        yield return new WaitForSeconds(5f);
        //modosu
        navMeshAgent.updatePosition = true;
        Rb.isKinematic = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
