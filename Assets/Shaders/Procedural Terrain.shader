Shader "MinTuts/Procedural Terrain" {
  SubShader {
    Pass {
      CGPROGRAM

        #pragma vertex   vert
        #pragma fragment frag

        #include "UnityCG.cginc"

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

          if (p < 0.01) {
            g = 0;
            b = 1;
            
            y = float3(1, 1, 1);
          }
          
          return float4(y * float3(r, g, b), 1);
        }

      ENDCG
    }
  }
}
