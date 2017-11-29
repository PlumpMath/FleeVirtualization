Shader "Custom/ColorNoise"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_NoiseTex ("Texture", 2D) = "white" {}
		_NoiseSpeed ("Noise Speed", float) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;
			sampler2D _NoiseTex;
			float _NoiseSpeed;
			float4 _NoiseTex_ST;
			
			struct appdata
			{
				float4 vert : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vert : POSITION;
				float2 uv : TEXCOORD0;
				float2 noiseUv : TEXCOORD1;
			};

			v2f vert(appdata i)
			{
				v2f o;
				float2 noiseUv = i.uv;
				noiseUv.y += (_Time.y % 5) * _NoiseSpeed;
				noiseUv.x += (_Time.y % 5) * _NoiseSpeed;
				o.vert = UnityObjectToClipPos(i.vert);
				o.uv = i.uv;
				o.noiseUv = TRANSFORM_TEX(noiseUv, _NoiseTex);
				return o;
			}

			fixed4 frag (v2f_img i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				col += _SinTime.w * 0.3;
				return col;
			}
			ENDCG
		}
	}
}
