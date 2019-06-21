using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private int i = 0;
    private Animator anim;
   
    // Start is called before the first frame update
    void Start()
    {
    anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float xdata = Input.GetAxis("Mouse X");
        float ydata = Input.GetAxis("Mouse Y");


        if (Input.GetKey("w"))
        {

                anim.SetBool("StandAim", true);
                i += 1;

            if (i > 1)
            {
                anim.SetBool("StandToFrontAim", true);
               
            }
        }

       if (Input.GetKeyUp("w") )
        {
            anim.SetBool("StandToFrontAim", false);
            anim.SetBool("StandAim", false);
            i = 0;
            anim.SetBool("StandToBackAim", false);
            anim.SetBool("StandAim", false);
            anim.SetBool("StandAim", true);
            i += 1;

            if (i > 1)
            {
                anim.SetBool("StandToFrontAim", true);
            }
        }
        if (Input.GetKey("s") )
        {

            anim.SetBool("StandAim", true);
            i += 1;

            if (i > 1)
            {
                anim.SetBool("StandToBackAim", true);

            }
        }

        if (Input.GetKeyUp("s") )
        {
            anim.SetBool("StandToBackAim", false);
            anim.SetBool("StandAim", false);
            anim.SetBool("StandAim", true);
            i += 1;

            if (i > 1)
            {
                anim.SetBool("StandToFrontAim", true);
            }
        }



        if (Input.GetKeyDown("a") )
            {
            anim.SetBool("StandAim", false);
            anim.SetBool("LeftWalk", true);
            }

        if (Input.GetKeyUp("a") || xdata <= 0 )
           {
                anim.SetBool("LeftWalk", false);

            }

           
        if (Input.GetKey("d") || xdata < 1.0f && xdata > 0)
            {
            anim.SetBool("StandAim", false);
            anim.SetBool("RightWalk", true);
            }

        if (Input.GetKey("d") || xdata > -1.0f && xdata < 0)
           {
                anim.SetBool("RightWalk", false);
            }

        if (Input.GetKey("e"))
        {

            anim.SetBool("StandAim", true);
            i += 1;

            if (i > 1)
            {
                anim.SetBool("StandAim", true);
            }
        }

        if (Input.GetKeyUp("e"))
        {
            anim.SetBool("StandAim", false);
            anim.SetBool("Standing", true);
          
            i = 0;
        }
       
    }



}


