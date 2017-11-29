using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MoveToTargetPos : MonoBehaviour
{
	[SerializeField] private GameObject[] objects;
	[SerializeField] private Transform targetTransform;
	private float currentTime;
	public float totalTime = 0.6f;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (objects.Contains(collision.gameObject))
		{
			collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			currentTime = 0f;
			StartCoroutine(Move(collision.gameObject));
		}
	}

	private IEnumerator Move(GameObject gameObj)
	{
		gameObj.GetComponent<Rigidbody2D>().simulated = false;
		while (currentTime < totalTime)
		{
			currentTime += Time.deltaTime;
			foreach (var i in gameObj.GetComponentsInChildren<Renderer>())
			{
				i.material.SetFloat("_AddBrightness", currentTime / totalTime);
			}
			yield return null;
		}

		gameObj.transform.position = targetTransform.position;
		gameObj.GetComponent<Rigidbody2D>().simulated = true;
		foreach (var i in gameObj.GetComponentsInChildren<Renderer>())
		{
			i.material.SetFloat("_AddBrightness", 0);
		}
	}
}
