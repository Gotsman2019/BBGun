using UnityEngine;
using System.Collections;

public class moveController : MonoBehaviour
{

    public float speed = 8.0f;
    private GameObject gun;
    void Update()
    {

        gun = GameObject.Find("MachineGun_01");
        float basho = gun.transform.position.y;

        if (gun.transform.position.y > 1 && gun.transform.position.y < 3)
        {
            //範囲を超えたら戻す必要あり


            if (Input.GetKey("w"))
            {

                transform.position += transform.forward * speed * Time.deltaTime;
                //yだけ変えたくない
            }
            if (Input.GetKey("s"))
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        }
      
    }
}