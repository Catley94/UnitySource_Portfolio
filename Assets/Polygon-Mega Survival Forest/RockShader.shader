Shader "Custom/SnowyStone"
{
    Properties
    {
        _MainTex("Albedo", 2D) = "white" {}
        _SnowTex("Snow Texture", 2D) = "white" {}
        _SnowAmount("Snow Amount", Range(0, 1)) = 0.0
        _SnowBrightness("Snow Brightness", Range(0, 2)) = 1.0
        _SnowSideAmount("Snow Side Amount", Range(0, 1)) = 0.0
        _SnowSideBrightness("Snow Side Brightness", Range(0, 2)) = 1.0
        _SnowTiling("Snow Tiling", Vector) = (1, 1, 0, 0)
    }

        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Lambert

            sampler2D _MainTex;
            sampler2D _SnowTex;
            float _SnowAmount;
            float _SnowBrightness;
            float _SnowSideAmount;
            float _SnowSideBrightness;
            float4 _SnowTiling;

            struct Input
            {
                float2 uv_MainTex;
                float3 worldNormal;
                float3 worldPos;
            };

            void surf(Input IN, inout SurfaceOutput o)
            {
                // �������� ���� �������� �������� �����
                fixed4 stoneColor = tex2D(_MainTex, IN.uv_MainTex);

                // �������� ����������� ����� � ������� �����������
                float3 worldUp = float3(0, 1, 0);

                // ���������� ���������� ����� �� ������ ����������� ������� � ����������� �����
                float snowAmount = saturate(dot(IN.worldNormal, worldUp)) * _SnowAmount;

                // ���������� ���������� ����� �� ����� ����� �� ������ ����������� �������
                float sideSnowAmount = saturate(1.0 - abs(dot(IN.worldNormal, worldUp))) * _SnowSideAmount;

                // �������� ���� ����� �� �������� ����� � ������ ��������
                float2 snowUV = IN.worldPos.xz * _SnowTiling.xy;
                fixed4 snowColor = tex2D(_SnowTex, snowUV);

                // ��������� ������� �����
                snowColor.rgb *= _SnowBrightness;

                // ����������� ���� �������� �������� ����� � ������ �����
                fixed4 finalColor = lerp(stoneColor, snowColor, snowAmount);

                // ��������� ���� �� ���� �����
                finalColor = lerp(finalColor, snowColor, sideSnowAmount * _SnowSideBrightness);

                o.Albedo = finalColor.rgb;
                o.Alpha = finalColor.a;
            }
            ENDCG
        }
            FallBack "Diffuse"
}