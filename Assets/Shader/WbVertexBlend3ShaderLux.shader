Shader "WbShader/Blend/Vertex Detail Blend 3" {
Properties {
 _Color ("Diffuse Color", Color) = (1,1,1,1)
 _SpecColor ("Specular Color", Color) = (1,1,1,1)
 _SpecInt ("Specular Intensity", Float) = 1
 _Shininess ("Specular Sharpness", Range(2,8)) = 4
 _Fresnel ("Fresnel Strength", Range(0,1)) = 0
 _MainTex ("Splat Tex 01 (Base)", 2D) = "white" {}
 _NormTex ("Splat Tex Norm 01", 2D) = "white" {}
 _MainTex2 ("Splat Tex 02 (R)", 2D) = "white" {}
 _NormTex2 ("Splat Tex Norm 03", 2D) = "white" {}
 _MainTex3 ("Splat Tex 03 (R)", 2D) = "white" {}
 _NormTex3 ("Splat Tex Norm 02", 2D) = "white" {}
 _scale ("UV Scale", Float) = 1
 _scaleSplat1 ("Splat1 Scale", Float) = 1
 _scaleSplat2 ("Splat2 Scale", Float) = 1
 _scaleSplat3 ("Splat3 Scale", Float) = 1
 _sharpness01 ("Splat1 Sharpness", Float) = 1
 _sharpness02 ("Splat2 Sharpness", Float) = 1
 _DiffCubeIBL ("Custom Diffuse Cube", CUBE) = "black" {}
 _SpecCubeIBL ("Custom Specular Cube", CUBE) = "black" {}
[HideInInspector]  _Shininess ("Shininess (only for Lightmapper)", Float) = 0.5
[HideInInspector]  _AO ("Ambient Occlusion Alpha (A)", 2D) = "white" {}
}
	//DummyShaderTextExporter
	
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard fullforwardshadows
#pragma target 3.0
		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
		}
		ENDCG
	}
}