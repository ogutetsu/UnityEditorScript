using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomInspectorExample))]
public class CustomInspector : Editor
{
    
    //CustomInspector上で操作するためのもの
    private CustomInspectorExample _target;

    private void OnEnable()
    {
        _target = target as CustomInspectorExample;
    }

    public override void OnInspectorGUI()
    {
        //デフォルトのGUIをレンダリング
        DrawDefaultInspector();
        EditorGUILayout.LabelField($"Inspector上にテキスト表示できます。");

        _target.Count = EditorGUILayout.IntField("Int型を指定", Mathf.Max(0, _target.Count));
        _target.Size = EditorGUILayout.FloatField("float型を指定", _target.Size);
        _target.Bgm = EditorGUILayout.ObjectField("オブジェクト型", _target.Bgm, typeof(AudioClip), false) as AudioClip;
        _target.BG = EditorGUILayout.ObjectField("", _target.BG, typeof(Sprite), false) as Sprite;

        //allowSceneObjectsは、シーン上のオブジェクトも設定できるかどうか
        EditorGUILayout.ObjectField("", null, typeof(GameObject), true);

    }
}
