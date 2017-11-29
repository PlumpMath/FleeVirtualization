Shader "Custom/GrayBlurEffect"
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_VignetteTex ("Vignette Texture", 2D) = "white" {}
	}
	SubShader 
	{
		Pass 
		{
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			uniform sampler2D _MainTex;
			uniform sampler2D _VignetteTex;
			float4 _offsets;
			float4 _MainTex_TexelSize;

			struct v2f_blur
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 uv01 : TEXCOORD1;
				float4 uv23 : TEXCOORD2;
				float4 uv45 : TEXCOORD3;
			};
			
			v2f_blur vert (appdata_img v)
			{
				v2f_blur o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord.xy;

				_offsets *= _MainTex_TexelSize.xyxy;//计算一个偏移值，offset可能是（0，1，0，0）也可能是（1，0，0，0）这样就表示了横向或者竖向取像素周围的点
			
				//由于uv可以存储4个值，所以一个uv保存两个vector坐标，_offsets.xyxy * float4(1,1,-1,-1)可能表示(0,1,0-1)，表示像素上下两个
				//坐标，也可能是(1,0,-1,0)，表示像素左右两个像素点的坐标，下面*2.0，*3.0同理
				o.uv01 = v.texcoord.xyxy + _offsets.xyxy * float4(1, 1, -1, -1);
				o.uv23 = v.texcoord.xyxy + _offsets.xyxy * float4(1, 1, -1, -1) * 2.0;
				o.uv45 = v.texcoord.xyxy + _offsets.xyxy * float4(1, 1, -1, -1) * 3.0;

				return o;
			}

			fixed4 frag(v2f_blur i) : COLOR 
			{
				fixed4 renderTex = tex2D(_MainTex, i.uv);
				fixed4 vignetteTex = tex2D(_VignetteTex, i.uv);
				fixed lum = dot(fixed3(0.299, 0.587, 0.114), vignetteTex.rgb);

				//fixed4 finalColor = renderTex;
				//fixed4 finalColor = fixed4(lum, lum, lum, 1);
				fixed4 finalColor = (0.4 + 0.6 * lum) * tex2D(_MainTex, i.uv);
				finalColor += (-0.15 * lum + 0.15) * tex2D(_MainTex, i.uv01.xy);
				finalColor += (-0.15 * lum + 0.15) * tex2D(_MainTex, i.uv01.zw);
				finalColor += (-0.1 * lum + 0.1) * tex2D(_MainTex, i.uv23.xy);
				finalColor += (-0.1 * lum + 0.1) * tex2D(_MainTex, i.uv23.zw);
				finalColor += (-0.05 * lum + 0.05) * tex2D(_MainTex, i.uv45.xy);
				finalColor += (-0.05 * lum + 0.05) * tex2D(_MainTex, i.uv45.zw);

				return finalColor;
			}

			ENDCG
		}
	} 
	FallBack "Diffuse"
}
