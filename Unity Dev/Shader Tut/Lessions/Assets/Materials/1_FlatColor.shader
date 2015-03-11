Shader "unityCookie/tut/intro/1 - FlatColor" {
	Properties {	// Properties is interface with unity
	   // _Color is variable name, it can be adjusted in unity
	   // by the CG shader or through the unity editor
		_Color ("MyColor", Color) = (1.0, 1.0, 1.0, 1.0)
	}
	
	Subshader {
		// we can have multiple passes and blend them together
		// to create the effect we want
		Pass {	// render pass
			CGPROGRAM	// start processing CG shader
			
			// pragmas
			#pragma vertex vert
			#pragma fragment frag
			
			// user defined variable
			// we want to use the _Color in properties within CG shader, so we define it first
			// because CG doesn't know what _Color is, even through it knows the information 
			// of _Color defined in Properties block of Shaderlab
			// so we need to define it and give it a type so CG can manipulate it
			uniform float4 _Color;		// uniform is a CG key word, it is used to 
										// define variables when we do initialization definations
			
			// base input structs
			struct vertexInput {
				float4 vertexPos : POSITION;
			};
			
			struct vertexOutput {
				float4 pos : SV_POSITION;
			};
			
			// vertex func
			vertexOutput vert(vertexInput v_in) {
				vertexOutput v_out;
				
				// model-view-projection matrix
				v_out.pos = mul(UNITY_MATRIX_MVP, v_in.vertexPos);
				
				return v_out;
			}
			
			// fragment func
			float4 frag(vertexOutput v) : COLOR {
				return _Color;
			}
			
			ENDCG
		}
	}
	
	Fallback "Diffuse"
}