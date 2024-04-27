using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour
{
	public float rotationSpeed = 5.0f;

	private TMP_Text text;
	private SceneVars sv;
	private AudioSource pickup;

	void Start()
	{
		text = GameObject.Find("Text (TMP)").GetComponent<TMP_Text>();
		sv = GameObject.Find("SceneVars").GetComponent<SceneVars>();
		pickup = GameObject.Find("Pickup").GetComponent<AudioSource>();
	}

	void Update()
	{
		float rs = rotationSpeed * Time.deltaTime;
		transform.Rotate(rs, rs, 0);
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.CompareTag("Player")) 
		{
			sv.cubes += 1;
			text.text = "Cubes: " + sv.cubes.ToString() + "/60";
			pickup.Play();
			Destroy(gameObject);
		}
	}
}
