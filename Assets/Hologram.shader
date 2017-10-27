// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Hologram"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color("Diffuse Material Color", Color) = (1,1,1,1)
		_SpecColor("Specular Material Color", Color) = (1,1,1,1)
		_Shininess("Shininess", Float) = 10
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100

			Pass
			{
				Tags{"LightMode" = "ForwardBase"}
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog

			#include "UnityCG.cginc"
			uniform float4 _LightColor0;
			uniform float4 _SpecColor;
			uniform float _Shininess;
			uniform float4 _Color;
			uniform sampler2D _MainTex;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float2 uv     : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 col : COLOR;
				float3 nor[3] : NORMAL; // 0 - norm, 1 - normalDir, 2 - viewDir
				float2 uv  : TEXCOORD0;
			};

			vertexOutput vert(vertexInput input)
			{
				vertexOutput output;

				float4x4 modelMatrix = unity_ObjectToWorld;
				float3x3 modelMatrixInvert = unity_WorldToObject;
				output.nor[1] = normalize(mul(input.normal, modelMatrixInvert));
				//float3 normalDirection = normalize(modelMatrixInvert * input.normal);



				output.nor[2] = normalize(_WorldSpaceCameraPos - mul(modelMatrix, input.vertex).xyz);


				//output.pos = UnityObjectToClipPos(input.pos);
				output.nor[0] = normalize(UnityObjectToClipPos(input.normal));
				output.pos = UnityObjectToClipPos(input.vertex);
				output.uv = input.uv;
				return output;
			}

			float4 frag(vertexOutput input) : COLOR
			{



				float3 lightDirection;
				float attenuation;

				if (0.0 == _WorldSpaceLightPos0.w)
				{
					attenuation = 1.0;
					lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				}
				else
				{
					float3 vertexToLightSource = _WorldSpaceLightPos0.xyz;
					float distance = length(vertexToLightSource);
					attenuation = 1.0 / distance;
					lightDirection = normalize(vertexToLightSource);
				}

				float3 ambientLighting = UNITY_LIGHTMODEL_AMBIENT.rgb * _Color.rgb;

				float3 diffuseReflection =
					attenuation * _LightColor0.rgb * _Color.rgb
				*max(0.0, dot(input.nor[1], lightDirection));

				float3 specularReflection;
				if (dot(input.nor[1], lightDirection) < 0.0)
				{
					specularReflection = float3(0.0, 0.0, 0.0);
				}
				else
				{
					specularReflection = attenuation * _LightColor0.rgb
						* _SpecColor.rgb * pow(max(0.0, dot(reflect(-lightDirection, input.nor[1]), input.nor[2])), _Shininess);

				}


				input.col = float4(diffuseReflection + specularReflection, 1.0);


				return input.col * tex2D(_MainTex, input.uv);


			}



				//
				//struct appdata
				//{
				//	float4 vertex : POSITION;
				//	float2 uv : TEXCOORD0;
				//};

				//struct v2f
				//{
				//	float2 uv : TEXCOORD0;
				//	UNITY_FOG_COORDS(1)
				//	float4 vertex : SV_POSITION;
				//};

				//sampler2D _MainTex;
				//float4 _MainTex_ST;
				//
				//v2f vert (appdata v)
				//{
				//	v2f o;
				//	o.vertex = UnityObjectToClipPos(v.vertex);
				//	o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				//	UNITY_TRANSFER_FOG(o,o.vertex);
				//	return o;
				//}
				//
				//fixed4 frag (v2f i) : SV_Target
				//{
				//	// sample the texture
				//	fixed4 col = tex2D(_MainTex, i.uv);
				//	// apply fog
				//	UNITY_APPLY_FOG(i.fogCoord, col);
				//	
				//	return col;
				//}
				ENDCG
				}
	Pass{
				Tags{ "LightMode" = "ForwardAdd" }
				// pass for additional light sources
				Blend One One // additive blending 

				CGPROGRAM

				#pragma vertex vert  
				#pragma fragment frag 

				#include "UnityCG.cginc"
				uniform float4 _LightColor0;
			// color of light source (from "Lighting.cginc")

			// User-specified properties
			uniform float4 _Color;
			uniform float4 _SpecColor;
			uniform float _Shininess;
			uniform sampler2D _MainTex;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float2 uv     : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 col : COLOR;
				float3 nor[3] : NORMAL; // 0 - norm, 1 - normalDir, 2 - viewDir
				float2 uv  : TEXCOORD0;
			};

			vertexOutput vert(vertexInput input)
			{
				vertexOutput output;

				float4x4 modelMatrix = unity_ObjectToWorld;
				float3x3 modelMatrixInvert = unity_WorldToObject;
				output.nor[1] = normalize(mul(input.normal, modelMatrixInvert));
				//float3 normalDirection = normalize(modelMatrixInvert * input.normal);



				output.nor[2] = normalize(_WorldSpaceCameraPos - mul(modelMatrix, input.vertex).xyz);


				//output.pos = UnityObjectToClipPos(input.pos);
				output.nor[0] = normalize(UnityObjectToClipPos(input.normal));
				output.pos = UnityObjectToClipPos(input.vertex);
				output.uv = input.uv;
				return output;
			}

			float4 frag(vertexOutput input) : COLOR
			{



				float3 lightDirection;
			float attenuation;

			if (0.0 == _WorldSpaceLightPos0.w)
			{
				attenuation = 1.0;
				lightDirection = normalize(_WorldSpaceLightPos0.xyz);
			}
			else
			{
				float3 vertexToLightSource = _WorldSpaceLightPos0.xyz;
				float distance = length(vertexToLightSource);
				attenuation = 1.0 / distance;
				lightDirection = normalize(vertexToLightSource);
			}

			float3 ambientLighting = UNITY_LIGHTMODEL_AMBIENT.rgb * _Color.rgb;

			float3 diffuseReflection =
				attenuation * _LightColor0.rgb * _Color.rgb
				*max(0.0, dot(input.nor[1], lightDirection));

			float3 specularReflection;
			if (dot(input.nor[1], lightDirection) < 0.0)
			{
				specularReflection = float3(0.0, 0.0, 0.0);
			}
			else
			{
				specularReflection = attenuation * _LightColor0.rgb
					* _SpecColor.rgb * pow(max(0.0, dot(reflect(-lightDirection, input.nor[1]), input.nor[2])), _Shininess);

			}


			input.col = float4(diffuseReflection + specularReflection, 1.0);


			return input.col * tex2D(_MainTex, input.uv);

			
			}
				ENDCG
			}
			
		}
		Fallback "Specular"
}