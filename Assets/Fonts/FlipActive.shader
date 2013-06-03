Shader "YSET/FlipCardActive"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
		_NumTex0("number 0, Alpha (A)", 2D) = "white" {}
		_NumTex1("number 1, Alpha (A)", 2D) = "white"{}
	}	
	
	CGINCLUDE
		sampler2D _NumTex0;
		sampler2D _MainTex;
			
		struct vertOut
		{
			float2 invertTexCoord : TEXCOORD0;
			float4 position : POSITION;
		};
			
		vertOut vert(float4 position : POSITION, float2 tex : TEXCOORD0)
		{
			vertOut OUT;
			OUT.position = mul(UNITY_MATRIX_MVP, position);
			
			// 这里的0.005f * resH与flip.cs等脚本中的偏移量应该保持一致。
			OUT.invertTexCoord = float2(tex.x, 1 - tex.y + 0.005f * 12);
			return OUT;
		}
			
		struct fragOut
		{
			float4 color : COLOR;
		};
			
		fragOut frag(float2 tex : TEXCOORD0)
		{
			fragOut OUT;
			half4 sourceColor = tex2D(_NumTex0, tex);
			half4 desColor = tex2D(_MainTex, tex);
			OUT.color = desColor * ( 1 - sourceColor.a ) + sourceColor * sourceColor.a;
			return OUT;
		}
	ENDCG
	
	SubShader
	{
		LOD 100
		Tags{"Queue" = "Transparent+1"}
		
		Pass
		{
			Cull front	
			Blend One Zero
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}
		
		Pass
		{
			Cull Back
			Blend One Zero
			
			SetTexture [_MainTex]
			{
				combine texture
			}
		}
		
		Pass
		{
			Cull Back
			Blend SrcAlpha OneMinusSrcAlpha
						
			SetTexture [_NumTex1]
			{
				combine texture
			}
		}
	}
}