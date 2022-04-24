Shader "UI/ColorWheel" {
	Properties {
		_Color ("_Color", Color) = (1,1,1,1)
		_OutlineColor ("_OutlineColor", Color) = (0,0,0,1)
		_OutlineSize ("_OutlineSize", Range(0,1)) = 0.5
	}
	SubShader {
		Lighting Off
		Blend SrcAlpha OneMinusSrcAlpha
	
		Pass{		
			CGPROGRAM
			#pragma vertex vert
	        #pragma fragment frag
			#pragma target 3.0
			
			#include "UnityCG.cginc"
			
			//Prepare the inputs
			struct vertIN{
				float4 vertex : POSITION;
				float4 texcoord0 : TEXCOORD0;
			};
			
			struct fragIN{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			
			//Function for making smooth circles from gradient
			fixed smoothCircle(fixed size, fixed gradient){
				fixed scaleFactor = size + 1;
				return smoothstep(0.5 - 0.0025 * scaleFactor, 0.5 + 0.0025 * scaleFactor, 1 - gradient * scaleFactor);
			}
			
			//Function for making box from gradient
			fixed smoothBox(fixed size, fixed2 gradient){
				fixed scaleFactor = size * 0.5;
				fixed alpha = ceil(gradient.x - scaleFactor);
				alpha *= ceil((1 - gradient.x) - scaleFactor);
				alpha *= ceil(gradient.y - scaleFactor);
				alpha *= ceil((1 - gradient.y) - scaleFactor);
				
				return alpha;
			}

			//Remap function
			fixed remap(float from, float fromMin, float fromMax, float toMin, float toMax)
		    {
		        fixed fromAbs  =  from - fromMin;
		        fixed fromMaxAbs = fromMax - fromMin;      
		       
		        fixed normal = fromAbs / fromMaxAbs;
		 
		        fixed toMaxAbs = toMax - toMin;
		        fixed toAbs = toMaxAbs * normal;
		 
		        fixed to = toAbs + toMin;
		       
		        return to;
		    }
			
			//Get the values from outside
			fixed4 _Color;
			float4 _OutlineColor;
			fixed _OutlineSize;
			
			//Fill the vert struct
			fragIN vert (vertIN v){
				fragIN o;
				
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord0;
				
				return o;
			}
			
			//Draw the circle
			fixed4 frag(fragIN i) : COLOR{
				fixed4 c = 1;
				
				//Make the inner area of the box
				fixed2 bGrad = 1;
				bGrad.x = smoothstep(0.25, 0.75, i.uv.x);
				bGrad.y = smoothstep(0.25, 0.75, i.uv.y);
				
				fixed4 cBox = lerp(1, _Color, bGrad.x) * bGrad.y;
				
				//Set up PI
				fixed PI = 3.14159265359;

				//Circular gradient
				fixed cGrad = distance(i.uv, fixed2(0.5, 0.5));
				
				//Angle gradient
				fixed ang = atan2(1 - i.uv.x - 0.5, 1 - i.uv.y - 0.5) + PI;

				//Calculate hue
				fixed4 cWheel = 1;
				
				cWheel.r = clamp(asin(cos(ang)) + 0.5, 0, 1);
				cWheel.g = clamp(asin(cos(2 * PI * (1.0/3.0) - ang)) + 0.5, 0, 1);
				cWheel.b = clamp(asin(cos(2 * PI * (2.0/3.0) - ang))+ 0.5, 0, 1);

								
				//Calculate white part
				fixed aWhite = smoothCircle(0.025, cGrad);
				
				aWhite -= smoothCircle(0.36, cGrad);
				
				aWhite += smoothBox(0.47, i.uv.xy);
				
				c = lerp(_OutlineColor, 1, aWhite);
				
				//Add color

				fixed v1 = remap(_OutlineSize,0,1,0,0.12);
				fixed aCol = smoothCircle(v1, cGrad);

				fixed v2 = remap(_OutlineSize,0,1,0.4,0.2);
				aCol -= smoothCircle(v2, cGrad);
				
				c = lerp(c, cWheel, aCol);

				fixed v3 = remap(_OutlineSize,0,1,0.45,0.55);
				aCol = smoothBox(v3, i.uv.xy);
				
				c = lerp(c, cBox, aCol);
				
				//Set alpha
				fixed alpha = smoothCircle(0, cGrad);
				
				alpha -= smoothCircle(0.4, cGrad);
				
				alpha += smoothBox(0.45, i.uv.xy);

				c.a = alpha;
				
				return c;
			}
			
			ENDCG
			
		}
	} 
}