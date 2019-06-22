using UnityEngine;
using System.Collections;

public class CameraChange : MonoBehaviour
{

    private bool isKirikaeButtonDown = false;
    public Camera mainCamera;
    public Camera subCamera;
    private int kirikae = 1;

    public void GetKirikaeButtonDown()
    {
        this.isKirikaeButtonDown = true;
    }
    public void GetKirikaeButtonUp()
    {
        this.isKirikaeButtonDown = false;
    }


    void Start()
    {
        subCamera.enabled = false;
    }
    public void KirikaeCamera()
    {
        if (Input.GetKeyDown("q") || (isKirikaeButtonDown))
        {
            kirikae = -1 * kirikae;
        }


        if (kirikae == -1)
        {

            mainCamera.enabled = false;
            subCamera.enabled = true;
        }
        if (kirikae == 1)
        {
            mainCamera.enabled = true;
            subCamera.enabled = false;
        }
    }

    void Update()
    {
        KirikaeCamera();
           

    }
}
