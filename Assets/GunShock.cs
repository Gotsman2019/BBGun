using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShock : MonoBehaviour
{
    private Animation Anime;
    public Transform M4MB;
    public Transform Spine;
    private float motox;
    private float motoy;
    private float motoz;
    public float xyure;
    public float yyure;
    public float zyure;
    public float xSpineyure;
    public float ySpineyure;
    public float zSpineyure;
    private Vector3 Posit;
    private Vector3 PosSpine;
   
    public void GunyureData()
    {
        
        xyure = -xyure;
        yyure = -yyure;
        zyure = -zyure;
        xSpineyure = -xSpineyure;
        ySpineyure = -ySpineyure;
        zSpineyure = -zSpineyure;


    }
    public void Gunyure()
    {

        //  Vector3 pos = WantMoveGun.transform.localPosition;
        Posit.x = Posit.x + xyure;
        Posit.y = Posit.y + yyure;
        Posit.z = Posit.z + zyure;
        PosSpine.x = PosSpine.x + xSpineyure;
        PosSpine.y = PosSpine.x + ySpineyure;
        PosSpine.z = PosSpine.z + zSpineyure;

        M4MB.localPosition = Posit;

    }
    public void MoveGunShock()
    {

            GunyureData();
            Gunyure();


    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
