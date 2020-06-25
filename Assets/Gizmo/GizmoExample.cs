using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoExample : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawCube(
            transform.position, Vector3.one*2);
        
        #if UNITY_EDITOR
        UnityEditor.Handles.Label(transform.position + new Vector3(0, 3, 0), "簡単なギズモの例");
#endif

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            transform.position, Vector3.one*2);
    }
}
