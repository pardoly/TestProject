using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class ErikaPlayer : MonoBehaviour {

	public static Vector3 playerPos;
	public static Quaternion playerRot;

	[Header("PlayerStatus")]
	public float MaxHP = 100f;
	public float MaxMP = 200f;
	public static float HealthPoint;
	public static float MagicPoint;
	public static bool hit = false;
	public static bool heal = false;
	public static bool NoMagic = false; 

	public Image healthBar;
	public Image MagicBar;
	public Text HPText;
	public Text MPText;



	[Header("Skill Instantiate")]
	public GameObject ComboShoot;
	public GameObject ComboShootBig;
	public GameObject chargeVfx;
	public GameObject lightLaser;
	public GameObject lightWings;
	public GameObject OrbRotate;
	public GameObject teleport;
	public float teleportUseMP = 10.0f;


	[Header("Movements parameters")]
	public float teleportDistance = 2.0f;
	public float startMoveSpeed = 0.05f;
	public float moveSpeedMutiplier = 0.05f;
	float moveSpeed;
	public float moveSpeedLimit = 0.15f;

	private Animator anim;
	private Rigidbody rbody;

	//input parameters
	public bool lockP;
	public static float receiveDamage;
	public static float MPlose;
	private float inputV;
	private float inputH;
	private float v;
	private float h;
	private float dirRot;

	//Animator parameters
	private bool combo;
	public static bool charge;
	private bool buff;
	private bool laser;
	public static bool KO = false;

	//flags
	bool flag1 = false ;
	bool flag2 = false ;
	bool flag3 = false ;
	bool laserflag = false;
	bool lockLaser = false;
	bool chargeflag = false;
	bool buffflag = false;



	// Use this for initialization
	void Awake () {

		anim = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody> ();

		lockP = false;
		combo = false;
		charge = false;
		buff = false;
		laser = false;
		KO = false;
		v = 0.0f;
		h = 0.0f;

		HealthPoint = MaxHP;
		MagicPoint = MaxMP;

		moveSpeed = startMoveSpeed;



	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (HealthPoint);

		HPMPCalculate ();


	/*	if (Input.GetKeyDown ("space"))
		{
			returnOrigin ();
		}*/


		playerPos = transform.position;
		playerRot = transform.rotation;

		if (Input.GetKeyDown ("z") || Input.GetButtonDown("Fire2"))
		{
			Vector3 Spos = new Vector3 (0.0f, 1.2f, 1.8f);
			Debug.Log ("Combo!");
			combo = true;
		} 
		else 
		{
			combo = false;
		}

		if (flag1 == false && anim.GetCurrentAnimatorStateInfo(0).IsName ("Combo1"))
		{
			flag1 = true;
			lockP = true;
			Vector3 Spos = new Vector3 (transform.position.x, transform.position.y + 1.2f, transform.position.z);
			Instantiate (ComboShoot, Spos, transform.rotation);
		}
		if (flag2 == false && anim.GetCurrentAnimatorStateInfo(0).IsName ("Combo2"))
		{
			flag2 = true;
			Vector3 Spos = new Vector3 (transform.position.x, transform.position.y + 1.2f, transform.position.z);
			Instantiate (ComboShoot, Spos, transform.rotation);
			Instantiate (ComboShoot, Spos, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 45.0f, transform.eulerAngles.z));
			Instantiate (ComboShoot, Spos, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - 45.0f, transform.eulerAngles.z));

		}
		if (flag3 == false && anim.GetCurrentAnimatorStateInfo(0).IsName ("Combo3"))
		{
			flag3 = true;
			Vector3 Spos = new Vector3 (transform.position.x, transform.position.y + 1.2f, transform.position.z);
			Instantiate (ComboShootBig, Spos, Quaternion.Euler(transform.eulerAngles.x + 90.0f, transform.eulerAngles.y, transform.eulerAngles.z));
		}

	
			if (Input.GetKey ("x")) 
		{
			//Debug.Log ("charging");
			charge = true;

		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("charging")) 
		{
			UseMP (-1.0f);
			PlayerSound.isrecovering = true;

		}


		if (Input.GetKeyUp ("x")) 
		{
			charge = false;
			UseMP (0.0f);
		}


		if (Input.GetKeyUp ("j")) 
		{
			buff = true;

		} 
		else 
		{
			buff = false;
		}
		if (chargeflag == false && anim.GetCurrentAnimatorStateInfo(0).IsName ("chargeStart"))
		{
			lockP = true;
			chargeflag = true;
			Vector3 pos = new Vector3 (transform.position.x, transform.position.y + 0.1f, transform.position.z);
			Instantiate (chargeVfx, pos, Quaternion.identity);

		}

		if (charge == true && anim.GetCurrentAnimatorStateInfo(0).IsName ("chargeBuffing"))
		{
			charge = false;
		}

		if (buffflag == false && anim.GetCurrentAnimatorStateInfo(0).IsName ("chargeBuffStart"))
		{
			buffflag = true;
			summonBuff ();

		}

		if (lockLaser == false && Input.GetKey("x") && Input.GetKeyDown ("f"))
		{
			laser = true;
			//returnOrigin ();
			lockP = true;
			lockLaser = true;
		}
	

		if (laserflag == false && anim.GetCurrentAnimatorStateInfo(0).IsName ("LaserSkillStart"))
		{
			laserflag = true;
			//Vector3 laserPos = new Vector3 (transform.position.x -0.08655f, 
												//transform.position.y + 2.64f, transform.position.z+ 1.4f);
			Instantiate (lightLaser, transform.position, transform.rotation);
			//Quaternion WingRot = new Quaternion (-0.5f, 0.5f, -0.5f, 0.5f);
			//Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			//Instantiate (lightWings, pos, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 90.0f, transform.eulerAngles.z - 90.0f));
			UseMP(MaxMP / 2);
			laser = false;
		}

	


		//Kill All flags
		if (anim.GetCurrentAnimatorStateInfo(0).IsName ("Idle"))
		{
			lockP = false;

			flag1 = false;
			flag2 = false;
			flag3 = false;
			laserflag = false;
			lockLaser = false;
			chargeflag = false;
			buffflag = false;

			PlayerSound.isrecovering = false;

		}


		//SetAnimator
		anim.SetFloat ("inputH", inputH);
		anim.SetFloat ("inputV", inputV);
		anim.SetBool ("combo", combo);
		anim.SetBool ("charge", charge);
		anim.SetBool("buff", buff);
		anim.SetBool ("laser", laser);
		anim.SetBool ("KO", KO);


		//----------------------------------moveCharacter------------------------------------
		if (HealthPoint == 0) 
		{
			lockP = true;
			KO = true;
			receiveDamage = 0.0f;
			PlayerSound.isKO = true;

		}

		if (lockP == false) {
			Vector3 vec;


			inputH = Input.GetAxis ("Horizontal");
			inputV = Input.GetAxis ("Vertical");


			transform.position = new Vector3 (transform.position.x + inputH * moveSpeed,
				transform.position.y,
				transform.position.z + inputV * moveSpeed);


			if (inputH == 0.0f && inputV == 0.0f) 
			{
				vec = new Vector3 (h, 0.0f, v);
			} 
			else 
			{
				vec = new Vector3 (inputH, 0.0f, inputV);
				v = inputV;
				h = inputH;
			}
			vec.Normalize ();
			dirRot = Mathf.Atan2 (vec.x, vec.z) / 3.14159265f * 180.0f;


			transform.eulerAngles = new Vector3 (0.0f, dirRot, 0.0f);

			if (MagicPoint >= teleportUseMP && Input.GetKeyDown ("b")) 
			{
				UseMP (teleportUseMP);
				anim.SetBool("damage", false);
				transform.Translate (Vector3.forward * teleportDistance);
				Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
				Instantiate (teleport, pos, transform.rotation);
				PlayerSound.isTeleport = true;

			}

			//Debug.Log (MagicPoint);
		}

		if (NoMagic == false) {			//running........
				
			if (Input.GetKey ("c")) {
				
				UseMP (1.0f);

				moveSpeed += moveSpeedMutiplier;

				if (moveSpeed >= moveSpeedLimit) {
					moveSpeed = moveSpeedLimit;
				}

				GameObject.Find ("Main Camera").GetComponent<MotionBlur> ().enabled = true;
				PlayerSound.isRunning = true;
			}
		}
				

		if (Input.GetKeyUp ("c") || NoMagic == true) {
				
			moveSpeed　 = startMoveSpeed;
			GameObject.Find ("Main Camera").GetComponent<MotionBlur> ().enabled = false;
			PlayerSound.isRunning = false;
			}

		//Debug.Log (MagicPoint);




	}

    void returnOrigin()
	{
	  transform.position = new Vector3 (0f, 0f, 0f);
	  transform.eulerAngles = new Vector3 (0f, 0f, 0f);

	}

	void summonBuff()
	{
		
		Instantiate (OrbRotate, transform.position, Quaternion.identity);

	}

	void HPMPCalculate()
	{
		if (HealthPoint > MaxHP) {
			HealthPoint = MaxHP;
		}
		if (HealthPoint < 0.0f) {
			HealthPoint = 0.0f;
		}
		if (MagicPoint > MaxMP) {
			MagicPoint = MaxMP;
		}
		if (MagicPoint < 0.0f) {
			MagicPoint = 0.0f;
		}
		if (HealthPoint >= 0.0 && HealthPoint <= MaxHP) {
			if (heal == true) {
				TakeDamage (receiveDamage);
			}
			if (hit == true) {
				TakeDamage (receiveDamage);
				//anim.SetBool ("damage", true);
			}
		}
		if (MagicPoint >= 21.0) {
			UseMP (MPlose);
		}
		if (hit == false || heal == false) {
			TakeDamage (0.0f);
			//anim.SetBool ("damage", false);
		}

		HPText.text = Mathf.Round(HealthPoint) + "/" + MaxHP;
		MPText.text = Mathf.Round (MagicPoint) + "/" + MaxMP;
	}

	public void TakeDamage (float damageAmount)
	{
		HealthPoint -= damageAmount;
		healthBar.fillAmount = HealthPoint / MaxHP;

		hit = false;
	}

	public void UseMP (float MPusage)
	{

		if(MagicPoint >= 0 && MagicPoint <= MaxMP)
		{
			MagicPoint -= MPusage;
			NoMagic = false;
		}
		if(MagicPoint == 0)
		{
			NoMagic = true;
		}

		MagicBar.fillAmount = MagicPoint / MaxMP;
	}

}