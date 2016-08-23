Shader "Custom/ItemGlow" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_ColorTint ("Color Tint",Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpMap ("Norma lMap",2D) = "bump" {}
		_RimColor("Rim Color",Color) = (1,1,1,1)
		_RimPower("Rim Power",Range(1.0,6.0)) = 3.0 

		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }

		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0



		struct Input {
			float4 color : Color
			float2 uv_MainTex;
			float2 uv_MumpMap;
			float3 viewDir;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		float4 _ColorTint;
		sampler2D _MainTex;
		sampler2D _BumpMap;
		float4 _RimColor;
		float _RimPower;


		void surf (Input IN, inout SurfaceOutputStandard o) {
			IN.color = _ColorTint;
			o.Albedo = text2D(_MainTex,IN.uv_MainTex).rgb * IN.color;
			o.Normal = UnpackNormal(tex2D(_BumpMap,IN.uv_BumpMap));
			half rim = saturate(dot(normalize(IN.viewDir),o.normal));
			o.Emission = _RimColor.rgb * pow(rim,_RimPower);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
