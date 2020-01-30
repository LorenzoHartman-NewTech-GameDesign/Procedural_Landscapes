Shader "Hidden/GlobalSnow/Deferred Eraser" {
Properties {
}

SubShader {
	Tags { "RenderType"="Opaque" }	
	Pass {

	ColorMask 0

	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	#include "UnityCG.cginc"
	
	struct v2f {
    	float4 pos : SV_POSITION;
	};

	v2f vert( appdata_base v ) {
	    v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
	    return o;
	}
	
	fixed4 frag(v2f i) : SV_Target {
		return fixed4(0,0,0,0);
	}
	ENDCG
	}
	
}

SubShader {
	Tags { "RenderType"="TransparentCutout" }	
	Pass {

	ColorMask 0

	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	#include "UnityCG.cginc"

	sampler2D _MainTex;

	struct v2f {
    	float4 pos : SV_POSITION;
    	float2 uv: TEXCOORD0;
	};

	v2f vert( appdata_base v ) {
	    v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = v.texcoord;
	    return o;
	}
	
	fixed4 frag(v2f i) : SV_Target {
		fixed4 c = tex2D(_MainTex, i.uv);
		clip(c.a-0.1);
		return fixed4(0,0,0,0);
	}
	ENDCG
	}
}

Fallback Off
}
