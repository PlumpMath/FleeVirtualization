using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
	[SerializeField] Sprite[] sprite;
	private Image image;
	System.Random random;

	private void Start()
	{
		image = GetComponent<Image>();
		random = new System.Random();
	}

	public void Change()
	{
		image.sprite = sprite[random.Next(4)];
	}
}
