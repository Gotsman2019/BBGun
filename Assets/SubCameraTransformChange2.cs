using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraTransformChange2 : MonoBehaviour
{
    public Transform RArmHandPos;
    private GameObject RArmHand;

    private float CameraChangeY = 1.5f;
    private float CameraChangeZ = 0.5f;
    private bool isShockButtonDown = true;

    public void ShockSubcamera()
    {
        CameraChangeY = -CameraChangeY;
        CameraChangeZ = -CameraChangeZ;

    }


    private void SubCameraPosition()
    {
        Vector3 Pos = RArmHandPos.transform.localPosition;
        Pos.x = Pos.x + 0;
        Pos.y = Pos.y + CameraChangeY;
        Pos.z = Pos.z + CameraChangeZ;

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

    public void Shock()
    {
            ShockSubcamera();
            SubCameraPosition();
    }


    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (!isShockButtonDown)
        {
            Shock();
        }   

    }
}
