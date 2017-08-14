using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBack : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			col.gameObject.transform.position = new Vector3 (0f, 0f, 0f);
		}
	}
}
