using UnityEngine;
using System.Collections;

public class CameraChange : MonoBehaviour
{

  
    private bool isKirikaeButtonUp = false;
    private bool modosu = false;
    public Camera mainCamera;
    public Camera subCamera;
    public int kirikae;
  // private int i=1;


    public void GetKirikaeButtonUp()
    {
        this.isKirikaeButtonUp = true;
        this.modosu = false;
    }

    public void GetModosuButtonUp()
    {
        this.modosu = true;
        this.isKirikaeButtonUp = false;
    }


    void Start()
    {

        subCamera.enabled = false;

    }





    void Update()
    {

        if (Input.GetKeyDown("q") || (isKirikaeButtonUp))
        
            {
                mainCamera.enabled = false;
                subCamera.enabled = true;
            }




          if (modosu)
            {
                mainCamera.enabled = true;
                subCamera.enabled = false;
            }

       
       
           

    }
}
