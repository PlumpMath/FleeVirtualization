using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimMotor : MonoBehaviour
{
	[SerializeField] private float angleSpeed;
	// Use this for initialization

	// Update is called once per frame
	void Update()
	{
		//transform.Rotate(new Vector3(0, 0, Time.deltaTime * angleSpeed));
		transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + Time.deltaTime * angleSpeed);
		//transform.localScale = Vector3.one;
	}
}
