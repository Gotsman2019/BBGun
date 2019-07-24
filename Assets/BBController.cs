using UnityEngine;
using System.Collections;

public class BBController : MonoBehaviour {

       public int ChangeRotation;
        // Use this for initialization
        void Start () {
               
        }
        
        // Update is called once per frame
        void Update () 
        {
        ChangeRotation -= 3;
          if (ChangeRotation > 0)
            {
            this.transform.Rotate(-ChangeRotation, 0, 0);
            }

        }
}