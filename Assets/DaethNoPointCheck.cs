using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaethNoPointCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "friend")
        {
            enemyDeathPoint += 10;

        }
        if (other.transform.tag == "enemy")
        {
            PlayerDeathPoint += 10;
        }
        Debug.Log("Enemy Point" + enemyDeathPoint + "Player Point" + PlayerDeathPoint);
    }

    private int enemyDeathPoint;
    private int PlayerDeathPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
