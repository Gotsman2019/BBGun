using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitCount : MonoBehaviour
{

    public Transform StartPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
        {

        if (collision.gameObject.tag == "HitBox")
            {

                Debug.Log("ATARI");
               
            }
        Debug.Log(collision.gameObject.tag);
        
     }
    }

