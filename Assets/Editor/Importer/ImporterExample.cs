using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;


//拡張子 cubeのアセットをインポートする
[ScriptedImporter(1, "cube")]
public class ImporterExample : ScriptedImporter
{
    public float scale = 1;
    //拡張子cubeのファイルがインポートされると、cubeのPrimitiveとマテリアルを追加したprefabが作成されます。
    public override void OnImportAsset(AssetImportContext ctx)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        cube.transform.position = Vector3.zero;
        cube.transform.localScale = new Vector3(scale, scale, scale);

        ctx.AddObjectToAsset("MainAsset", cube);
        ctx.SetMainObject(cube);
        
        var material = new Material(Shader.Find("Standard"));
        
        ctx.AddObjectToAsset("My Material", material);
        

    }
}
