using System.Collections;
using System.Collections.Generic;
////using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadNextScene : MonoBehaviour
{
	[SerializeField] private string nextSceneName;
	private bool canJamp = false;

	////public async void Jump2NextLevel()
	public void Jump2NextLevel()
	{
		if (canJamp == false)
		{
			return;
		}
		var effects = GameObject.Find("Main Camera").GetComponents<PostEffectBase>();
		if (effects == null)
		{
			return;
		}
		var button = GetComponent<Button>();
		if (button != null)
		{
			button.enabled = false;
		}

		foreach (var i in effects)
		{
			if (i.enabled)
			{
				i.enabled = false;
				i.enabled = true;
			}
			i.enabled = true;
		}
		float totalTime = effects[0].TotalTime;
		////await Task.Delay(Convert.ToInt32(totalTime * 1000f));
		////SceneManager.LoadScene(nextSceneName);
		StartCoroutine(LoadScene(nextSceneName, totalTime));
	}

	private IEnumerator LoadScene(string nextSceneName, float totalTime)
	{
		yield return new WaitForSeconds(totalTime);
		SceneManager.LoadScene(nextSceneName);
	}

	private void OnEnable()
	{
		canJamp = true;
	}
}
