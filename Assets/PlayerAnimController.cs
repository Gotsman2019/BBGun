using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            anim.SetBool("StandAim", true);

        }
        else
        {
            anim.SetBool("StandAim", false);
        }

        if (Input.GetKey("w"))
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
      
        if (Input.GetKey("s"))
        {

             anim.SetBool("BackWalk", true);
        }
     
        else
        {
            anim.SetBool("BackWalk", false);
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
    }
}
