using UnityEngine;
using System.Collections.Generic;

namespace Es.InkPainter.Sample
{


    [RequireComponent(typeof(Collider), typeof(MeshRenderer))]
    public class CollisionPainter : MonoBehaviour
    {
        public List<Vector3> VecList = new List<Vector3>();



        [SerializeField]
        private Brush brush = null;

        [SerializeField]
        private int wait = 3;
      
        private int waitCount;
        private int eraseNum = 0;
        public void Awake()
        {
            GetComponent<MeshRenderer>().material.color = brush.Color;
        }

        public void FixedUpdate()
        {
            ++waitCount;
           
        }

        public void OnCollisionStay(Collision collision)
        {
            ++eraseNum;//当たった回数
            Debug.Log(eraseNum);
            if (waitCount < wait)
                return;
            waitCount = 0;


            foreach (var p in collision.contacts)
            {

                VecList.Add(p.point);
               var canvas = p.otherCollider.GetComponent<InkCanvas>();
                if (canvas != null)
                {
                    canvas.Paint(brush, p.point);


                    if (eraseNum > 10)
                    {
                        foreach(Vector3 i in VecList)
                        {
                            canvas.Erase(brush, i);

                        }
                    }

                }

            }
           
        }
      
    }
}
