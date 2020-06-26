using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneHandlesExample : MonoBehaviour
{
    public enum HandleType
    {
        Free,
        Slider,
        FreeRot,
        Radius,
        Line,
        SolidArc,
        PolyLine,
        Bezier,
        Button,
        
    }

    public HandleType type;

}
