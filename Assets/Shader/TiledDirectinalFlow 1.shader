Shader "WbShader/Effects/Tiled Directional Flow Test" {
Properties {
 _Color ("Diffuse Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _FlowMap ("Flow", 2D) = "red" {}
 _WaterNormalMap ("Water normal", 2D) = "blue" {}
 _SkyBox ("SkyBox", CUBE) = "" {}
 _FlowSpeed ("Flow speed", Float) = 1
 _FlowTileScale ("Flow tile scale", Float) = 35
 _NormalTileScale ("Normal tile scale", Float) = 10
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