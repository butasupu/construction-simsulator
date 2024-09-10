Shader "WbShader/People/People Mask_SpecNorm" {
Properties {
 _Color ("Diffuse Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _SpecTex ("Specular(RGB) Gloss(A)", 2D) = "white" {}
 _Shininess ("Specular Sharpness", Float) = 0.5
 _Glossiness ("Specular Glossiness", Float) = 0.5
 _ColorCloth ("_ColorCloth Color", Color) = (1,1,1,1)
 _ColorHair ("_ColorHair Color", Color) = (1,1,1,1)
 _ColorEye ("_ColorEye Color", Color) = (1,1,1,1)
 _ColorShoe ("_ColorShoe Color", Color) = (1,1,1,1)
 _DiffCubeIBL ("Custom Diffuse Cube", CUBE) = "black" {}
 _SpecCubeIBL ("Custom Specular Cube", CUBE) = "black" {}
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