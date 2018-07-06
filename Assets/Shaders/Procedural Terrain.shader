Shader "MinTuts/Procedural Terrain" {
  Properties {
    _WaterLimit("Water Limit", Range(0.000001, 0.05)) = 0.01
    _ShoreLimit("Shore Limit", Range(0.05,     0.1 )) = 0.05

    _RedChannel  ("Red Channel",   Range(0, 1)) = 0
    _GreenChannel("Green Channel", Range(0, 1)) = 1
    _BlueChannel ("Blue Channel",  Range(0, 1)) = 0

    _ShoreMultiplier    ("Shore Multiplier",     Range(1,      4   )) = 2
    _IntensityMultiplier("Intensity Multiplier", Range(0.0001, 0.02)) = 0.015
  }

  SubShader {
    Pass {
      CGPROGRAM

        #pragma vertex   vert
        #pragma fragment frag

        #include "UnityCG.cginc"

        float _WaterLimit;
        float _ShoreLimit;

        float _RedChannel;
        float _GreenChannel;
        float _BlueChannel;

        float _ShoreMultiplier;
        float _IntensityMultiplier;

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
          float  p = i.wpos.y * _IntensityMultiplier;
          float3 y = float3(p, p, p);

          float r = _RedChannel;
          float g = _GreenChannel;
          float b = _BlueChannel;

          if (p < _WaterLimit) {
            g -= 1;
            b += 1;

            y = float3(1, 1, 1);
          } else if (p < _ShoreLimit) {
            r = -(p - (_ShoreLimit * _ShoreMultiplier));
            g = r;

            y = float3(1, 1, 1);
          }

          return float4(y * float3(r, g, b), 1);
        }

      ENDCG
    }
  }
}
