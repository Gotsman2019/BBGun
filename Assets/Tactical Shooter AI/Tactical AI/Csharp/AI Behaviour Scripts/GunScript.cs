using UnityEngine;
using System.Collections;

/*
 * Manages the firing of the gun, and has minor influence on aiming.
 * Also deals with secondary fire
 * */

namespace TacticalAI{
public class GunScript : MonoBehaviour {

	//Stuff
	public TacticalAI.BaseScript myAIBaseScript;
	public TacticalAI.AnimationScript animationScript;
    public TacticalAI.SoundScript soundScript;
    public AudioSource audioSource;

	int[] enemyTeams;	

	//Bullet stuff	
	public GameObject bulletObject;
	public AudioClip bulletSound;
	[Range (0.0f, 1.0f)]
	public float bulletSoundVolume = 1;	
	public Transform  bulletSpawn;	
	public GameObject muzzleFlash;
	public Transform muzzleFlashSpawn;
	public float flashDestroyTime = 0.3f;
	bool canCurrentlyFire = true;

	
	//Used for shotguns; 1 is default and should be used for non-shotgiun weapons
	public int pelletsPerShot = 1;	
	
	//Just to determine whether or not or projectiles should home in on our enemies
	public bool isRocketLauncher = false;
	
	//Secondary Fire
	public GameObject secondaryFireObject;
	//1 = highest probability
	[Range (0.0f, 1.0f)]
	public float oddsToSecondaryFire = 0.1f;
	public float minDistForSecondaryFire = 10;
	public float maxDistForSecondaryFire  = 50;
	bool canFireGrenadeAgain = false;	
	Vector3 lastPosTargetSeen = Vector3.zero;
	public bool needsLOSForSecondaryFire = false;
	bool canThrowGrenade = true;
	public  float minTimeBetweenSecondaryFire = 4;	

	
	//RoF, burst and timer Stuff		
	public float minPauseTime = 1;
	public float randomPauseTimeAdd  = 2;	
	public int minRoundsPerVolley = 1;
	public int maxRoundsPerVolley = 10;
	public int minBurstsPerVolley;
	public int maxBurstsPerVolley;	
	public int currentRoundsPerVolley;	
	public float rateOfFire = 2;
	float timeBetweenBursts;	
	public float burstFireRate = 12;
	public int shotsPerBurst = 1;
	float timeBetweenBurstBullets;
	
	//Reloading
	public int bulletsUntilReload = 60;
	public AudioClip reloadSound;	
	[Range (0.0f, 1.0f)]
	public float reloadSoundVolume = 1;
	bool isReloading = false;
	int currentBulletsUntilReload = 0;
	public float reloadTime = 2;	

	//Accuracy
	public float inaccuracy = 1;	
	[Range (0.0f, 90.0f)]
	public float maxFiringAngle = 10;	
	[Range (0.0f, 90.0f)]
	public float maxSecondaryFireAngle = 40;
	Quaternion fireRotation;	
	
	//Transforms
	Transform targetTransform;
	Transform LOSTargetTransform;
	
	//LoS stuff
	LayerMask LOSLayermask;
	public float timeBetweenLOSChecks = 2;
	//bool canSeePlayer = true;
	//bool canDoLOSCheck = false;
	
	//Private status stuff
	bool aware = false;
	bool isFiring = false;
	bool isWaiting = false;
	
	//Cover	
	public float distInFrontOfTargetAllowedForCover = 3;
	public float coverTransitionTime = 0.45f;
	float rayDist;

	//Sound
	public float soundRadius = 7;

    public float minimumDistToFireGun = 0;
    public float maximumDistToFireGun = 9999;



        void Awake (){
		//Set default values, calculate squared distances, etc.
		LOSLayermask = TacticalAI.ControllerScript.currentController.GetLayerMask();

        if (!audioSource && bulletSpawn)
            if (bulletSpawn.gameObject.GetComponent<AudioSource>())
                audioSource = bulletSpawn.gameObject.GetComponent<AudioSource>();

        if(gameObject.GetComponent<SoundScript>())
            {
                soundScript = gameObject.GetComponent<SoundScript>();
            }

            if (!grenadeSpawn)
                grenadeSpawn = bulletSpawn;
        isFiring = false;
		isWaiting= false;
		currentBulletsUntilReload = bulletsUntilReload;	
		timeBetweenBurstBullets = 1/burstFireRate;
		timeBetweenBursts = 1/rateOfFire;	
		minBurstsPerVolley = (int)(minRoundsPerVolley/shotsPerBurst);
		maxBurstsPerVolley = (int)(maxRoundsPerVolley/shotsPerBurst);	
		maxFiringAngle /= 2;
		maxSecondaryFireAngle /= 2;
        minimumDistToFireGun = minimumDistToFireGun * minimumDistToFireGun;
        maximumDistToFireGun = maximumDistToFireGun * maximumDistToFireGun;
    }
		
	// Stuff we need done after all other stuff is set up
	void Start () {
		enemyTeams = myAIBaseScript.GetEnemyTeamIDs();
	}

     float timer = 30;
	// Update is called once per frame
	void LateUpdate ()
        {
				if(aware)
					{             
                        //If we're not doing anythingm start the bullet firing cycle
						if(!isFiring && !isWaiting && bulletObject)
							{						
								StartCoroutine(BulletFiringCycle());
							}	
						else if(!bulletObject)	
							{
								Debug.LogWarning("Can't fire because there is no bullet object selected!");
							}
					}
            timer--;

    }

    public bool checkForFriendlyFire;
    public string friendlyTag;
	
	//Shooting////////////////////////////////////////////////////////	
	IEnumerator BulletFiringCycle()
	{
		//Fire
		isFiring = true;

            //エージェントが隠れて発射位置に遷移するアニメーションが終了するのを待ちます。
            if (myAIBaseScript.inCover)
			yield return new WaitForSeconds(coverTransitionTime*1.5f);

            //エージェントがターゲットに気付いていない場合やターゲットに近接している場合は攻撃しないでください。
            if (myAIBaseScript.IsEnaging() && !myAIBaseScript.isMeleeing && !myAIBaseScript.inParkour)
			{
                //LOSTargetTransformに明確なLoSがある場合は、発砲します。
                //ターゲットの頭の真上の位置まで視線を確認したい場合があります（たとえば、
                //たとえ彼らが目標を見ることができなくても彼はあなたのエージェントが射撃を抑制することを可能にするでしょう。
                if (LOSTargetTransform && !animationScript.isSprinting())
					{
                    //二度目の発砲を使用できるかどうかを確認
                    //手榴弾がLoSを必要としないかもしれない間、ホーミングミサイルはそうするかもしれません
                    if (!Physics.Linecast(bulletSpawn.position, LOSTargetTransform.position, LOSLayermask) || !locatedNewGrenadeTargetYet)	
							{
								lastPosTargetSeen = targetTransform.position;
                                locatedNewGrenadeTargetYet = true;
                                canFireGrenadeAgain = true;							
								FireOneGrenade();
								canFireGrenadeAgain = true;										
							}
						else if(!needsLOSForSecondaryFire)
							{
                                lastPosTargetSeen = targetTransform.position;
                                if (canFireGrenadeAgain)
									FireOneGrenade();
                                canFireGrenadeAgain = true;	
							}
					}
                //Paragon AIエージェントに聞こえるようなサウンドを作成する
                //この音はプレイヤーには聞こえないでしょう
                if (soundRadius > 0)
					{
						TacticalAI.ControllerScript.currentController.CreateSound(bulletSpawn.position, soundRadius, enemyTeams);
					}
                //通常の弾丸を撃つ
                if (animationScript.currentlyRotating)
                {
                    yield return StartCoroutine(Fire());
                }
			}
		
		//Transition
		isWaiting = true;
		isFiring = false;


            //リロードしていない場合は、しばらくの間待ってからもう一度バーストします。
            if (currentBulletsUntilReload > 0 && reloadTime > 0)
			{
				yield return new WaitForSeconds(minPauseTime + Random.value * randomPauseTimeAdd);
			}
		else
			{
                isReloading = true;
                //弾薬不足の場合は、リロードしてください
                if (reloadSound)
					{
                        audioSource.volume = reloadSoundVolume;
                        audioSource.PlayOneShot(reloadSound);
					}
				if(animationScript)	
					{
						animationScript.PlayReloadAnimation();
					}
                if(soundScript)
                    {
                        soundScript.PlayReloadAudio();
                    }
				yield return new WaitForSeconds(reloadTime);
				currentBulletsUntilReload = bulletsUntilReload;
                isReloading = false;
                yield return new WaitForSeconds(minPauseTime * Random.value);
			}
		isWaiting= false;
	}
	
	IEnumerator Fire()
	{

    //Check Distances
    float distSqr = Vector3.SqrMagnitude(bulletSpawn.position - LOSTargetTransform.position);
    if(minimumDistToFireGun <= distSqr && maximumDistToFireGun >= distSqr)
                //エージェントのマガジンに残っている数よりも多くの弾丸を発射しないようにしてください。
		currentRoundsPerVolley = Mathf.Min(Random.Range(minBurstsPerVolley, maxBurstsPerVolley), currentBulletsUntilReload);

            //弾丸が残っていることを確認し、エージェントが死んだ場合は発砲を止めます
            while (currentRoundsPerVolley > 0 && this.enabled && !animationScript.isSprinting() && !myAIBaseScript.inParkour)
			{	
				if(LOSTargetTransform && canCurrentlyFire)
					{
                    //光線が常に「前方」を向いていることを確認してください。
                    //ターゲットに対して明確なLoSがあることを確認してください
                    //彼らはカバーの薄い層の後ろにある場合でもエージェントがまだターゲットに発射するようにレイを短く停止することができます
                    rayDist = Mathf.Max(0.00001f, Vector3.Distance(bulletSpawn.position, LOSTargetTransform.position) - distInFrontOfTargetAllowedForCover);		
						if(rayDist == 0 || !Physics.Raycast(bulletSpawn.position, LOSTargetTransform.position-bulletSpawn.position, rayDist, LOSLayermask))	
							{
                                bool canFire = true;
                                if(checkForFriendlyFire)
                                {
                                    RaycastHit hit;
                                    if(Physics.Raycast(bulletSpawn.position, targetTransform.position - bulletSpawn.position, out hit, Vector3.Distance(bulletSpawn.position, LOSTargetTransform.position), LOSLayermask))
                                        {
                                            if(hit.transform.tag == friendlyTag)
                                            {
                                                canFire = false;
                                            }
                                        }
                                }
                        if (canFire)
                            {
                            //決まった数の弾丸を爆発させます。 通常、この数は1です。
                            for (int i = 0; i < shotsPerBurst; i++)
                                {
                                    if (i < shotsPerBurst - 1)
                                        yield return new WaitForSeconds(timeBetweenBurstBullets);
                                    currentBulletsUntilReload--;
                                    FireOneShot();
                                }
                            }
					    }															
						currentRoundsPerVolley--;
					}
				else
					{
						yield break;
					}
                if (currentRoundsPerVolley > 0)
                {
				    yield return new WaitForSeconds(timeBetweenBursts);
                }
			}
	}
		
	void FireOneShot()
	{
		//Look At Target
		if(targetTransform && !myAIBaseScript.inParkour)
			{
                //少し離れている場合でも、目標を目標に合わせる
                //これは、RotateToAimGunScriptがターゲットを直接指すことはめったにないためです。
                bool amAtTarget = Vector3.Angle(bulletSpawn.forward, targetTransform.position - bulletSpawn.position) < maxFiringAngle;

                //Fire Shot
                //ほとんどの弾丸は1つの弾丸を持っています。 しかし、ショットガンやそれに類する武器にはもっと多くのものがあります。
                for (int j = 0; j < pelletsPerShot; j++)
					{
                        if (amAtTarget)
                        {
                            fireRotation.SetLookRotation(targetTransform.position - bulletSpawn.position);
                        }
                        else
                        {
                            fireRotation = Quaternion.LookRotation(bulletSpawn.forward);
                        }

                    //正確さをシミュレートするために、ランダムな量で目標を変更してください。
                    fireRotation *= Quaternion.Euler(Random.Range(-inaccuracy, inaccuracy), Random.Range(-inaccuracy, inaccuracy), 0); 

						GameObject bullet = (GameObject)(Instantiate(bulletObject, bulletSpawn.position, fireRotation));
                    //これがTacticalAI Bullet Scriptを使用していてロケットランチャーの場合
                    if (isRocketLauncher && bullet.GetComponent<TacticalAI.BulletScript>())
							{
								bullet.GetComponent<TacticalAI.BulletScript>().SetAsHoming(targetTransform);
							}
					}

                //プレイヤーに聞こえる音を再生する
                if (bulletSound)
					{
                        audioSource.volume = bulletSoundVolume;
                        audioSource.PlayOneShot(bulletSound);
					}
					
				if(animationScript)	
					{
						animationScript.PlayFiringAnimation();
					}

                //マズルフラッシュを作成してから、一定時間後にそれを破壊する
                if (muzzleFlash)
					{
						GameObject flash = (GameObject)(Instantiate(muzzleFlash, muzzleFlashSpawn.position, muzzleFlashSpawn.rotation));
						flash.transform.parent = muzzleFlashSpawn;
						GameObject.Destroy(flash, flashDestroyTime);	
					}
			}
	}
	
	
	//Shooting////////////////////////////////////////////////////////
	//Secondary Fire////////////////////////////////////////////////////////
	void FireOneGrenade()
	{
       //Debug.Log("weehoo");
       if (Random.value < oddsToSecondaryFire && canThrowGrenade && Vector3.Angle(bulletSpawn.forward, lastPosTargetSeen - bulletSpawn.position)  < maxSecondaryFireAngle && secondaryFireObject)
			{
                //Debug.Log("lol");
				float dist = Vector3.Distance(lastPosTargetSeen, bulletSpawn.position);
				if(dist < maxDistForSecondaryFire && dist > minDistForSecondaryFire && timer < 0)
					{
						canFireGrenadeAgain = false;	
						StartCoroutine(SetTimeUntilNextGrenade());


                        myAIBaseScript.ThrowGrenade(secondaryFireObject, lastPosTargetSeen, grenadeSpawn);
                        /*
                        //Fire Secondary Fire
                        //Debug.Log("eeee");
                        //Debug.Break();
                        GameObject currentGrenade = (GameObject)(Instantiate(secondaryFireObject, bulletSpawn.position, bulletSpawn.rotation));

                        //Stuff to deal with Grenades
                        currentGrenade.transform.LookAt(lastPosTargetSeen);
                        if(currentGrenade.GetComponent<TacticalAI.GrenadeScript>())
                            {
                                currentGrenade.GetComponent<TacticalAI.GrenadeScript>().SetTarget(lastPosTargetSeen);
                            }	*/
                    }
            }			
	}
        //Secondary Fire////////////////////////////////////////////////////////
        public Transform grenadeSpawn;
		
	//Setters
	public void EndEngage()
	{
		targetTransform = null;
		aware = false;
	}
	
	public void AssignTarget(Transform newTarget, Transform newLOSTarget){	
		targetTransform = newTarget;
		LOSTargetTransform = newLOSTarget;
		aware = true;			
	}	
	
	public void SetCanCurrentlyFire(bool b)
	{
		canCurrentlyFire = b;
	}
	
	public void SetAware()
	{
		aware = true;
	}
	
	public void SetEnemyBaseScript(TacticalAI.BaseScript x)
	{
		myAIBaseScript = x;
	}	
	
	public void ChangeTargets(Transform newl,Transform newt)
	{
		LOSTargetTransform = newl;
		targetTransform = newt;				
	}

    bool locatedNewGrenadeTargetYet;

	IEnumerator SetTimeUntilNextGrenade()
	{
		canThrowGrenade = false;
		yield return new WaitForSeconds(minTimeBetweenSecondaryFire);
		canThrowGrenade = true;
	}		

	public bool IsFiring()
	{
		return isFiring;
	}	
        
    public bool IsReloading()
	{
		return isReloading;
	}		
}
}