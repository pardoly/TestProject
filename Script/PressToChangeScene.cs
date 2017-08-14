using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToChangeScene : MonoBehaviour {

	public SceneFader fade;

	public void Select (string levelName)
	{
		fade.FadeTo (levelName);
	}
}
