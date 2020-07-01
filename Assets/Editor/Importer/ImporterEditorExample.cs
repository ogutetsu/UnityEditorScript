using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;


//Inspectorに制御パラメータを追加したい場合は、ScriptedImporterEditor.OnInspectorGUIを実装する
//ScriptedImporterのpublicフィールドでも問題ないが、ScriptedImporterEditorを使った方がわかりやすい
[CustomEditor(typeof(ImporterExample))]
public class ImporterEditorExample : ScriptedImporterEditor
{
    public override void OnInspectorGUI()
    {
        var scale = new GUIContent("Scale");
        //Custom対象のクラスのプロパティ名を指定します
        var prop = serializedObject.FindProperty("scale");
        EditorGUILayout.PropertyField(prop, scale);
        
        //最後に呼び出す必要がある
        base.ApplyRevertGUI();
    }
}
