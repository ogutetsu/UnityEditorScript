using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Editor側に記述する場合のGizmo
//リリース時などにGizmoのコードを含ませたくない場合などに使用
public class EditorGizmo 
{
    
    //GizmoType.Active ... オブジェクトがアクティブな場合描画 (Inspectorに表示されている状態)
    //GizmoType.Selected...選択している場合、ギズモを描画
    //GizmoType.NonSelected...選択していない場合、ギズモを描画
    //GizmoType.Pickable...
    //GizmoType.InSelectionHierarchy...オブジェクトが選択されている、または子が選択されている場合ギズモを描画
    //GizmoType.NotInSelectionHierarchy...オブジェクトが選択されていない、または親が選択されていない場合ギズモを描画



    [DrawGizmo(GizmoType.Selected|
               GizmoType.NonSelected|
               GizmoType.InSelectionHierarchy)]
    private static void CustomGizmo(EditorGizmoTarget target, GizmoType type)
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(target.transform.position, Vector3.one);
        UnityEditor.Handles.Label(target.transform.position + new Vector3(0, 3, 0), "ギズモのコードのみ分けたもの");
    }
    
    
}
