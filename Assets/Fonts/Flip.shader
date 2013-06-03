Shader "YSET/FlipCard"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
		_NumTex("number 0, Alpha (A)", 2D) = "white" {}
	}	
	
	SubShader
	{
		LOD 100
		Tags{"Queue" = "Transparent"}
				
		Pass
		{
			Cull back
			Blend SrcAlpha OneMinusSrcAlpha
			
			SetTexture [_MainTex]
			{
				combine texture
			}	
		}
		
		Pass
		{
			Cull back
			Blend SrcAlpha OneMinusSrcAlpha
			
			SetTexture [_NumTex]
			{
				combine texture
			}
		}
	}
}