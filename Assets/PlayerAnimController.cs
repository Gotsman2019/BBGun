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
            if (Input.GetKey("s"))
            {
                anim.SetBool("StandToBackAim", true);
            }

            else if (Input.GetKey("w"))
            {
                anim.SetBool("StandToFrontAim", true);
            }

            else if (Input.GetKey("a"))
            {
                anim.SetBool("StandToLeftAim", true);
            }

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
        //マウスで動いかしたいのに。。。。。
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("RigthWalk", true);
            Debug.Log("左クリック");
        }
            float migi = Input.GetAxis("Horizontal");
        Debug.Log(migi);
        if (migi > 0)
        {

           anim.SetBool("RigthWalk", true);
        }


    }



}
