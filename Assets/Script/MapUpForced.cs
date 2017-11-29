using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUpForced : MonoBehaviour
{
	[SerializeField] private GameObject[] obj;
	[SerializeField] private GameObject targetObject;
	[SerializeField] private int upDirection;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == targetObject)
		{
			foreach (var i in obj)
			{
				i.GetComponent<MapRotate2>().Rotate(upDirection);
			}
		}
	}
}
