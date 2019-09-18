// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class AnimateUnderwater : MonoBehaviour
{



    // Drag this to the Water Object for more freedom of animation 


    //----------------------------------------------------


    // Declare here the input properties for each 
    // shader properties you want to animate

    public Vector2 distort1Speed;
    public Vector2 distort2Speed;

    private Vector2 distortionMap1UV;
    private Vector2 distortionMap2UV;


    void Start()
    {


        distort1Speed = distort1Speed / 10;
        distort2Speed = distort2Speed / 10;

    }

    void Update()
    {

        // Declare here the UV properties for each
        // shader properties you're animating

        // Repeat it for each shader properties

        distortionMap1UV.x = Time.time * distort1Speed.x;
        distortionMap1UV.y = Time.time * distort1Speed.y;

        distortionMap2UV.x = (Time.time * distort2Speed.x);
        distortionMap2UV.y = (Time.time * distort2Speed.y);




        // For each property copy this line and chage texture names and UV properties
        GetComponent< Renderer > ().material.SetTextureOffset("_DistortionMap1", distortionMap1UV);
        GetComponent< Renderer > ().material.SetTextureOffset("_DistortionMap2", distortionMap2UV);


    }
}