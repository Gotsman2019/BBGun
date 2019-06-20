using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DaethNoPointCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "enemy")
        {
            PlayerDeathPoint += 10;
        }

    }

    private int enemyDeathPoint;
    private int PlayerDeathPoint;
    private GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText2");
    }

    // Update is called once per frame
    void Update()
    {
        this.scoreText.GetComponent<Text>().text = "My Team Score" + " " + PlayerDeathPoint + " " + "point";
    }
}
