using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private bool arrowcharge;
    private Animator ArrowAnime;
   

      public void ArrowChargeButtonDown()
    {
        arrowcharge = true;
    }
    public void ArrowChargeButtonUp()
    {
        arrowcharge = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        ArrowAnime = GetComponent<Animator>();
        arrowcharge = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowcharge)
        {
            ArrowAnime.SetBool("shooting",true);
        }
        if (!arrowcharge)
        {
            ArrowAnime.SetBool("shooting",false);
        }
    }
}
