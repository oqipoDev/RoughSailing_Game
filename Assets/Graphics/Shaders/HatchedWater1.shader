// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/HatchedWater1"
{
    Properties
    {
        _RandomDir("Direction randomizer", 2D) = "white" {}
        _DistToBorder("Distance to border", 2D) = "white" {}
        _ColoredNoise ("Colored noise", 2D) = "white" {}
        _Normal ("Normal map", 2D) = "white" {}
        _TexFreq ("Texture frequency", float) = 1
        _LightAngle ("Light Angle", Range(0, 360)) = 0
        _ShadowPow ("Shadow intensity", Range (0, 2)) = 1
        _MainAngle("Flow Angle", float) = 0
        _FlowRand ("Flow randomness", Range(0, 180)) = 90
        _LineFreq("Line frequency", float) = 30
        _Speed ("FlowSpeed", float) = 1
        _NoiseAmnt ("Line jerkiness", Range(0, 10)) = 5
        _BorderFac ("Wave border factor", Range(0, 10)) = 5
        _Height ("Wave height", float) = 1
        [HideInInspector] _CustomTime ("Custom time", float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque"}
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog
            #pragma target 3.0
            #pragma glsl

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv1 : TEXCOORD0;
                float2 uv2 :TEXCOORD2;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 normal : NORMAL;
            };

            sampler2D _RandomDir;
            sampler2D _DistToBorder;
            sampler2D _ColoredNoise;
            sampler2D _Normal;
            float4 _RandomDir_ST;
            float _LineFreq,
                _MainAngle,
                _FlowRand,
                _NoiseAmnt,
                _Speed,
                _BorderFac,
                _LightAngle,
                _ShadowPow,
                _TexFreq,
                _Height,
                _CustomTime;

            v2f vert (appdata v)
            {
                v2f o;
                //Initialize vertex
                float4 worldpos = mul(unity_ObjectToWorld, v.vertex);
                o.vertex = worldpos;
                //UVs
                float2 shiftedUV1 = -(worldpos.xz + _CustomTime * 0.05 * _Speed) * _TexFreq * 0.01;
                float2 shiftedUV2 = (worldpos.xz - _CustomTime * 0.05 * _Speed) * _TexFreq * 0.01;

                o.uv1 = shiftedUV1;
                o.uv2 = shiftedUV2;

                o.normal = v.normal;

                float wave1 = tex2Dlod(_DistToBorder, float4(o.uv1.xy, 0, 0));
                float wave2 = tex2Dlod(_DistToBorder, float4(o.uv2.xy, 0, 0));

                float2 waves = float2(wave1 + wave2, 0);
                
                o.vertex = UnityObjectToClipPos(v.vertex - waves.yxy * _Height * 0.1);

                /*float4 vertec = UnityObjectToClipPos(o.vertex);

                float a = tex2Dlod(_DistToBorder, float4(v.uv.xy, 0, 0)).r;

                vertec.y += a;

                o.vertex =  mul(UNITY_IMATRIX_MVP, vertec);*/

                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //Fetch textures
                fixed3 Dir1 = tex2D(_RandomDir, i.uv1.xy).rgb;
                fixed3 Dir2 = tex2D(_RandomDir, i.uv2.xy).rgb;
                
                fixed3 mixedDirs = Dir1 * Dir2;

                fixed3 norm1 = float3(1, 1, 1) - (tex2D(_Normal, i.uv1.xy).rgb);
                fixed3 norm2 = tex2D(_Normal, i.uv2.xy).rgb;

                fixed3 normals = normalize((norm1 * norm2 * 2) - fixed3(0.5, 0.5, 0.5));
                
                float noise = tex2D(_ColoredNoise, i.uv1 * 10).r * tex2D(_ColoredNoise, i.uv2 * 10).b;
                noise = noise * _NoiseAmnt * 10;

                float border = 1 - min(tex2D(_DistToBorder, i.uv1.xy).r, tex2D(_DistToBorder, i.uv2.xy).r);

                //depth?

                //Mixing
                float rotAmt = (_MainAngle + (mixedDirs * _FlowRand * 2) - _FlowRand) * 0.01745329;

                //Get lines from sine of x
                float flowCoord = cos(rotAmt) * i.uv1.x - sin(rotAmt) * i.uv1.y;
                
                //Add noise
                float lineWeight = sin((flowCoord * _LineFreq * 100) + noise);
                lineWeight = (lineWeight / 2) + 0.5;

                //Lighting
                float3 lightdir = normalize(float3(
                    cos(radians(_LightAngle)),
                    sin(radians(_LightAngle)), 0));

                float light = 1 - clamp(((dot(lightdir, normals) / 2) + 0.5) * _ShadowPow, 0, 1);

                float shadedLines = pow(light, 0.5) + lineWeight;

                float litLines = pow(border, _BorderFac * 10) * light;

                fixed4 fogTest = fixed4(0, 0.5, 0.5, 1);

                UNITY_APPLY_FOG(i.fogCoord, fogTest);

                //float bnw = floor(shadedLines + litLines - 0.5 + fogTest.r);

                float finalLines = (shadedLines + litLines - 1);

                float foggyLines = finalLines + (fogTest.g * 4 - 2);

                fixed4 finalCol = foggyLines;

                return fixed4(finalCol);
            }
            ENDCG
        }
    }
}
