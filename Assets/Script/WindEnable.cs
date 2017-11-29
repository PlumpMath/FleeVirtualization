using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEnable : MonoBehaviour
{
	private ParticleSystem[] particles;
	private BoxCollider2D box;
	[SerializeField] private float stepTime = 4;
	// Use this for initialization
	void Start()
	{
		particles = GetComponentsInChildren<ParticleSystem>();
		box = GetComponent<BoxCollider2D>();
		InvokeRepeating("Step", 0, stepTime);
	}

	void Step()
	{
		foreach (var item in particles)
		{
			if (item.isPlaying)
			{
				box.enabled = false;
				item.Stop();
				continue;
			}
			else if (item.isStopped)
			{
				box.enabled = true;
				item.Play();
			}
		}
	}
}
