using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        this.scoreText.GetComponent<Text>().text = "Enemy Score"+" "+enemyDeathPoint+" "+"point";
    }
}
