using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

	private AudioSource source;
	private Animator anim;

	public AudioClip walkSE;
	public AudioClip teleportSE;
	public AudioClip runSE;
	public AudioClip recover;

	public static bool isTeleport = false;
	public static bool isRunning = false;
	public static bool isKO = false;
	public static bool isrecovering = false;

	void Start () {

		anim = gameObject.GetComponent<Animator> ();
		source = gameObject.GetComponent<AudioSource> ();

		
	}
	
	// Update is called once per frame
	void Update () {

		if (anim.GetFloat ("inputV") != 0.0f && source.isPlaying == false) {
			if (isRunning == true) {
				source.PlayOneShot (runSE);
			} else {			
				source.PlayOneShot (walkSE);
			}
		} 
		else if (anim.GetFloat ("inputH") != 0.0f && source.isPlaying == false) 
		{
			if (isRunning == true) {
				source.PlayOneShot (runSE);
			} else {			
				source.PlayOneShot (walkSE);
			}
		}


		if(isTeleport == true)
			{
				source.PlayOneShot(teleportSE);
				isTeleport = false;
			}

		if (isKO == true) {

			source.Stop ();
		}

		if (isrecovering == true && source.isPlaying == false) {
			source.PlayOneShot (recover);
		}
		
	}


}
