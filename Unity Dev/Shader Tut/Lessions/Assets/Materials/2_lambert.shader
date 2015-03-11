Shader "unityCookie/tut/2 - lambert" {
	Properties {
		_Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}
	
	SubShader {
		Pass {
			Tags {"LightMode" = "ForwardBase"}
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			// user defined variables
			uniform float4 _Color;
			
			// unity defined variables
			uniform float4 _LightColor0;	    // color of the light, built in variable
			
			// input structs
			struct vertexIn {
				float4 vertexPos : POSITION;	// vertexPos is defined in object(local) space
				float3 normal : NORMAL;         // vertex normal in object(local) sapce
			};
			
			struct vertexOut {
				float4 pos : SV_POSITION;
				float4 col : COLOR;		// we are going to override the color attribute of vertex with our own color
			};
			
			vertexOut vert(vertexIn v_in) {
				vertexOut v_out;
				
				// mul - multiply a matrix by a column vector, row vector by a matrix, or matrix by a matrix
				float3 normalDir = normalize(mul(float4(v_in.normal, 0.0), _Object2World).xyz);
				//float3 normalDir = normalize(mul(float4(v_in.normal, 0.0), _World2Object).xyz);
				float3 lightDir;
				float atten = 1.0;
				
				lightDir = normalize(_WorldSpaceLightPos0.xyz);
				
				// calculate diffuse light
				float3 diffuseReflection = atten * _LightColor0.xyz * _Color.rgb * max(0.0, dot(normalDir, lightDir));
				
				v_out.pos = mul(UNITY_MATRIX_MVP, v_in.vertexPos);
				v_out.col = float4(diffuseReflection, 1.0);
				
				return v_out;
			}
			
			float4 frag(vertexOut v_in) : COLOR {
				return v_in.col;
			}
						
			ENDCG
		}
	}
	Fallback "Diffuse"
}
