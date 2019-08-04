using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDown : MonoBehaviour
{
    private GameObject child;
    private Animator animator;
    public void DeathAnim()
    {
        animator.SetTrigger("DeathCheckAI");
       
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

       
    }
}
