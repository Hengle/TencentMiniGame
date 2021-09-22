Shader "Unlit/S_Reflection"
{
    Properties
    {
        _ReflectionTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="TransParent" }
        LOD 100
        Blend SrcAlpha One
        //OneMinusSrcAlpha
        Pass
        {
            Stencil{
                Ref 1
                Comp Equal
            }


            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag


            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _ReflectionTex;
            float _reflectionFactor;
            float4 _ReflectionTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_ReflectionTex, i.uv);
                col.a = _reflectionFactor;
                return col;
            }
            ENDCG
        }
    }
}
