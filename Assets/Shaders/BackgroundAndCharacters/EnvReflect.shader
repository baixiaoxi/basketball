Shader "Basketball/CustomDiffuseDetail" {

	//Optionally Properties
    Properties {
      _Base ("Base", 2D) = "white" {}
      _Detail ("Detail", 2D) = "gray" {}
      _Cube ("Cube", Cube) = "" {}
      _Emiss ("Emiss", Float) = .5   
    }
    
    //SubShader
    SubShader {
      //double sided plane
      Pass  
      {  
      	Cull Off  
      }      
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      sampler2D _Base;
      sampler2D _Detail;	  
	  samplerCUBE _Cube;
	  float _Emiss;
	  	
	  struct Input {
	  	float2 uv_Base;
		float2 uv_Detail;
		float3 worldRefl;
		INTERNAL_DATA	
	  };
	  
      void surf (Input IN, inout SurfaceOutput o) {      	 			
     	 o.Albedo  = tex2D (_Base, IN.uv_Base).rgb * 0.5; 
      	 o.Albedo *= tex2D (_Detail, IN.uv_Detail).rgb * 2;
		 o.Alpha = tex2D(_Base, IN.uv_Base).a;
		 o.Emission = texCUBE (_Cube, WorldReflectionVector (IN, o.Normal)).rgb * _Emiss;		 
      }
      ENDCG
      
    }
        
    //Optionally Fallback 
	Fallback "Diffuse"
}