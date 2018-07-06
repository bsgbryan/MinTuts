Shader "MinTuts/Procedural Terrain" {
  Properties {
    _WaterLimit("Water Limit", Range(0.000001, 0.05)) = 0.01
    _ShoreLimit("Shore Limit", Range(0.05,     0.1 )) = 0.05
  }

  SubShader {
    Pass {
      CGPROGRAM

        #pragma vertex   vert
        #pragma fragment frag

        #include "UnityCG.cginc"

        float _WaterLimit;
        float _ShoreLimit;

        struct v2f {
          float4 pos  : SV_POSITION;
          float3 wpos : POSITION1;
        };

        v2f vert(float4 vertex : POSITION) {
          v2f o;
          
          o.pos  = UnityObjectToClipPos(vertex);
          o.wpos = mul(unity_ObjectToWorld, vertex);
          
          return o;
        }

        float4 frag(v2f i) : COLOR {
          float  p = i.wpos.y * 0.015;
          float3 y = float3(p, p, p);

          float r = 0;
          float g = 1;
          float b = 0;

          if (p < _WaterLimit) {
            g = 0;
            b = 1;
            
            y = float3(1, 1, 1);
          } else if (p < _ShoreLimit) {
            r = -(p - 0.1);
            g = r;
            
            y = float3(1, 1, 1);
          }
          
          return float4(y * float3(r, g, b), 1);
        }

      ENDCG
    }
  }
}
