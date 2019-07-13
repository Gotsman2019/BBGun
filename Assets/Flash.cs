using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

    private GameObject flash;
    public GameObject muzzleFlash2;
    public float flashDestroyTime = 0.003f;
    public Transform muzzleFlashSpawn2;
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
    }

    // Update is called once per frame
    void Update()
    {
        //マズルフラッシュを作成してから、一定時間後にそれを破壊する
        if (flashtrue)
        {
            flash = (GameObject)(Instantiate(muzzleFlash2, muzzleFlashSpawn2.position, muzzleFlashSpawn2.rotation));

            flash.transform.parent = muzzleFlashSpawn2;

            GameObject.Destroy(flash, flashDestroyTime);
        }
        GameObject.Destroy(flash, flashDestroyTime);
    }
}
