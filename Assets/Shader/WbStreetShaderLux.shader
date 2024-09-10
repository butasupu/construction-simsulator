Shader "WbShader/Ground/Street" {
Properties {
 _MainTex ("Base Tex", 2D) = "white" {}
 _NormTex ("Base Tex NORM", 2D) = "bump" {}
 _usageTex1 ("Usage Tex 01", 2D) = "white" {}
 _usageTex2 ("Usage Tex 02", 2D) = "white" {}
 _NormTex2 ("Texture", 2D) = "bump" {}
 _markingsTexIn ("Markings In", 2D) = "white" {}
 _NormTex3 ("Texture", 2D) = "white" {}
 _markingsTexOut ("Markings Out", 2D) = "white" {}
 _NormTex4 ("Texture", 2D) = "white" {}
 _cracksTex01 ("Cracks 01", 2D) = "white" {}
 _NormTex5 ("Texture", 2D) = "white" {}
 _cracksTex02 ("Cracks 02", 2D) = "white" {}
 _NormTex6 ("Texture", 2D) = "white" {}
 _tilingTex ("Tiling", 2D) = "white" {}
 _NormTex7 ("Texture", 2D) = "white" {}
 _NoiseTex ("NOISE", 2D) = "white" {}
 _concreteScale ("UV Scale", Float) = 1
 _cracksScale ("Splat1 Scale", Float) = 1
 _tilingMultiplier ("Splat2 Scale", Float) = 1
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