using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class EditorUtil
{
    public static List<T> GetAssetWithScript<T>(string path) where T : MonoBehaviour
    {
        T tmp;
        
        List<T> assetList = new List<T>();
        
        //paht以下のprefabを検索して、そのGUIDリストを取得します。
        string[] guids = AssetDatabase.FindAssets("t:prefab", new string[] {path});
        foreach (var name in guids)
        {
            //GUIDからアセットの相対パスを取得
            var assetPath = AssetDatabase.GUIDToAssetPath(name);
            //指定パスのアセットをロード
            var asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;
            tmp = asset.GetComponent<T>();
            if (tmp)
            {
                assetList.Add(tmp);
            }
        }
        return assetList;
    }
    
    
}
