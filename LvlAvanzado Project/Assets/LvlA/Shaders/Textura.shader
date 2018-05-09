Shader "LvlA/Textura" 
{
	Properties{
		_Tint("Color", Color) = (1, 1, 1, 1)
		_MainText("Mapa", 2D) = "White" {}
	}

		SubShader{
			Pass{
				Tags{
				"LightMode" = "ForwardBase"
				}

				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag

				#include "UnityStandardBRDF.cginc"

				float4 _Tint;
				sampler2D _MainTex;
				float4 _MainTex_ST;
					
				struct VertexData {
					float4 posicion : POSITION;
					float3 normal : NORMAL;
					float2 uv : TEXCOORD0;
				};

				struct Interpoladores {
					float4 posicion : SV_POSITION;
					float2 uv : TEXCOORD0;
					float3 normal : TEXCOORD1;
				};

				Interpoladores vert(VertexData v) {
					Interpoladores i;
					i.posicion = UnityObjectToClipPos(v.posicion);
					i.normal = UnityObjectToWorldNormal(v.normal);
					i.uv = TRANSFORM_TEX(v.uv, _MainTex);
					return i;
				}

				float4 frag(Interpoladores i) : SV_TARGET{
					i.normal = normalize(i.normal);
					float3 lightDir = _WorldSpaceLightPos0.xyz;
					float3 lightColor = _LightColor0.rgb;
					float3 albedo = tex2D(_MainTex, i.uv).rgb * _Tint.rgb;
					float3 diffuse = albedo * lightColor * DotClamped(lightDir, i.normal);
					return float4(diffuse, 1);
				}

			ENDCG
		}
	}
}
