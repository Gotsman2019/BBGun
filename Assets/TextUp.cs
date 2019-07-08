using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUp : MonoBehaviour
{
   public  GameObject Hit;
  
   public void TextShow()
    {
        Hit.transform.gameObject.SetActive(true);
        Debug.Log("TEXT");
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
