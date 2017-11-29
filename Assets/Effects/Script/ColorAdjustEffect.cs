using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAdjustEffect : PostEffectBase
{
	//通过Range控制可以输入的参数的范围  
	[Range(0.0f, 3.0f)]
	public float brightness = 1.0f;//亮度  
	[Range(0.0f, 3.0f)]
	public float contrast = 1.0f;  //对比度  
	[Range(0.0f, 3.0f)]
	public float saturation = 1.0f;//饱和度  
	public AnimationCurve brightnessCurve;
	//public float totalTimeT;

	private float currentTime;

	//覆写OnRenderImage函数  
	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		//仅仅当有材质的时候才进行后处理，如果material为空，不进行后处理  
		if (MyMaterial)
		{
			//通过Material.SetXXX（"name",value）可以设置shader中的参数值  
			MyMaterial.SetFloat("_Brightness", brightness);
			MyMaterial.SetFloat("_Saturation", saturation);
			MyMaterial.SetFloat("_Contrast", contrast);
			//使用Material处理Texture，dest不一定是屏幕，后处理效果可以叠加的！  
			Graphics.Blit(src, dest, MyMaterial);
		}
		else
		{
			//直接绘制  
			Graphics.Blit(src, dest);
		}
	}

	private void OnEnable()
	{
		currentTime = 0.0f;
		//totalTime = 4.0f;
		StartCoroutine(UpdateEffect());
	}

	private IEnumerator UpdateEffect()
	{
		while (currentTime < totalTime)
		{
			currentTime += Time.deltaTime;
			float t = currentTime / totalTime;
			brightness = brightnessCurve.Evaluate(t);
			yield return null;
			//brightness = 1.0f;
		}
	}

	public void PlayEffect()
	{
		StartCoroutine(UpdateEffect());
	}
}
