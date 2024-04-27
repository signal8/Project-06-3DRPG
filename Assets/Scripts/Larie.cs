using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larie : MonoBehaviour
{
	public TextAsset dialog;
	public TextAsset altDialog;
	private SceneVars sv;

	void Start()
	{
		sv = GameObject.Find("SceneVars").GetComponent<SceneVars>();
	}

	void Talk()
	{
		BasicInkExample sc = GameObject.Find("StoryController")
			.GetComponent<BasicInkExample>();

		if (sv.cubes == 60) sc.StartCharacterDialog(altDialog);
		else sc.StartCharacterDialog(dialog);
	}
}
