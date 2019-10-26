Shader "Custom/TerrainShader" {

	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_HeightMin("Height Min", Float) = 0
		_HeightMax("Height Max", Float) = 100
		// _ColorMin("Tint Color At Min", Color) = (0,0,0,1)
		// _ColorMax("Tint Color At Max", Color) = (1,1,1,1)
	}

	SubShader {
		Pass {
			Tags { "RenderType"="Opaque" }
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct Input {
				// float2 uv_MainTex;
				float3 worldPos;
			};

			fixed4 _ColorMin;
			fixed4 _ColorMax;
			float _HeightMin;
			float _HeightMax;

			struct v2f {
				float4 pos : SV_POSITION;
				fixed4 color : COLOR;
			};

			v2f vert(appdata_base v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				float h = (_HeightMax - worldPos.y) / (_HeightMax - _HeightMin);
				if (h >= 0.55) {
					o.color = fixed4(0.50, 0.50, 0.85, 1);
				}
				else if (h >= 0.53) {
					o.color = fixed4(0.50, 0.50, 0.15, 1);
				}
				else if (h >= 0.4) {
					o.color = fixed4(0.61, 0.77, 0.27, 1);
				}
				else if (h >= 0.2) {
					o.color = fixed4(0.38, 0.74, 0.16, 1);
				}
				else if (h >= 0.07) {
					o.color = fixed4(0.21, 0.56, 0.27, 1);
				}
				else {
					o.color = fixed4(0.95, 0.95, 0.95, 1);
				}
				// o.color = lerp(_ColorMax.rgba, _ColorMin.rgba, h);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target { return i.color; }
			ENDCG
		}
	}
	// FallBack "Diffuse"
}
