using System;
using UnityEditor;
using UnityEngine;

namespace ImportExample
{
    public class ImportDllExample : AssetPostprocessor
    {
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            foreach (var path in importedAssets)
            {
                Debug.LogFormat($"ImportDllExample : {path}");
            }
        }
    }
}