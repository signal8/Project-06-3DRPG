using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject pa;
	private Animator pa_anim;

	void Start()
	{
		pa_anim = pa.GetComponent<Animator>();
	}

	void Update()
	{
		if (Input.GetKey("r")) pa_anim.SetTrigger("Dance");

		if (!Input.GetKey("f")) return;
		Vector3 v = pa.transform.position;
		v += Vector3.up;

		RaycastHit hit;
		if (Physics.Raycast(v, pa.transform.forward, out hit, 5))
		{
			if (!hit.collider.CompareTag("NPC")) return;
			hit.collider.gameObject.SendMessage("Talk");
		}

	}

	void OnTriggerEnter(Collider c)
	{
		if (c.CompareTag("Pickup")) Destroy(c.gameObject);
	}

	void OnDrawGizmosSelected()
	{
		Vector3 tmp = transform.position;
		tmp += transform.forward * 5;

		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, tmp);
	}
}
