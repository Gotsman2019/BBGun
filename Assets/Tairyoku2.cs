using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tairyoku2 : MonoBehaviour
{
    public Transform LeftArm;
    public Transform RigthtArm;
    public Transform RArmUPER2;
    public Transform StartPoint;
    public int tairyoku;
    public float time = 60;
    public AudioClip KillSound;
    private AudioSource audioSource;
    // Start is called before the first frame update

    private Animation Anime;
    private GameObject LimitTime;
    private GameObject showgameover;
    private GameObject restartbutton;

    private GameObject restartimage;
    private GameObject textgameover;
    private GameObject killscore;
    private bool soundcheck;
    private int Score;


    void OnCollisionEnter(Collision collision)
    {
        if (tairyoku > 0)
        {
            if (collision.gameObject.tag == "tama2")
            {
                tairyoku -= 30;

                {
                    BackAI();
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "route4")
        {
            tairyoku = 80;
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

            this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();
            this.GetComponent<TacticalAI.TargetScript>().SetMine();
           


        }

    }

    void Start()
    {
        Anime = GetComponent<Animation>();
        this.LimitTime = GameObject.Find("LimitTime");
        this.showgameover = GameObject.Find("RedGameover");
        this.restartimage = GameObject.Find("Restart");
        this.restartbutton = GameObject.Find("RestartText");
        this.textgameover = GameObject.Find("GameOverText");
        this.killscore = GameObject.Find("KillScore");
        showgameover.GetComponent<Image>().enabled = false;
        textgameover.GetComponent<Text>().enabled = false;
        //killscore.GetComponent<Text>().enabled = false;
        audioSource = GetComponent<AudioSource>();
        soundcheck = false;

    }



    private void LateUpdate()
    {
        this.killscore.GetComponent<Text>().text = (Score + "Kills");
        time -= 1f * Time.deltaTime;
        if (time > 0)
        {
            this.LimitTime.GetComponent<Text>().text = ((int)time).ToString() + "Sec";
        }
        if (time <= 0)
        {
            ShowGameover();
            TextGameEnd();
            tairyoku = 0;
            RestertImage();
            Restertext();

        }
        if (tairyoku <= 0)

        {
            if (!soundcheck)
            {
                audioSource.PlayOneShot(KillSound);
                soundcheck = true;
            }
            RigthtArm.localRotation = Quaternion.Euler(80, -50, RigthtArm.localRotation.z);
            LeftArm.localRotation = Quaternion.Euler(-50, 50, LeftArm.localRotation.z);
            RArmUPER2.localRotation = Quaternion.Euler(0, RArmUPER2.localRotation.y, 0);

            this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();
            this.GetComponent<TacticalAI.TargetScript>().RemoveMine();

        }
    }


    public void ScoreCount()
      {
        Score += 1;
      }



    public void RestertButtonDown()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void RestertImage()
    {
       
        restartimage.GetComponent<Image>().enabled = true;
    }
    public void Restertext()
    {
        restartbutton.GetComponent<Text>().enabled = true;
    }


    public void ShowGameover()
    {
        showgameover.GetComponent<Image>().enabled = true;
       
    }
    public void TextGameEnd()
    {
        textgameover.GetComponent<Text>().enabled = true;

    }

    public int GetTairyoku()
    {
        return tairyoku;
    }
    public void BackAI()
    {

        if (tairyoku <= 0)
        {
            if (!soundcheck)
            {
                audioSource.PlayOneShot(KillSound);
                soundcheck = true;
            }

            RigthtArm.localRotation = Quaternion.Euler(80, -50, RigthtArm.localRotation.z);
            LeftArm.localRotation = Quaternion.Euler(-50, 50, LeftArm.localRotation.z);
            RArmUPER2.localRotation = Quaternion.Euler(0, RArmUPER2.localRotation.y, 0);

            this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();

            this.GetComponent<TacticalAI.TargetScript>().RemoveMine();

        }
    }
}