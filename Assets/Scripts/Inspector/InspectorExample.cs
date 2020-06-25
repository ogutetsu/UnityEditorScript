using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorExample : MonoBehaviour
{

    //publicはInspectorに公開されます。
    public int value1 = 1;
    //privateを公開する場合
    [SerializeField]
    private int value2 = 2;
    //publicをInspectorに公開しない場合
    [HideInInspector]
    public int value3 = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
