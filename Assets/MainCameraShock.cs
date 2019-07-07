using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraShock: MonoBehaviour
{
    public Transform RArmHandPos2;
    private GameObject RArmHand;

    private float CameraChangeY = 0.1f;
    private float CameraChangeZ = 0.1f;
    private bool isShockButtonDown = true;

    public void ShockSubcamera()
    {
        CameraChangeY = -CameraChangeY;
        CameraChangeZ = -CameraChangeZ;

    }


    public void MainCameraPosition()
    {

        Vector3 Pos = RArmHandPos2.transform.localPosition;
        Pos.x = Pos.x + 0;
        Pos.y =Pos.y + CameraChangeY;
        Pos.z =Pos.z + CameraChangeZ;
       
        RArmHandPos2.transform.localPosition = Pos;
             
    }
    public void GetSubShockButtonDown()
    {

        this.isShockButtonDown = false;
    }
    public void GetSubShockButtonUp()
    {
        this.isShockButtonDown = true;
    }

    public void ShockMain()
    {

        ShockSubcamera();
        MainCameraPosition();
    }

    // Start is called before the first frame update
    void Start()
    {

      //  RArmHand = GameObject.Find("RArmHand");

    }// Update is called once per frame
    void Update()
    {
       
        if (!isShockButtonDown)
        {
            ShockMain();
        }

    }
}
