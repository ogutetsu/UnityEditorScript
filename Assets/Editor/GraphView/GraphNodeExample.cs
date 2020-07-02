using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GraphNodeExample : Node
{
    public Port inputPort;
    public Port outputPort;
    
    
    public GraphNodeExample()
    {
        title = "test node";

        //入力ポートの作成
        inputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(Port));
        inputPort.name = "In";
        inputContainer.Add(inputPort);
        
        //出力ポートの作成
        outputPort =
            Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(Port));
        outputPort.name = "Out";
        outputContainer.Add(outputPort);
        
        
    }
    
    
    
    
}
