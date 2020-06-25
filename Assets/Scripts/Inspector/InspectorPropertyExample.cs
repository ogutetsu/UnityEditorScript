using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorPropertyExample : MonoBehaviour
{

    //InspectorPropertyAttributeでも可
    [InspectorProperty]
    public int Year = 2020;

    
    //引数のサンプル(引数の処理は実装していません)
    //また、AttributeのDrawerはintしか処理しないためエラーが表示されます。
    [InspectorProperty(true)] public string Str;

}
