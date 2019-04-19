using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class CameraController : MonoBehaviour
    {
        
        private void Start()
        {

        }


        void Update()
        {
           Transform mytransform = this.transform;
            Vector3 localAngle = mytransform.localEulerAngles;


           
            //if (Input.GetKey("right"))
          // {
          //   transform.Rotate(new Vector3(0, 1, 0));
                


           // }
           // if (Input.GetKey("left"))
          // {

           //    transform.Rotate(new Vector3(0, -1, 0));

          // }
            if (Input.GetKey("k"))
            {//離したら水平にもどした方が良いかな
                transform.Rotate(new Vector3(0, 0, -1));

            }
            if (Input.GetKey("m"))
            {
                transform.Rotate(new Vector3(0, 0, 1));

            }

           

        }
    }
}
