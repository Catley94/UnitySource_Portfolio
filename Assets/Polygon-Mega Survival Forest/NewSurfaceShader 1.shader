Shader "Custom/GrassShaderWithShadowAndCutout"
{
    Properties
    {
        _MainTex("Grass Texture", 2D) = "white" {}
        _WindSpeed("Wind Speed", Range(0, 1)) = 0.5
        _WindStrength("Wind Strength", Range(0, 1)) = 0.5
        _CutoutThreshold("Cutout Threshold", Range(0, 1)) = 0.5
        _GradientColor("Gradient Color", Color) = (1, 1, 1, 1)
        _HeightThreshold("Height Threshold", Range(-1, 1)) = 0.5
    }

        SubShader
        {
            Tags { "RenderType" = "Opaque" "Queue" = "Transparent" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Lambert vertex:vert fullforwardshadows alpha:fade

            // �������� ��������� ����� �����
            sampler2D _MainTex;

        // ��������� �������� �����
        float _WindSpeed;
        float _WindStrength;

        // ��������� ���������
        float _CutoutThreshold;

        // ����������� ����
        fixed4 _GradientColor;
        float _HeightThreshold;

        // ���������� ���������� ��� ��������
        float offset;

        struct Input
        {
            float2 uv_MainTex;
        };

        void vert(inout appdata_full v)
        {
            // ���������, ��� ������� ��������� ���� �������� ������
            if (v.vertex.y > _HeightThreshold)
            {
                float2 windOffset = float2(v.vertex.x, v.vertex.z) * _WindStrength;
                float2 waveOffset = float2(sin(_Time.y * _WindSpeed), cos(_Time.y * _WindSpeed)) * _WindStrength;
                offset = sin(dot(windOffset, waveOffset));
                v.vertex.y += offset;
            }
            else
            {
                // ������ ����� ����� �������� �����������
                v.vertex.y = _HeightThreshold;
            }
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            // �������� ���� �� ��������
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

            // ��������� ����������� ���� � ��������
            fixed4 gradientColor = half4(c.rgb, 1) * _GradientColor;

            // ��������� ���� � ������������
            o.Albedo = gradientColor.rgb;
            o.Alpha = c.a;

            // �������� ����� �� ��������� ������
            clip(o.Alpha - _CutoutThreshold);
        }
        ENDCG
        }

            FallBack "Diffuse"
}