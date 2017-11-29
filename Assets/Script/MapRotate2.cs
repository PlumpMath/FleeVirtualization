using System.Collections;
using System.Collections.Generic;
//using System.Threading.Tasks;
using UnityEngine;

public class MapRotate2 : MonoBehaviour
{
	[SerializeField] private Transform targetTransform;
	[SerializeField] private bool enableR;
	private new GameObject camera;

	public bool EnableR
	{
		get
		{
			return enableR;
		}

		set
		{
			enableR = value;
		}
	}

	private void Start()
	{
		camera = GameObject.Find("Main Camera");
	}

	void Update()
	{
		if (enableR && Input.GetKeyDown(KeyCode.R))
		{
			//camera.GetComponent<RotationDistortEffect>().StartPassThoughEffect();
			Rotate();
			//transform.RotateAround(targetTransform.position, Vector3.back, 90f);
		}
	}

	public void Rotate()
	{
		camera.GetComponent<WaterWaveEffect>().enabled = true;
		//await Task.Delay(500);
		transform.RotateAround(targetTransform.position, Vector3.back, 90f);
	}

	public void Rotate(int targetZ)
	{
		while (transform.rotation.eulerAngles.z != targetZ)
		{
			camera.GetComponent<WaterWaveEffect>().enabled = true;
			//await Task.Delay(500);
			transform.RotateAround(targetTransform.position, Vector3.back, 90f);
		}
	}
}
