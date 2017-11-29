using System;
using System.Collections;
using System.Collections.Generic;
////using System.Threading.Tasks;
using UnityEngine;

public class MyTimeLine : MonoBehaviour
{
	[SerializeField] private float enterTime;
	[SerializeField] private float exitTime;
	[SerializeField] private new GameObject camera;
	[SerializeField] private GameObject nextFrame;
	private ColorAdjustEffect effect;
	public float totalTime = 2f;

	private void Start()
	{
		effect = camera.GetComponent<ColorAdjustEffect>();
		Run();
	}

	////private async void Run()
	////{
	////	print(123456);
	////	effect.TotalTime = exitTime;
	////	await Task.Delay(Convert.ToInt32(totalTime * 1000));
	////	if (nextFrame == null)
	////	{
	////		camera.GetComponent<LoadNextScene>().Jump2NextLevel();
	////		effect.TotalTime = camera.GetComponent<RotationDistortEffect>().TotalTime;
	////		effect.enabled = true;
	////		return;
	////	}
	////	effect.brightness = 1;
	////	effect.enabled = true;
	////	await Task.Delay(Convert.ToInt32(exitTime * 1000));
	////	effect.brightness = 1;
	////	nextFrame.SetActive(true);
	////	effect.enabled = false;
	////	gameObject.SetActive(false);
	////}

	private void Run()
	{
		effect.TotalTime = exitTime;
		StartCoroutine(Run2());
	}
	
	private IEnumerator Run2()
	{
		yield return new WaitForSeconds(totalTime);
		if (nextFrame == null)
		{
			camera.GetComponent<LoadNextScene>().Jump2NextLevel();
			effect.TotalTime = camera.GetComponent<RotationDistortEffect>().TotalTime;
			effect.enabled = true;
			yield return null;
		}
		effect.brightness = 1;
		effect.enabled = true;
		StartCoroutine(Run3());
	}
	
	private IEnumerator Run3()
	{
		yield return new WaitForSeconds(exitTime);
		effect.brightness = 1;
		nextFrame.SetActive(true);
		effect.enabled = false;
		gameObject.SetActive(false);
	}
}
