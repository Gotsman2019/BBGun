using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChange : MonoBehaviour
{
   public GameObject Bazooka;
   public GameObject M4;
   private Transform transformBaz;
   private Transform transformM4;
   private bool isChangeButtonDown ;
    private bool change = false;
    private int i = -1;
   
     public void GetMyChangeActiveButtonDown()
    {
        if (!change)
        {
            this.isChangeButtonDown = true;
            i = -i;
        }
        change = true;
    }
    public void GetMyChangeActiveUp()
    {
        this.isChangeButtonDown =true ;
        i = -1;

    }

    // Start is called before the first frame update
    void Start()
    {

        transformM4 = transform.Find("M4MB");
        transformBaz = transform.Find("Bazooka");
    }

    // Update is called once per frame
   
     void Update()
    {
       
            if (Input.GetKey("z")  || isChangeButtonDown && i == 1)
            {
               transformM4 = transform.Find("M4MB");
               transformBaz = transform.Find("Bazooka");
               M4.transform.gameObject.SetActive(false);
               Bazooka.transform.gameObject.SetActive(true);
               change = false;
                
               

            }

            if (Input.GetKey("x")  || isChangeButtonDown && i == -1 )

            {
                transformM4 = transform.Find("M4MB");
                transformBaz = transform.Find("Bazooka");
                M4.transform.gameObject.SetActive(true);
                Bazooka.transform.gameObject.SetActive(false);
               change = false;

            }
        
   }
}
