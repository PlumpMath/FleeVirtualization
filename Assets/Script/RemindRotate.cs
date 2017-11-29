using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemindRotate : MonoBehaviour
{
	[SerializeField] private GameObject text;
	[SerializeField] private GameObject image;
	private float showTime = 3f;
	private float currentTime;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player2D")
		{
			text.GetComponent<ReminedEnable>().enabled = true;
			image.GetComponent<ReminedEnable>().enabled = true;
			StartCoroutine(Hide());
		}
	}

	private IEnumerator Hide()
	{
		currentTime = 0;
		while (currentTime < showTime)
		{
			currentTime += Time.deltaTime;
			yield return null;
		}
		text.GetComponent<ReminedEnable>().enabled = false;
		image.GetComponent<ReminedEnable>().enabled = false;
	}
}
