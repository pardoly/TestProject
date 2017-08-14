using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public SceneFader fade;

	void Update()
	{
		if (ErikaPlayer.HealthPoint == 0) {
			StartCoroutine (NextScene ());
		}
	}



	IEnumerator NextScene () {


			yield return new WaitForSeconds (2f);

			fade.FadeTo ("mazeGameOver");



	}
}
