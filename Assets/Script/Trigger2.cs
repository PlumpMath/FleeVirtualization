using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger2 : MonoBehaviour
{
	[SerializeField] private GameObject targetObject;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == targetObject)
		{
			GameObject.Find("Map").GetComponent<MapRotate2>().EnableR = true;
			GameObject.Find("Environment").GetComponent<MapRotate2>().EnableR = true;
			StartCoroutine(GoToBlur());
		}
	}

	private IEnumerator GoToBlur()
	{
		while (!Input.GetKeyDown(KeyCode.R))
		{
			yield return null;
		}
		GameObject.Find("Main Camera").GetComponent<GrayBlurEffect>().enabled = true;
		GameObject.Find("Text").GetComponent<Text>().text = "!  !  !";
	}
}
