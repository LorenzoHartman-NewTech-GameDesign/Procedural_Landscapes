Shader "Doloro Ent/Snow - Linear" { 
	Properties { 
		[Toggle(REDIFY_ON)] _NoiseOn("Noise effect", Int) = 0
		_NoiseCutOut ("Noise cutout", Range(0,1)) = 1
		_NormalMap("Normal", 2D) = "white" {}
		_Color0("Main tint", Color) = (0.6784,0.6784,0.6784,1)
		_Color1("Emission tint", Color) = (0.847,0.8823,0.8823,1)
		[HideInInspector]_Variable0("Scale", float) = 100
		_BRDFTex ("BRDF Texture", 2D) ="white" {}
		_SpecularColor ("Specular Color", Color ) = (0.0666,0.0666,0.0666,1)
		_SpecPower ("Specular Power", Range (0.01, 100)) = 12
		_Brightnes ("Brightnes", Range (0, 1)) = 1
		_Variable1("Emission", Range (0, 0.5)) = 0.24
	}
	SubShader {
		Tags {
			"Queue" = "Geometry"
			"RenderType" = "Opaque"
		}
		SeparateSpecular On
		LOD 300

		CGPROGRAM 
		#pragma surface surf Loose halfasview approxview 
		#pragma target 3.0
		#include "UnityCG.cginc"

		sampler2D _NormalMap;
		float4 _Color0;
		float4 _Color1;
		float _Variable0;
		float _Variable1;
		float _TessMultiplier;
		float _Displacement;
		sampler2D _DispMap;
		uniform float4 _DispMap_ST;
		fixed _SpecPower;
		fixed _DiffusePower;
		sampler2D _BRDFTex;
		fixed4 _SpecularColor;
		float _Brightnes;
		int _NoiseOn;
		fixed _NoiseCutOut;

		struct appdata{
			float4 vertex    : POSITION;  // The vertex position in model space.
			float3 normal    : NORMAL;    // The vertex normal in model space.
			float4 texcoord  : TEXCOORD0; // The first UV coordinate.
			float4 texcoord1 : TEXCOORD1; // The second UV coordinate.
			float4 texcoord2 : TEXCOORD2; // The third UV coordinate.
			float4 tangent   : TANGENT;   // The tangent vector in Model Space (used for normal mapping).
			float4 color     : COLOR;     // Per-vertex color.
		};

		struct Input{
			float2 uv_NormalMap;
			float2 uv_Tex1;
			float3 viewDir;
			float3 worldPos;
			float3 worldRefl;
			float3 worldNormal;
			float4 screenPos;
			float4 color : COLOR;

			INTERNAL_DATA
		};
		
		inline float4 LightingLoose (SurfaceOutput s, fixed3 lightDir, half3 viewDir, fixed atten)
		{
			half3 h = normalize( lightDir + viewDir );
			fixed diff = max( 0.5, dot(s.Normal, lightDir) );

			float ahdn = pow( clamp(1.0 - dot ( h, normalize(s.Normal) ), 0.0, 1.0), _DiffusePower );
			half4 brdf = tex2D(_BRDFTex, float2(diff, 1 - ahdn));
			
			float nh = max( 0, dot(s.Normal, h) );
			float spec = pow(nh, s.Specular * _SpecPower) * s.Gloss;

			float4 col;
			col.rgb = ( s.Albedo * _LightColor0.rgb * brdf.rgb + _LightColor0.rgb * _SpecularColor.rgb * spec ) *  atten * 2.5 ;
			col.a = s.Alpha + _LightColor0.a * _SpecularColor.a * spec * atten;
			
			float ldn = normalize(viewDir);
			float4 additive = float4(0,0,0,0);	
			if(_NoiseOn)
			{		
				float checkVar3 = frac(sin( dot(s.Normal ,lightDir )) * 438.5453);
				if(checkVar3 > 0.99)
					additive += float4(lerp(float4(s.Albedo, s.Alpha), _Color1, float4(s.Normal,1.0f))) / 5;
				else if(checkVar3 > 0.7)
					additive += float4(lerp(float4(s.Albedo, s.Alpha), _Color1, float4(s.Normal,1.0f))) / 10;
				else if(checkVar3 > 0.5)
					additive += float4(lerp(float4(s.Albedo, s.Alpha), _Color1, float4(s.Normal,1.0f))) / 12;
				else if(checkVar3 > 0.3)
					additive += float4(lerp(float4(s.Albedo, s.Alpha), _Color1, float4(s.Normal,1.0f))) / 15;
				else if(checkVar3 > 0.1)
					additive += float4(lerp(float4(s.Albedo, s.Alpha), _Color1, float4(s.Normal,1.0f))) / 20;
					
				//col += additive;
				col = lerp(col, col + additive, _NoiseCutOut);
			}
							
			return col;
		}
		
		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = _Color0.rgb + lerp(0, 0.6f, normalize(IN.screenPos) * _Brightnes);
			o.Albedo *= 5;
			o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap * _Variable0));			
			o.Emission = _Variable1;
			o.Specular = 1;
			o.Alpha = _Color0.a;
			o.Gloss = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
