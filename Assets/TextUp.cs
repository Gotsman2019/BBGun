using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUp : MonoBehaviour
{
    public float shotSpeed;
    public GameObject bulletPrefab;
    public int shotCount = 50;
    private float shotInterval;
    private  GameObject Hit;
    private float waitingTime = 1.0f;

    public void TextShow()
    {
        waitingTime -= 0.2f;

        shotInterval += 1;

        if (waitingTime <= 0 && shotCount > 0 && shotInterval % 30 == 0)
        {
            shotCount -= 1;

            //  Hit.transform.gameObject.SetActive(true);

            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.localEulerAngles.x, transform.parent.localEulerAngles.y, 0));
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            Vector3 force = new Vector3(0.0f, 1.0f, 1.0f);
            bulletRb.AddForce(force * shotSpeed);
        }

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
