using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraTransformChange : MonoBehaviour
{

    public Transform RArmHandPos;
    private GameObject RArmHand;

    private float CameraChangeY = 0.008f;
    private float CameraChangeZ = 0.008f;
    private bool isShockButtonDown = true;

    public void ShockSubcamera()
    {
        CameraChangeY = -CameraChangeY;
        CameraChangeZ = -CameraChangeZ;

    }


    public void SubCameraPosition()
    {

        Vector3 Pos = RArmHandPos.transform.localPosition;
        Pos.x = Pos.x + 0;
        Pos.y =Pos.y + CameraChangeY;
        Pos.z =Pos.z + CameraChangeZ;
       
        RArmHandPos.transform.localPosition = Pos;
             




    }
    public void GetSubShockButtonDown()
    {

        this.isShockButtonDown = false;
    }
    public void GetSubShockButtonUp()
    {
        this.isShockButtonDown = true;
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
            ShockSubcamera();
            SubCameraPosition();
        }

    }
}
