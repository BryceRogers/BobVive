﻿Shader "Custom/TranspUnlit" {
     Properties {
         _Color("Color & Transparency", Color) = (0, 0, 0, 0.5)
     }
     SubShader {
         Lighting Off
         ZWrite Off
         Cull Front
         Blend SrcAlpha OneMinusSrcAlpha
         Tags {"Queue" = "Transparent"}
         Color[_Color]
         Pass {
         }
     } 
     FallBack "Unlit/Transparent"
 }