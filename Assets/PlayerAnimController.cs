using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
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
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");


           


        if (Input.GetKey("w")|| vertical > 0)
        {

                anim.SetBool("StandAim", true);
                i += 1;

            if (i > 1)
            {
                anim.SetBool("StandToFrontAim", true);
               
            }
        }

       if (Input.GetKeyUp("w")|| vertical <= 0 && vertical > -0.05f)
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
        if (Input.GetKey("s")|| vertical < 0)
        {

            anim.SetBool("StandAim", true);
            i += 1;

            if (i > 1)
            {
                anim.SetBool("StandToBackAim", true);

            }
        }

        if (Input.GetKeyUp("s") || vertical > 0 && vertical < 0.05f)
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



        if (Input.GetKeyDown("a")|| horizontal < 0)
            {
            anim.SetBool("StandAim", false);
            anim.SetBool("LeftWalk", true);
            }

        if (Input.GetKeyUp("a") || horizontal > 0 && horizontal < 0.05f )
           {
                anim.SetBool("LeftWalk", false);

            }

           
        if (Input.GetKeyDown("d") || horizontal > 0)
            {
            anim.SetBool("StandAim", false);
            anim.SetBool("RightWalk", true);
            }

        if (Input.GetKeyUp("d") ||horizontal < 0 && horizontal > -0.05f)
           {
                anim.SetBool("RightWalk", false);
            }
       

          anim.SetBool("StandAim", true);

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


