using UnityEngine;
using System.Collections;

public class moveController : MonoBehaviour
{

    public float speed = 5.0f;
    private GameObject gun;
    void Update()
    {

        gun = GameObject.Find("MachineGun_01");


        if (gun.transform.position.y > 1 && gun.transform.position.y < 3)
        {

            if (Input.GetKey("w"))
            {
                transform.position += transform.forward * speed * Time.deltaTime;
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