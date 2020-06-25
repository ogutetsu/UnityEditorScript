using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//慣例でクラス名の最後にAttributeをつけてます。
public class InspectorPropertyAttribute : PropertyAttribute
{
    public readonly bool Display;

    public InspectorPropertyAttribute(bool display = false)
    {
        Display = display;
    }

}
