using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsion : MonoBehaviour
{
	[SerializeField] private GameObject targetObject;
	[SerializeField] private float repulsionSpeed = 7f;
	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Contains("Player"))
		{
			audioSource.Play();
		}
	}
}
