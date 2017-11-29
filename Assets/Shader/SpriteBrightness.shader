Shader "Custom/SpriteBrightness" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_AddBrightness ("AddBrightness", float) = 1
		
		//[PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
	}

	SubShader 
	{
		Tags
		{ 
			"Queue"="Transparent" 
		//	"IgnoreProjector"="True" 
		//	"RenderType"="Transparent" 
		//	"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}
		Pass
		{
			//设置一些渲染状态，此处先不详细解释
			ZTest Always
			Cull Off
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			
			CGPROGRAM
			//在Properties中的内容只是给Inspector面板使用，真正声明在此处，注意与上面一致性
			sampler2D _MainTex;
			//sampler2D _AlphaTex;
			float _AddBrightness;

			//vert和frag函数
			#pragma vertex vert_img
			#pragma fragment frag
			#include "Lighting.cginc"
			
			//fragment shader
			fixed4 frag(v2f_img i) : SV_Target
			{
				//从_MainTex中根据uv坐标进行采样
				fixed4 renderTex = tex2D(_MainTex, i.uv);
				fixed3 finalColor = renderTex + _AddBrightness;
				//fixed alpha = tex2D (_AlphaTex, i.uv).a;
				//返回结果，alpha通道不变
				return fixed4(finalColor.rgb, renderTex.a);
				//return fixed4(0.1, 0.1, 0.1, alpha);
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
