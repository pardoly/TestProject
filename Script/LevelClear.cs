using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClear : MonoBehaviour {

	public bool FinalStage = false;
	public int levelToUnlock;

	void Start()
	{
		if (FinalStage == true) 
		{
			ShowClearTime.isRank = true;
		} 
		else
		{
			ShowClearTime.isRank = false;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			Application.LoadLevel ("mazeLevelClear");
			PlayerPrefs.SetInt ("levelReached", levelToUnlock);
		}
	}
}
