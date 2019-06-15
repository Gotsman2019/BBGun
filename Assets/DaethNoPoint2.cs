using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaethNoPoint2: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "friend")
        {
            enemyDeathPoint += 10;

        }
        Debug.Log("Enemy Point" + enemyDeathPoint);
    }

    private int enemyDeathPoint;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
