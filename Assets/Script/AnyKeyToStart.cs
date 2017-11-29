using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LoadNextScene))]
public class AnyKeyToStart : MonoBehaviour
{
	private void Update()
	{
		if (Input.anyKeyDown)
		{
			GetComponent<LoadNextScene>().Jump2NextLevel();
		}
	}
}
