using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TexturePipeline : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        Debug.LogFormat($"OnPreprocessTexture : {assetPath}");
    }

    private void OnPostprocessTexture(Texture2D texture)
    {
        Debug.LogFormat($"OnPostprocessTexture : {assetPath}");
    }
}
