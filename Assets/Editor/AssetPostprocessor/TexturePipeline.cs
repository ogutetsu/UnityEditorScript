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

        //指定のパス下の場合に処理を実行
        if (assetPath.StartsWith("Assets/Texture"))
        {
            //テクスチャの設定を変更
            TextureImporter importer = assetImporter as TextureImporter;
            importer.textureType = TextureImporterType.Sprite;
            TextureImporterSettings settings = new TextureImporterSettings();
            importer.ReadTextureSettings(settings);
            settings.spriteAlignment = (int) SpriteAlignment.Center;
            settings.mipmapEnabled = false;
            importer.SetTextureSettings(settings);
        }
        
    }
}
