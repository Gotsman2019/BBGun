using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerAnimController : MonoBehaviour
{
    private int i = 0;
    private Animator anim;
    private bool isSitButtonDown = false;
    private bool isSitButtonUp = false;
    // Start is called before the first frame update
    private bool SitCheck;
    public void GetMySitButtonDown()
    {
        this.isSitButtonDown = true;
        this.isSitButtonUp = false;
        SitCheck = false;
    }
    public void GetMySitButtonUp()
    {
        this.isSitButtonUp = true;
        this.isSitButtonDown = false;
        SitCheck = false;
    }


    void Start()
    {
    anim = GetComponent<Animator>();
        SitCheck = false;
        isSitButtonDown = false;
        isSitButtonUp = true;


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
            anim.SetBool("SitAim", false);
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
            anim.SetBool("SitAim", false);
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
            anim.SetBool("SitAim", false);
            anim.SetBool("StandAim", true);
            i += 1;

            if (i > 1)
            {
                anim.SetBool("SitAim", false);
                anim.SetBool("StandToFrontAim", true);
            }
        }



        if (Input.GetKeyDown("a")|| horizontal < 0)
            {
            anim.SetBool("SitAim", false);
            anim.SetBool("StandAim", false);
            anim.SetBool("LeftWalk", true);
            }

        if (Input.GetKeyUp("a") || horizontal > 0 )//&& horizontal < 0.05f )
           {
                anim.SetBool("LeftWalk", false);
               anim.SetBool("SitAim", false);

        }

           
        if (Input.GetKeyDown("d") || horizontal > 0)
            {
            anim.SetBool("StandAim", false);
            anim.SetBool("SitAim", false);
            anim.SetBool("RightWalk", true);
            }

        if (Input.GetKeyUp("d") ||horizontal < 0 )//&& horizontal > -0.05f)
           {
            anim.SetBool("RightWalk", false);
            anim.SetBool("SitAim", false);
           }

        if (horizontal >-0.01f && horizontal < 0.01f)
        {
            anim.SetBool("LeftWalk", false);
            anim.SetBool("RightWalk", false);
            anim.SetBool("StandAim", true);
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


        if (Input.GetKeyDown("p")|| isSitButtonDown)
        {

                anim.SetBool("SitAim", true);
                SitCheck = true;



        }

        if (Input.GetKeyUp("p")|| isSitButtonUp)
        {
            if (!SitCheck)
            {

                anim.SetBool("SitAim", false);
                SitCheck = true;
            }

        }

    }



}


