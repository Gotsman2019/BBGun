using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChange : MonoBehaviour
{
   public GameObject Bazooka;
   public GameObject M4;
   private Transform transformBaz;
   private Transform transformM4;


    // Start is called before the first frame update
    void Start()
    {
        transformM4 = transform.Find("M4MB");
        transformBaz = transform.Find("Bazooka");
    }

    // Update is called once per frame
   
     void Update()
    {
        if (Input.GetKey("z"))
        {
            M4.transform.gameObject.SetActive(false);
            Bazooka.transform.gameObject.SetActive(true);
        }
            
    }
}
