using System;
using System.Collections;
using System.Collections.Generic;
////using System.Threading.Tasks;
using UnityEngine;

public class WaitFor : MonoBehaviour
{
	[SerializeField] private float seconds;
	// Use this for initialization
	private void OnEnable()
	{
		////WaitForSeconds();
		StartCoroutine(WaitForSecond());
	}

	private IEnumerator WaitForSecond()
	{
		yield return new WaitForSeconds(seconds);
		GetComponent<LoadNextScene>().Jump2NextLevel();
	}

	////async void WaitForSeconds()
	////{
	////	await Task.Delay(Convert.ToInt32(seconds * 1000f));
	////	GetComponent<LoadNextScene>().Jump2NextLevel();
	////}
}
