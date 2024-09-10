Shader "WbShader/Ground/Digging Plane" {
Properties {
 _Color ("Diffuse Color", Color) = (1,1,1,1)
 _MainTex ("Vertex Color Black", 2D) = "white" {}
 _MainTexNorm ("Vertex Color Black Norm", 2D) = "bump" {}
 _Splat1 ("Vertex Color Red", 2D) = "white" {}
 _Splat1Norm ("Vertex Color Red Norm", 2D) = "bump" {}
 _Splat2 ("Vertex Color Alpha", 2D) = "white" {}
 _Splat2Norm ("Vertex Color Alpha Norm", 2D) = "bump" {}
 _Splat3 ("Vertex Color Blue", 2D) = "white" {}
 _Splat3Norm ("Vertex Color Blue Norm", 2D) = "bump" {}
 _Splat4 ("Vertex R + worldNormal", 2D) = "white" {}
 _Splat4Norm ("Vertex R + worldNormal Norm", 2D) = "bump" {}
 _scale ("UV Scale", Float) = 1
 _scaleSplat1 ("Vertex Color Black 1 Scale", Float) = 1
 _scaleSplat2 ("Vertex Color Red 2 Scale", Float) = 1
 _scaleSplat3 ("Vertex Color Alpha 3 Scale", Float) = 1
 _scaleSplat4 ("Vertex Color Blue 4 Scale", Float) = 1
 _scaleSplat5 ("Vertex R + worldNormal 5 Scale", Float) = 1
 _sharpness01 ("Splat1 Sharpness", Float) = 1
 _sharpness02 ("Splat2 Sharpness", Float) = 1
 _sharpness03 ("Splat3 Sharpness", Float) = 1
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