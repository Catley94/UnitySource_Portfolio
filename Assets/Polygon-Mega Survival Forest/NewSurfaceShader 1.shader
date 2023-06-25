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

            // Текстура основного цвета травы
            sampler2D _MainTex;

        // Параметры анимации ветра
        float _WindSpeed;
        float _WindStrength;

        // Параметры отсечения
        float _CutoutThreshold;

        // Градиентный цвет
        fixed4 _GradientColor;
        float _HeightThreshold;

        // Глобальная переменная для смещения
        float offset;

        struct Input
        {
            float2 uv_MainTex;
        };

        void vert(inout appdata_full v)
        {
            // Проверяем, что вершина находится выше заданной высоты
            if (v.vertex.y > _HeightThreshold)
            {
                float2 windOffset = float2(v.vertex.x, v.vertex.z) * _WindStrength;
                float2 waveOffset = float2(sin(_Time.y * _WindSpeed), cos(_Time.y * _WindSpeed)) * _WindStrength;
                offset = sin(dot(windOffset, waveOffset));
                v.vertex.y += offset;
            }
            else
            {
                // Нижняя часть травы остается неподвижной
                v.vertex.y = _HeightThreshold;
            }
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            // Получаем цвет из текстуры
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

            // Применяем градиентный цвет к текстуре
            fixed4 gradientColor = half4(c.rgb, 1) * _GradientColor;

            // Применяем цвет и прозрачность
            o.Albedo = gradientColor.rgb;
            o.Alpha = c.a;

            // Отсекаем траву по заданному порогу
            clip(o.Alpha - _CutoutThreshold);
        }
        ENDCG
        }

            FallBack "Diffuse"
}