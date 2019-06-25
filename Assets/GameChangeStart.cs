using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameChangeStart : MonoBehaviour
{
    private bool GameStart = false;
    public void GameStartButtonDown()
    {
        this.GameStart = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameStart))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
