using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCount : MonoBehaviour
{
	private int triggerCount = 0;
	[SerializeField] private Transform targetPosition;
	[SerializeField] private GameObject back;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.gameObject.name.Contains("Player")) return;
		triggerCount++;
		if (triggerCount > 3)
		{
			GetComponent<LoadNextScene>().enabled = true;
			GetComponent<LoadNextScene>().Jump2NextLevel();
		}
		else
		{
			var effect = GameObject.Find("Main Camera").GetComponent<RotationDistortEffect>();
			if (effect.enabled)
			{
				effect.StartPassThoughEffect();
			}
			else
			{
				effect.enabled = true;
			}

			switch (triggerCount)
			{
			case 1:
				{
					print(1);
					GameObject.Find("Text").GetComponent<SetText>().Set("这个世界好像不大对...");
					break;
				}
			case 2:
				{
					print(2);
					GameObject.Find("Text").GetComponent<SetText>().Set("我不是沉浸到虚拟现实中睡着了吗？！");
					break;
				}
			case 3:
				{
					print(3);
					GameObject.Find("Text").GetComponent<SetText>().Set("门后面是现实还是更真实的虚拟？");
					break;
				}
			default:
				break;
			}

			collision.gameObject.transform.position = targetPosition.position;
			back.GetComponent<BackgroundChange>().Change();
		}
	}
}
