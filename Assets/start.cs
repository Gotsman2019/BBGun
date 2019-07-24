using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public void StartSurvival()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void StartNightGame()
    {
        SceneManager.LoadScene("NightGame");
    }
    public void StartDefense()
    {
        SceneManager.LoadScene("difense");
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
