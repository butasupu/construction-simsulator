Shader "WbShader/Sky/Animated Sky" {
Properties {
 _Tint ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
 _Tex ("Cubemap", CUBE) = "white" {}
 _Tex2 ("Cubemap", CUBE) = "white" {}
 _RotationSpeed ("_RotationSpeed name", Vector) = (0,0,0,0)
 _Translation ("_Translation name", Vector) = (0,0,0,0)
 _Speed ("_Speed name", Float) = 0
 _HalfCycle ("_HalfCycle name", Float) = 0
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