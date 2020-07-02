using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class GraphViewExample : GraphView
{

    private GraphNodeExample startNode;
    
    public GraphViewExample() : base()
    {
       
        //ノードをドラッグ出来るようにする
        this.AddManipulator(new SelectionDragger());
        
        
        var graphviewProvider = new GraphViewProviderExample();
        graphviewProvider.Initialize(this);
        
        //右クリックでノードを作成できるようにする
        nodeCreationRequest += context =>
        {
            SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), graphviewProvider);
        };
        
        //GraphViewの背景を黒っぽくする　Addだと手前に表示されるためInsertで差し込む
        Insert(0, new GridBackground());
        
        //拡大縮小
        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
        
        startNode = new StartNode();
        //開始ノードを最初から作成しておく
        AddElement(startNode);
        
    }

    //どのノードとつながるか
    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        var connectPorts = new List<Port>();
        foreach (var port in ports.ToList())
        {
            //InputとInput、OutputとOutputは接続出来ない
            if (port.direction == startPort.direction)
            {
                continue;;
            }
            connectPorts.Add(port);
        }
        return connectPorts;
    }


    public void Exe()
    {
        //Outの接続先を取得する
        var edge = startNode.outputPort.connections.FirstOrDefault();
        if (edge == null) return;

        var currentNode = edge.input.node as GraphNodeExample;
        while (true)
        {
            currentNode.Exe();
            var next = currentNode.outputPort.connections.FirstOrDefault();
            if (next == null) break;
            currentNode = next.input.node as GraphNodeExample;

        }
    }
    
    
}
