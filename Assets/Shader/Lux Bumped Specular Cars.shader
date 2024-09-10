Shader "Lux/Bumped Specular SpecNorm (Combined)" {
Properties {
 _Color ("Diffuse Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
 _SpecTex ("SpecNorm Color (RGB) Roughness (A)", 2D) = "white" {}
 _DiffCubeIBL ("Custom Diffuse Cube", CUBE) = "black" {}
 _SpecCubeIBL ("Custom Specular Cube", CUBE) = "black" {}
 _Glossiness ("Specular Glossiness", Float) = 0.5
 _DissolveTex ("Dissolve Map", 2D) = "white" {}
 _DissolveEdgeColor ("Dissolve Edge Color", Color) = (1,1,1,0)
 _DissolveIntensity ("Dissolve Intensity", Range(0,1)) = 0.5
 _DissolveEdgeRange ("Dissolve Edge Range", Range(0,1)) = 0.42
 _DissolveEdgeMultiplier ("Dissolve Edge Multiplier", Float) = 0
 _MainHeight ("Main Height", Float) = 0
[HideInInspector]  _Shininess ("Shininess (only for Lightmapper)", Float) = 0.5
[HideInInspector]  _AO ("Ambient Occlusion Alpha (A)", Float) = 1
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