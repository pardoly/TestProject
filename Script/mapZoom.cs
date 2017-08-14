using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapZoom : MonoBehaviour {

	void Update () {

		Camera Cam = gameObject.GetComponent<Camera> ();

		if (Cam.orthographicSize < 4.0f) {
			Cam.orthographicSize = 4.0f;
		}
		if (Cam.orthographicSize > 29.25f) {
			Cam.orthographicSize = 29.25f;
		}

		if (Input.GetKeyDown (KeyCode.KeypadPlus) && Cam.orthographicSize > 4.0f) {

			Cam.orthographicSize -= 10.0f;
			
		}
		if (Input.GetKeyDown (KeyCode.KeypadMinus) && Cam.orthographicSize < 29.25f) {

			Cam.orthographicSize += 10.0f;

		}

		
	}
}
