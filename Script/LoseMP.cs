using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMP : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			ErikaPlayer.MPlose = 1.0f;
		}

	}
	void OnTriggerExit(Collider col)
		{
			if (col.gameObject.tag == "Player") 
			{
				ErikaPlayer.MPlose = 0.0f;
			}

		}
}
