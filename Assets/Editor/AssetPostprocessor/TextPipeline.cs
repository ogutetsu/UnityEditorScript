using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TextPipeline : AssetPostprocessor
{
    
    
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
        string[] movedFromAssetPaths)
    {
        foreach (var path in importedAssets)
        {
            Debug.LogFormat($"{path}がインポートされました。");

            //拡張子が.txtかチェック
            if (path.EndsWith(".txt"))
            {
                Debug.LogFormat($"テキストファイルがインポートされました。");
            }
        }
            
    }
}
