using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomEnemy : MonoBehaviour
{
	private NavMeshAgent agent;
	private Animator anim;
	private float timer;
	private bool dancing = false;
	private AudioSource aud;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		anim = gameObject.GetComponentInChildren<Animator>();
		aud = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Input.GetKey("e") && timer <= 0.0f) 
		{
			aud.Play();
			agent.ResetPath();
			dancing = true;
			timer = 2.0f;
			anim.SetTrigger("Dance");
		}
		
		if (timer >= 0.0f) timer -= Time.deltaTime;
		else dancing = false;

		if (agent.hasPath || agent.remainingDistance > 0.1f 
				|| dancing == true) return;
		else
		{
			agent.SetDestination((Random.insideUnitSphere * 10) +
					transform.position);
		}
	}

}
