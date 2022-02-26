// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4226,x:34033,y:32525,varname:node_4226,prsc:2|emission-8392-OUT,olwid-3228-OUT,olcol-7828-OUT;n:type:ShaderForge.SFN_VertexColor,id:4313,x:32135,y:32326,varname:node_4313,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:8434,x:31842,y:33042,varname:node_8434,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:8800,x:32050,y:32948,ptovrint:False,ptlb:Line Frequency,ptin:_LineFrequency,varname:_LineFrequency,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Multiply,id:2606,x:32512,y:32875,varname:node_2606,prsc:2|A-2530-OUT,B-1681-OUT;n:type:ShaderForge.SFN_Sin,id:4476,x:32626,y:32700,varname:node_4476,prsc:2|IN-2606-OUT;n:type:ShaderForge.SFN_Multiply,id:2530,x:32361,y:32816,varname:node_2530,prsc:2|A-5495-OUT,B-8800-OUT;n:type:ShaderForge.SFN_Vector1,id:5495,x:32194,y:32885,varname:node_5495,prsc:2,v1:100;n:type:ShaderForge.SFN_LightAttenuation,id:1246,x:30778,y:32291,varname:node_1246,prsc:2;n:type:ShaderForge.SFN_Desaturate,id:3994,x:31778,y:32338,varname:node_3994,prsc:2|COL-7804-RGB;n:type:ShaderForge.SFN_Add,id:8826,x:32204,y:32461,varname:node_8826,prsc:0|A-8350-OUT,B-1930-OUT;n:type:ShaderForge.SFN_LightVector,id:5067,x:31049,y:31779,varname:node_5067,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:1117,x:30980,y:32108,prsc:2,pt:False;n:type:ShaderForge.SFN_ViewVector,id:7930,x:31347,y:32040,varname:node_7930,prsc:2;n:type:ShaderForge.SFN_Reflect,id:9736,x:31347,y:31912,varname:node_9736,prsc:2|A-8499-OUT,B-1117-OUT;n:type:ShaderForge.SFN_Dot,id:4559,x:31511,y:31982,varname:node_4559,prsc:2,dt:0|A-9736-OUT,B-7930-OUT;n:type:ShaderForge.SFN_Multiply,id:8499,x:31190,y:31839,varname:node_8499,prsc:2|A-5067-OUT,B-2838-OUT;n:type:ShaderForge.SFN_Vector1,id:2838,x:31049,y:31907,varname:node_2838,prsc:2,v1:-1;n:type:ShaderForge.SFN_Power,id:2896,x:31820,y:32055,varname:node_2896,prsc:2|VAL-5877-OUT,EXP-8353-OUT;n:type:ShaderForge.SFN_Vector1,id:8353,x:31661,y:32188,varname:node_8353,prsc:2,v1:5;n:type:ShaderForge.SFN_Clamp01,id:5877,x:31661,y:32055,varname:node_5877,prsc:2|IN-4559-OUT;n:type:ShaderForge.SFN_Multiply,id:8967,x:31929,y:32177,varname:node_8967,prsc:2|A-2896-OUT,B-906-OUT;n:type:ShaderForge.SFN_Cubemap,id:4978,x:31623,y:31862,ptovrint:True,ptlb:Reflection Cubemap,ptin:_Cubemap,varname:_Cubemap,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,pvfc:1|MIP-9506-OUT;n:type:ShaderForge.SFN_Vector1,id:9506,x:31483,y:31845,varname:node_9506,prsc:2,v1:3;n:type:ShaderForge.SFN_Cubemap,id:7804,x:31603,y:32287,ptovrint:False,ptlb:Diffuse Cubemap,ptin:_DiffuseCubemap,varname:_DiffuseCubemap,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,pvfc:3|DIR-1117-OUT,MIP-4279-OUT;n:type:ShaderForge.SFN_Vector1,id:4279,x:31440,y:32314,varname:node_4279,prsc:2,v1:6;n:type:ShaderForge.SFN_Add,id:2656,x:32102,y:32006,varname:node_2656,prsc:2|A-2939-OUT,B-8967-OUT;n:type:ShaderForge.SFN_Multiply,id:906,x:31122,y:32359,varname:node_906,prsc:2|A-1246-OUT,B-6123-OUT;n:type:ShaderForge.SFN_LightColor,id:8990,x:30778,y:32418,varname:node_8990,prsc:2;n:type:ShaderForge.SFN_Desaturate,id:6123,x:30944,y:32418,varname:node_6123,prsc:2|COL-8990-RGB;n:type:ShaderForge.SFN_Dot,id:4021,x:31585,y:32485,varname:node_4021,prsc:2,dt:0|A-1117-OUT,B-8284-OUT;n:type:ShaderForge.SFN_LightVector,id:8284,x:31386,y:32495,varname:node_8284,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6798,x:31778,y:32508,varname:node_6798,prsc:2|A-4021-OUT,B-906-OUT;n:type:ShaderForge.SFN_Clamp01,id:1930,x:31966,y:32521,varname:node_1930,prsc:2|IN-6798-OUT;n:type:ShaderForge.SFN_Desaturate,id:2939,x:31795,y:31862,varname:node_2939,prsc:2|COL-4978-RGB;n:type:ShaderForge.SFN_Subtract,id:2202,x:32339,y:32229,varname:node_2202,prsc:2|A-8339-OUT,B-4313-A;n:type:ShaderForge.SFN_Vector1,id:8339,x:32135,y:32263,varname:node_8339,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:9980,x:32409,y:32461,varname:node_9980,prsc:2|A-4313-A,B-8826-OUT;n:type:ShaderForge.SFN_Multiply,id:26,x:32514,y:32194,varname:node_26,prsc:2|A-9401-OUT,B-2202-OUT;n:type:ShaderForge.SFN_Add,id:282,x:32585,y:32426,varname:node_282,prsc:2|A-26-OUT,B-9980-OUT;n:type:ShaderForge.SFN_Subtract,id:3978,x:32704,y:32589,varname:node_3978,prsc:2|A-282-OUT,B-3830-OUT;n:type:ShaderForge.SFN_Vector1,id:3830,x:32539,y:32623,varname:node_3830,prsc:2,v1:0.75;n:type:ShaderForge.SFN_Add,id:5778,x:32933,y:32704,varname:node_5778,prsc:2|A-3978-OUT,B-4476-OUT;n:type:ShaderForge.SFN_Blend,id:8392,x:33815,y:32525,varname:node_8392,prsc:2,blmd:10,clmp:True|SRC-5307-OUT,DST-7787-OUT;n:type:ShaderForge.SFN_Slider,id:3961,x:32204,y:32708,ptovrint:False,ptlb:Saturation,ptin:_Saturation,varname:node_3961,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:10;n:type:ShaderForge.SFN_Tex2d,id:2437,x:32031,y:33136,ptovrint:False,ptlb:Colored Noise,ptin:_ColoredNoise,varname:node_2437,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8434-UVOUT;n:type:ShaderForge.SFN_Slider,id:3905,x:31977,y:33401,ptovrint:False,ptlb:Noise amount,ptin:_Noiseamount,varname:node_3905,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.04,max:0.2;n:type:ShaderForge.SFN_Vector1,id:4202,x:32031,y:33304,varname:node_4202,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Subtract,id:8936,x:32194,y:33195,varname:node_8936,prsc:2|A-2437-R,B-4202-OUT;n:type:ShaderForge.SFN_Multiply,id:9519,x:32354,y:33195,varname:node_9519,prsc:2|A-8936-OUT,B-3905-OUT;n:type:ShaderForge.SFN_Add,id:1681,x:32354,y:32966,varname:node_1681,prsc:2|A-8434-U,B-9519-OUT;n:type:ShaderForge.SFN_Slider,id:8709,x:32689,y:33046,ptovrint:False,ptlb:Outline,ptin:_Outline,varname:node_8709,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_ObjectScale,id:3233,x:32780,y:33104,varname:node_3233,prsc:2,rcp:False;n:type:ShaderForge.SFN_Desaturate,id:3316,x:32967,y:33104,varname:node_3316,prsc:2|COL-3233-XYZ;n:type:ShaderForge.SFN_Divide,id:3228,x:33169,y:33077,varname:node_3228,prsc:2|A-8709-OUT,B-3316-OUT;n:type:ShaderForge.SFN_VertexColor,id:4217,x:32513,y:33231,varname:node_4217,prsc:2;n:type:ShaderForge.SFN_Blend,id:7828,x:33067,y:33192,varname:node_7828,prsc:2,blmd:10,clmp:True|SRC-5075-OUT,DST-2183-OUT;n:type:ShaderForge.SFN_Vector1,id:2183,x:32796,y:33412,varname:node_2183,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Power,id:2164,x:32969,y:32275,varname:node_2164,prsc:2|VAL-4313-RGB,EXP-3961-OUT;n:type:ShaderForge.SFN_Power,id:5075,x:32723,y:33231,varname:node_5075,prsc:2|VAL-4217-RGB,EXP-3961-OUT;n:type:ShaderForge.SFN_Multiply,id:4432,x:32286,y:31962,varname:node_4432,prsc:2|A-8275-OUT,B-2656-OUT;n:type:ShaderForge.SFN_Vector1,id:8275,x:32102,y:31929,varname:node_8275,prsc:2,v1:4;n:type:ShaderForge.SFN_Subtract,id:9401,x:32427,y:32051,varname:node_9401,prsc:2|A-4432-OUT,B-613-OUT;n:type:ShaderForge.SFN_Vector1,id:613,x:32200,y:32174,varname:node_613,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:315,x:33097,y:32704,varname:node_315,prsc:2|A-5778-OUT,B-3830-OUT;n:type:ShaderForge.SFN_Add,id:504,x:33268,y:32633,varname:node_504,prsc:2|A-6092-OUT,B-315-OUT;n:type:ShaderForge.SFN_Vector1,id:6092,x:33045,y:32574,varname:node_6092,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7243,x:32718,y:32400,varname:node_7243,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:5307,x:33253,y:32404,varname:node_5307,prsc:2|A-2164-OUT,B-4613-OUT;n:type:ShaderForge.SFN_Multiply,id:5339,x:32871,y:32457,varname:node_5339,prsc:2|A-7243-OUT,B-3961-OUT;n:type:ShaderForge.SFN_Add,id:4613,x:33107,y:32441,varname:node_4613,prsc:2|A-4048-OUT,B-5339-OUT;n:type:ShaderForge.SFN_Vector1,id:4048,x:32969,y:32423,varname:node_4048,prsc:2,v1:1;n:type:ShaderForge.SFN_Depth,id:1160,x:32784,y:32792,varname:node_1160,prsc:2;n:type:ShaderForge.SFN_Vector1,id:8633,x:32699,y:32896,varname:node_8633,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:1321,x:33097,y:32838,varname:node_1321,prsc:2|A-1160-OUT,B-3136-OUT;n:type:ShaderForge.SFN_Fresnel,id:1345,x:33202,y:32958,varname:node_1345,prsc:2|EXP-1521-OUT;n:type:ShaderForge.SFN_Add,id:5498,x:33268,y:32822,varname:node_5498,prsc:2|A-1321-OUT,B-1345-OUT;n:type:ShaderForge.SFN_Lerp,id:7787,x:33693,y:32611,varname:node_7787,prsc:2|A-504-OUT,B-282-OUT,T-3936-OUT;n:type:ShaderForge.SFN_Vector1,id:5468,x:33407,y:32667,varname:node_5468,prsc:2,v1:0.5;n:type:ShaderForge.SFN_ConstantClamp,id:3936,x:33542,y:32705,varname:node_3936,prsc:2,min:0,max:1|IN-785-OUT;n:type:ShaderForge.SFN_Divide,id:3136,x:32967,y:32888,varname:node_3136,prsc:2|A-8633-OUT,B-1398-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1398,x:32699,y:32975,ptovrint:False,ptlb:LinesDistance,ptin:_LinesDistance,varname:node_1398,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Slider,id:3221,x:31361,y:32188,ptovrint:False,ptlb:Ambient amount,ptin:_Ambientamount,varname:node_3221,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Multiply,id:8350,x:31989,y:32381,varname:node_8350,prsc:2|A-3221-OUT,B-3994-OUT;n:type:ShaderForge.SFN_Subtract,id:785,x:33413,y:32750,varname:node_785,prsc:2|A-5498-OUT,B-5468-OUT;n:type:ShaderForge.SFN_Vector1,id:1521,x:33049,y:33019,varname:node_1521,prsc:2,v1:1;proporder:8800-4978-7804-3961-2437-3905-8709-1398-3221;pass:END;sub:END;*/

Shader "Custom/Hatched_watercol_shader" {
    Properties {
        _LineFrequency ("Line Frequency", Float ) = 3
        _Cubemap ("Reflection Cubemap", Cube) = "_Skybox" {}
        _DiffuseCubemap ("Diffuse Cubemap", Cube) = "_Skybox" {}
        _Saturation ("Saturation", Range(0, 10)) = 2
        _ColoredNoise ("Colored Noise", 2D) = "white" {}
        _Noiseamount ("Noise amount", Range(0, 0.2)) = 0.04
        _Outline ("Outline", Range(0, 1)) = 0
        _LinesDistance ("LinesDistance", Float ) = 1
        _Ambientamount ("Ambient amount", Range(0, 1)) = 0.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Saturation)
                UNITY_DEFINE_INSTANCED_PROP( float, _Outline)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.vertexColor = v.vertexColor;
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                float _Outline_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Outline );
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*(_Outline_var/dot(objScale,float3(0.3,0.59,0.11))),1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                float _Saturation_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Saturation );
                return fixed4(saturate(( 0.1 > 0.5 ? (1.0-(1.0-2.0*(0.1-0.5))*(1.0-pow(i.vertexColor.rgb,_Saturation_var))) : (2.0*0.1*pow(i.vertexColor.rgb,_Saturation_var)) )),0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform samplerCUBE _Cubemap;
            uniform samplerCUBE _DiffuseCubemap;
            uniform sampler2D _ColoredNoise; uniform float4 _ColoredNoise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _LineFrequency)
                UNITY_DEFINE_INSTANCED_PROP( float, _Saturation)
                UNITY_DEFINE_INSTANCED_PROP( float, _Noiseamount)
                UNITY_DEFINE_INSTANCED_PROP( float, _LinesDistance)
                UNITY_DEFINE_INSTANCED_PROP( float, _Ambientamount)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float _Saturation_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Saturation );
                float node_2939 = dot(texCUBElod(_Cubemap,float4(viewReflectDirection,3.0)).rgb,float3(0.3,0.59,0.11));
                float node_906 = (attenuation*dot(_LightColor0.rgb,float3(0.3,0.59,0.11)));
                float _Ambientamount_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Ambientamount );
                float node_282 = ((((4.0*(node_2939+(pow(saturate(dot(reflect((lightDirection*(-1.0)),i.normalDir),viewDirection)),5.0)*node_906)))-2.0)*(1.0-i.vertexColor.a))+(i.vertexColor.a*((_Ambientamount_var*dot(texCUBElod(_DiffuseCubemap,float4(i.normalDir,6.0)).rgb,float3(0.3,0.59,0.11)))+saturate((dot(i.normalDir,lightDirection)*node_906)))));
                float node_3830 = 0.75;
                float _LineFrequency_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LineFrequency );
                float4 _ColoredNoise_var = tex2D(_ColoredNoise,TRANSFORM_TEX(i.uv0, _ColoredNoise));
                float _Noiseamount_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Noiseamount );
                float _LinesDistance_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LinesDistance );
                float3 emissive = saturate(( lerp((0.0+(((node_282-node_3830)+sin(((100.0*_LineFrequency_var)*(i.uv0.r+((_ColoredNoise_var.r-0.5)*_Noiseamount_var)))))*node_3830)),node_282,clamp((((partZ*(1.0/_LinesDistance_var))+pow(1.0-max(0,dot(normalDirection, viewDirection)),1.0))-0.5),0,1)) > 0.5 ? (1.0-(1.0-2.0*(lerp((0.0+(((node_282-node_3830)+sin(((100.0*_LineFrequency_var)*(i.uv0.r+((_ColoredNoise_var.r-0.5)*_Noiseamount_var)))))*node_3830)),node_282,clamp((((partZ*(1.0/_LinesDistance_var))+pow(1.0-max(0,dot(normalDirection, viewDirection)),1.0))-0.5),0,1))-0.5))*(1.0-(pow(i.vertexColor.rgb,_Saturation_var)*(1.0+(0.1*_Saturation_var))))) : (2.0*lerp((0.0+(((node_282-node_3830)+sin(((100.0*_LineFrequency_var)*(i.uv0.r+((_ColoredNoise_var.r-0.5)*_Noiseamount_var)))))*node_3830)),node_282,clamp((((partZ*(1.0/_LinesDistance_var))+pow(1.0-max(0,dot(normalDirection, viewDirection)),1.0))-0.5),0,1))*(pow(i.vertexColor.rgb,_Saturation_var)*(1.0+(0.1*_Saturation_var)))) ));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform samplerCUBE _Cubemap;
            uniform samplerCUBE _DiffuseCubemap;
            uniform sampler2D _ColoredNoise; uniform float4 _ColoredNoise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _LineFrequency)
                UNITY_DEFINE_INSTANCED_PROP( float, _Saturation)
                UNITY_DEFINE_INSTANCED_PROP( float, _Noiseamount)
                UNITY_DEFINE_INSTANCED_PROP( float, _LinesDistance)
                UNITY_DEFINE_INSTANCED_PROP( float, _Ambientamount)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = 0;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
