using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class GraphViewExample : GraphView
{
    public GraphViewExample() : base()
    {
       
        //ノードをドラッグ出来るようにする
        this.AddManipulator(new SelectionDragger());
        
        //右クリックでノードを作成できるようにする
        nodeCreationRequest += context =>
        {
            AddElement(new GraphNodeExample());
        };
        
        //GraphViewの背景を黒っぽくする　Addだと手前に表示されるためInsertで差し込む
        Insert(0, new GridBackground());
        
        //拡大縮小
        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
        
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
}
