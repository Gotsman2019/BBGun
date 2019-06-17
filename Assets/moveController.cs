using UnityEngine;
using System.Collections;

public class moveController : MonoBehaviour
{

    public float speed = 8.0f;
    private GameObject player;
    void Update()
    {

        player = GameObject.Find("Player");
        float basho = player.transform.position.y;


            if (Input.GetKey("i"))
            {

                transform.position += transform.forward * speed * Time.deltaTime;
                //yだけ変えたくない
            }
            if (Input.GetKey("m"))
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey("k"))
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
            if (Input.GetKey("j"))
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
        
      
    }
}