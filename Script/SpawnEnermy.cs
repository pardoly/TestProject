using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnermy : MonoBehaviour {

	public GameObject enermy;
	public bool hellMode = false;

	// Use this for initialization
	void Start () {

		if (hellMode == false) {
			Instantiate (enermy, transform.position, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if(hellMode == true && col.gameObject.tag == "Player")
		{
			for (int i = 0; i < 10; i++) {
				Vector3 pos = new Vector3 (transform.position.x + Random.Range (-1.0f, 1.0f),
					             transform.position.y,
					             transform.position.z + Random.Range (-1.0f, 1.0f));

				Instantiate (enermy, pos, Quaternion.identity);
				Destroy (gameObject, 0.5f);

			}
				
				}
		}

}
