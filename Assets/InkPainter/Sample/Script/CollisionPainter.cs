using UnityEngine;
using System.Collections.Generic;

namespace Es.InkPainter.Sample
{

    public class HitPoint
    {
        public InkCanvas canvas;
        public Vector3 point;
        public int remainingFrame;
    }

    [RequireComponent(typeof(Collider), typeof(MeshRenderer))]
    public class CollisionPainter : MonoBehaviour
    {
       　//GameObject tama = GameObject.Find("shell");
        [SerializeField]
        private Brush brush = null;

        [SerializeField]
        private int wait = 3;

        private List<HitPoint> hitPointList = new List<HitPoint>();
        private int waitCount;
        private int eraseNum = 0;


        public void Awake()
        {
            GetComponent<MeshRenderer>().material.color = brush.Color;

        }

        public void FixedUpdate()
        {
            ++waitCount;

            for (int i = 0; i < hitPointList.Count; i++)
            {
                HitPoint hitPoint = hitPointList[i];

                hitPoint.remainingFrame--;

                if (hitPoint.remainingFrame <= 0)
                {
                    hitPoint.canvas.Erase(brush, hitPoint.point);
                    hitPointList.RemoveAt(i);

                }
            }
            GameObject tama = GameObject.Find("shell");
            GameObject tama2 = GameObject.Find("BBball");
            Destroy(tama);
            Destroy(tama2);
        }

        public void OnCollisionStay(Collision collision)
        {
            ++eraseNum;//当たった回数

            if (waitCount < wait)
                return;
            waitCount = 0;


            foreach (var p in collision.contacts)
            {
                var canvas = p.otherCollider.GetComponent<InkCanvas>();

                if (canvas != null)
                {
                    canvas.Paint(brush, p.point);

                    HitPoint hitPont = new HitPoint();
                    hitPont.canvas = canvas;
                    hitPont.point = p.point;
                    hitPont.remainingFrame = 30;
                    hitPointList.Add(hitPont);
                }
            }
        }
    }
}