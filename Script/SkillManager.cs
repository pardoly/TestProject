using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour {

	[Header("Skill Element")]
	public static int elementNum;
	public static bool elementChange = false;



	// Use this for initialization
	void Start () {
		elementNum = 0;
		ElementColor.rValue = 0.574f;
		ElementColor.gValue = 0.767f;
		ElementColor.bValue = 1.0f;
		ElementColorTint.rTintValue = 0.288f;
		ElementColorTint.gTintValue = 0.5f;
		ElementColorTint.bTintValue = 1.0f;



			
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (HealthPoint);
	}



	public void SetElement0()     // 0 = light, 1 = fire, 2 = ice, 3 = dark, 4 = electric
	{
		elementNum = 0;
		elementChange = true;
		ElementColor.rValue = 0.574f;
		ElementColor.gValue = 0.767f;
		ElementColor.bValue = 1.0f;
		ElementColorTint.rTintValue = 0.288f;
		ElementColorTint.gTintValue = 0.5f;
		ElementColorTint.bTintValue = 1.0f;

	}


	public void SetElement1()
	{
		elementNum = 1;
		elementChange = true;
		ElementColor.rValue = 1.0f;
		ElementColor.gValue = 0.15f;
		ElementColor.bValue = 0.0f;
		ElementColorTint.rTintValue = 1.0f;
		ElementColorTint.gTintValue = 0.15f;
		ElementColorTint.bTintValue = 0.0f;

	}

	public void SetElement2()
	{
		elementNum = 2;
		elementChange = true;
		ElementColor.rValue = 0.3f;
		ElementColor.gValue = 0.3f;
		ElementColor.bValue = 1.0f;
		ElementColorTint.rTintValue = 0.0f;
		ElementColorTint.gTintValue = 0.0f;
		ElementColorTint.bTintValue = 0.8f;
	}

	public void SetElement3()
	{
		elementNum = 3;
		elementChange = true;
		ElementColor.rValue = 0.5f;
		ElementColor.gValue = 0.0f;
		ElementColor.bValue = 0.5f;
		ElementColorTint.rTintValue = 0.5f;
		ElementColorTint.gTintValue = 0.0f;
		ElementColorTint.bTintValue = 0.5f;
	}

	public void SetElement4()
	{
		elementNum = 4;
		elementChange = true;
		ElementColor.rValue = 1.0f;
		ElementColor.gValue = 1.0f;
		ElementColor.bValue = 0.238f;
		ElementColorTint.rTintValue = 1.0f;
		ElementColorTint.gTintValue = 1.0f;
		ElementColorTint.bTintValue = 0.238f;
	}


}
