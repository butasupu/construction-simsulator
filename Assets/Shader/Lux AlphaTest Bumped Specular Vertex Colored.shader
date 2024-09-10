Shader "Lux/Cutout/Bumped Specular Vertex Colored Multiply" {
Properties {
 _Color ("Diffuse Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
 _SpecTex ("Specular Color (RGB) Roughness (A)", 2D) = "black" {}
 _Fresnel ("Fresnel Strength", Float) = 0.2
 _BumpMap ("Normalmap", 2D) = "bump" {}
 _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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