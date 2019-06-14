﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tairyoku2 : MonoBehaviour
{
    public Transform LeftArm;
    public Transform RigthtArm;
    public Transform RArmUPER2;
    public Transform StartPoint;
    public int tairyoku;


    // Start is called before the first frame update

    private Animation Anime;


    void OnCollisionEnter(Collision collision)
    {
        if (tairyoku > 0)
        {
            if (collision.gameObject.tag == "tama")
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
        if (tairyoku > 0)
        {

        }
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

    }



    private void LateUpdate()
    {

        if (tairyoku <= 0)

        {


            RigthtArm.localRotation = Quaternion.Euler(80, -50, RigthtArm.localRotation.z);
            LeftArm.localRotation = Quaternion.Euler(-50, 50, LeftArm.localRotation.z);
            RArmUPER2.localRotation = Quaternion.Euler(0, RArmUPER2.localRotation.y, 0);

            this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();
            this.GetComponent<TacticalAI.TargetScript>().RemoveMine();


        }
    }
    public int GetTairyoku()
    {
        return tairyoku;
    }
    public void BackAI()
    {
        if (tairyoku <= 0)
        {
            Debug.Log(transform.name + tairyoku + "BackAI");
            RigthtArm.localRotation = Quaternion.Euler(80, -50, RigthtArm.localRotation.z);
            LeftArm.localRotation = Quaternion.Euler(-50, 50, LeftArm.localRotation.z);
            RArmUPER2.localRotation = Quaternion.Euler(0, RArmUPER2.localRotation.y, 0);

            this.GetComponent<TacticalAI.TargetScript>().ChangeTeamID();

            this.GetComponent<TacticalAI.TargetScript>().RemoveMine();

        }
    }
}