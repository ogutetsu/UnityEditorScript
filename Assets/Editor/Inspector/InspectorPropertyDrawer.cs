using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//ここで、Attributeクラスを指定します。
[CustomPropertyDrawer(typeof(InspectorPropertyAttribute))]
public class InspectorPropertyDrawer : PropertyDrawer
{
    private string YearFormat(int year)
    {
        return $"今年は{year}年です";
    }

    //2行分表示出来るように高さを変更
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property) * 2;
    }

    //拡張分の描画
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.Integer)
        {
            property.intValue = EditorGUI.IntField(new Rect(position.x,position.y, position.width, position.height/2), label, property.intValue);
            EditorGUI.LabelField(new Rect(position.x,position.y+position.height/2, position.width, position.height/2), " ", YearFormat(property.intValue));
        }
        else
        {
            EditorGUI.HelpBox(position, "数値を入力してください。", MessageType.Error);
        }
        
    }
}
