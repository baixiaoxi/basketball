Shader "custom/doubleside" {
	Properties {
		 _Color ("Main Color", Color) = (1,1,1,1)
		 _SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 0)
		 _MainTex ("Base (RGB) TransGloss (A)", 2D) = "white" {}
		 _BumpMap ("Normalmap", 2D) = "bump" {}
		}
		
		SubShader {
		 Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		 Cull Off
		 LOD 250
		 
		CGPROGRAM
		#pragma surface surf BlinnPhong alpha
		
		sampler2D _MainTex;
		sampler2D _BumpMap;
		fixed4 _Color;
		
		struct Input{
			 float2 uv_MainTex;
			 float2 uv_BumpMap;
			 float3 viewDir;
		};
		
		void surf (Input IN, inout SurfaceOutput o) {
			 
			 fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
			 o.Albedo = tex.rgb * _Color.rgb;
			 o.Albedo *= tex.rgb;
			 o.Gloss = tex.a;
			 o.Alpha = tex.a * _Color.a;
			 o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));			 
		}
		
		ENDCG
	}

FallBack "Transparent/Parallax Specular"
}