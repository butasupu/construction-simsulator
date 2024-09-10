Shader "WbShader/Effects/Streaky Reflection" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _StreakyTex ("Streaky Tex (RGB) Trans (A)", 2D) = "white" {}
 _Intensity ("Illumination Intensity", Range(0,1)) = 1
 _Rim ("Side Fading", Float) = 0
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