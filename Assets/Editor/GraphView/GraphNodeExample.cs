using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;



[Serializable]
public class NodeData
{
    public string NodeGUID;
    public NodeType NodeType;
    public Vector2 Position;

}

[Serializable]
public class NodeLinkData
{
    public string BaseNodeGUID;
    public string PortName;
    public string TargetGUID;
}

[Serializable]
public class NodeContainer : ScriptableObject
{
    public List<NodeLinkData> NodeLinkDatas = new List<NodeLinkData>();
    public List<NodeData> NodeDatas = new List<NodeData>();
}


public enum NodeType
{
    Start,
    String,
    Log
};


public abstract class GraphNodeExample : Node
{
    public Port inputPort;
    public Port outputPort;

    public string GUID;

    public NodeType type;
    
    public GraphNodeExample()
    {
        title = "test node";
        GUID = Guid.NewGuid().ToString();

        /*//入力ポートの作成
        inputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(Port));
        inputPort.name = "In";
        inputContainer.Add(inputPort);
        
        //出力ポートの作成
        outputPort =
            Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(Port));
        outputPort.name = "Out";
        outputContainer.Add(outputPort);*/

    }

    public abstract void Exe();


}

//開始ノード
public class StartNode : GraphNodeExample
{
    public StartNode() : base()
    {
        title = "Start";
        type = NodeType.Start;

        capabilities -= Capabilities.Deletable;
        
        outputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(Port));
        outputPort.name = "Out";
        outputContainer.Add(outputPort);
    }
    public override void Exe()
    {
        
    }
}


//ログ表示ノード
public class LogNode : GraphNodeExample
{

    public LogNode() : base()
    {
        title = "Log";
        type = NodeType.Log;

        var input = Port.Create<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(Port));
        inputContainer.Add(input);
        
        inputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(string));
        inputContainer.Add(inputPort);
        
        outputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(Port));
        outputContainer.Add(outputPort);

    }

    public override void Exe()
    {
        var edge = inputPort.connections.FirstOrDefault();
        var node = edge.output.node as StringNode;

        if (node == null) return;
        
        Debug.Log(node.Text);
    }
}

//文字列ノード
public class StringNode : GraphNodeExample
{

    private TextField _textField;
    public string Text => _textField.value;
    public StringNode() : base()
    {
        title = "String";
        type = NodeType.String;
        
        outputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(string));
        outputContainer.Add(outputPort);
        
        _textField = new TextField();
        mainContainer.Add(_textField);
        
    }

    public override void Exe()
    {
    }
}


static public class NodeFactory
{
    static public GraphNodeExample Create(NodeType type)
    {
        GraphNodeExample node = null;
        switch (type)
        {
            case NodeType.Start:
                node = new StartNode();
                break;
            case NodeType.String:
                node = new StringNode();
                break;
            case NodeType.Log:
                node = new LogNode();
                break;
        }
        return node;
    }
    
}






