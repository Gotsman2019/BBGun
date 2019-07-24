using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

    private GameObject flash;
    private GameObject flash2;
    public GameObject muzzleFlash2;
    public GameObject muzzleFlash3;
    public float flashDestroyTime = 0.003f;
    public float flashDestroyTime2 = 0.001f;
    public Transform muzzleFlashSpawn2;
    public Transform muzzleFlashSpawn3;
    private bool flashtrue;
    public  void FlashSpawn()
    {
        flashtrue = true;
    }
    public void FlashSpawnEnd()
    {
        flashtrue = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        flash = (GameObject)(Instantiate(muzzleFlash2, muzzleFlashSpawn2.position, muzzleFlashSpawn2.rotation));
        flash2 = (GameObject)(Instantiate(muzzleFlash3, muzzleFlashSpawn3.position, muzzleFlashSpawn3.rotation));
    }

    // Update is called once per frame
    void Update()
    {
        //マズルフラッシュを作成してから、一定時間後にそれを破壊する
        if (flashtrue)
        {
            flash = (GameObject)(Instantiate(muzzleFlash2, muzzleFlashSpawn2.position, muzzleFlashSpawn2.rotation));
            flash2 = (GameObject)(Instantiate(muzzleFlash3, muzzleFlashSpawn3.position, muzzleFlashSpawn3.rotation));
            flash.transform.parent = muzzleFlashSpawn2;
            flash2.transform.parent = muzzleFlashSpawn3;

            GameObject.Destroy(flash, flashDestroyTime);
            GameObject.Destroy(flash2, flashDestroyTime2);
        }
        GameObject.Destroy(flash, flashDestroyTime);
        GameObject.Destroy(flash2, flashDestroyTime2);
    }
}
