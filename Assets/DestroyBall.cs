using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
   public float desball;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, desball);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
