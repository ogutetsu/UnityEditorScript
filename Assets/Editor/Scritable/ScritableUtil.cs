using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public static class ScritableUtil 
{

    public static T Create<T>(string path) where T : ScriptableObject
    {
        T data = ScriptableObject.CreateInstance<T>() as T;
        //新しいアセットを作成
        AssetDatabase.CreateAsset(data, path);
        //新しいアセットをプロジェクトに表示
        AssetDatabase.Refresh();
        //新しく作成されたアセットをプロジェクトに保存
        AssetDatabase.SaveAssets();
        return data;
    }
    
    
    [MenuItem("Custom/Scritable/New Data")]
    private static void CreateScritable()
    {
        string path = EditorUtility.SaveFilePanelInProject("New Data",
            "ScritableData",
            "asset",
            "ScritableObjectのサンプル例");
        if (path != "")
            ScritableUtil.Create<ScritableExample>(path);
    }
}
