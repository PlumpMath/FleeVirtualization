using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReminedEnable : MonoBehaviour
{
	[SerializeField] private float width = 1475;
	[SerializeField] private float height = 150;
	private float totalTime = 0.5f;
	private float currentTime = 0f;

	private void OnEnable()
	{
		currentTime = 0;
		StartCoroutine(Show());
	}

	private IEnumerator Show()
	{
		var rectTransform = GetComponent<RectTransform>();
		while (currentTime < totalTime)
		{
			//print(currentTime);
			currentTime += Time.deltaTime;
			rectTransform.sizeDelta = new Vector2(width * currentTime / totalTime, height);
			yield return null;
		}
	}

	private void OnDisable()
	{
		GetComponent<RectTransform>().sizeDelta = Vector2.zero;
	}
}
