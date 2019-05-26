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
       
        if (Input.GetKey("w"))
        {

                anim.SetBool("StandAim", true);
                i += 1;

            if (i > 1)
            {
                anim.SetBool("StandToFrontAim", true);
            }
        }

       if (Input.GetKeyUp("w"))
        {
            anim.SetBool("StandToFrontAim", false);
            anim.SetBool("StandAim", false);
            i = 0;
        }
        if (Input.GetKey("s"))
        {

            anim.SetBool("StandAim", true);
            i += 1;

            if (i > 1)
            {
                anim.SetBool("StandToBackAim", true);
            }
        }

        if (Input.GetKeyUp("s"))
        {
            anim.SetBool("StandToBackAim", false);
            anim.SetBool("StandAim", false);
        }



        if (Input.GetKey("a"))
            {

                anim.SetBool("LeftWalk", true);
            }

            else
            {
                anim.SetBool("LeftWalk", false);
            }

            if (Input.GetKey("d"))
            {

                anim.SetBool("RightWalk", true);
            }

            else
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


