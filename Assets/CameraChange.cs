using UnityEngine;
using System.Collections;

public class CameraChange : MonoBehaviour
{


    public Camera mainCamera;
    public Camera subCamera;
    private int kirikae = 1;
    void Start()
    {
        subCamera.enabled = false;

    }

    void Update()
    {

            if (Input.GetKeyDown("q"))
            {
                kirikae = -1 * kirikae;
            }


            if (kirikae == -1)
            {
                Debug.Log("SubCamera");
                mainCamera.enabled = false;
                subCamera.enabled = true;
            }
            if (kirikae == 1)
            {
                mainCamera.enabled = true;
                subCamera.enabled = false;
            }
        

    }
}
