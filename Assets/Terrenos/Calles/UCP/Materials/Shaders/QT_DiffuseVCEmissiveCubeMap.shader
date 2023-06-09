Shader "QuantumTheory/Self-Illumin/QT_DiffuseVCEmissiveCubeMap"
{
	Properties 
	{
_MainTex("Diffuse", 2D) = "white" {}
_Illum("Self Illumination Mask (A)", 2D) = "black" {}
_CubeMap("CubeMap Reflection", Cube) = "black" {}
_EmissionLM("Emission Max Strength (Beast)", Float) = 20

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Geometry"
"IgnoreProjector"="False"
"RenderType"="Opaque"

		}

		
Cull Back
ZWrite On
ZTest LEqual
ColorMask RGBA
Fog{
}


		CGPROGRAM
#pragma surface surf BlinnPhongEditor  vertex:vert
#pragma target 2.0


sampler2D _MainTex;
sampler2D _Illum;
samplerCUBE _CubeMap;
float _EmissionLM;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
half3 spec = light.a * s.Gloss;
half4 c;
c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
c.a = s.Alpha;
return c;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input {
				float2 uv_MainTex;
float4 color : COLOR;
float2 uv_Illum;
float3 viewDir;

			};

			void vert (inout appdata_full v, out Input o) {
float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);


			}
			

			void surf (Input IN, inout EditorSurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
float4 Tex2D0=tex2D(_MainTex,(IN.uv_MainTex.xyxy).xy);
float4 Multiply1=IN.color * float4( 2,2,2,2 );
float4 Multiply0=Tex2D0 * Multiply1;
float4 Tex2D1=tex2D(_Illum,(IN.uv_Illum.xyxy).xy);
float4 Split1=float4( IN.viewDir.x, IN.viewDir.y,IN.viewDir.z,1.0 );
float4 Multiply6=float4( Split1.y, Split1.y, Split1.y, Split1.y) * float4( -1,-1,-1,-1 );
float4 Assemble1=float4(float4( Split1.x, Split1.x, Split1.x, Split1.x).x, Multiply6.y, float4( Split1.z, Split1.z, Split1.z, Split1.z).z, float4( Split1.w, Split1.w, Split1.w, Split1.w).w);
float4 TexCUBE0=texCUBE(_CubeMap,Assemble1);
float4 Multiply3=Tex2D1 * TexCUBE0;
float4 Add0=Multiply0 + Multiply3;
float4 Multiply2=Multiply0 * Tex2D1;
float4 Master0_1_NoInput = float4(0,0,1,1);
float4 Master0_3_NoInput = float4(0,0,0,0);
float4 Master0_4_NoInput = float4(0,0,0,0);
float4 Master0_5_NoInput = float4(1,1,1,1);
float4 Master0_7_NoInput = float4(0,0,0,0);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Albedo = Add0;
o.Emission = Multiply2;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}