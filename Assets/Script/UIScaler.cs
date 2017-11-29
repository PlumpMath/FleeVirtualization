using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaler : MonoBehaviour
{
	private void Start()
	{
		float widthS = GetComponentInParent<Canvas>().pixelRect.width;
		float heightS = GetComponentInParent<Canvas>().pixelRect.height;
		//print(GetComponent<RectTransform>().lossyScale);
		GetComponent<RectTransform>().localScale = new Vector3(1, 1920f / widthS * heightS / 1080f, 1);
	}
}
