using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class GraphViewWindow : EditorWindow
{
    private GraphViewExample _graphView;

    [MenuItem("Custom/GraphView/Window")]
    static public void ShowWindow() => GetWindow<GraphViewWindow>();
    

    private void OnEnable()
    {
        GenerateToolbar();
        
        _graphView = new GraphViewExample()
        {
            style = { flexGrow = 1}
        };
        rootVisualElement.Add(_graphView);
        
        
        rootVisualElement.Add(new Button(_graphView.Exe) { text = "実行"});
        
    }


    void GenerateToolbar()
    {
        var toolbar = new Toolbar();

        
        toolbar.Add(new Button(()=>SaveDialog()) { text = "Save"});
        toolbar.Add(new Button(()=>LoadDialog()) { text = "Load"});


        rootVisualElement.Add(toolbar);
    }


    public void SaveDialog()
    {
        var path = EditorUtility.SaveFilePanel("保存", "", "New", "asset");
        if (path == "") return;
        SaveGraph(path);
    }

    public void LoadDialog()
    {
        var path = EditorUtility.OpenFilePanel("ファイルを開く", "", "asset");
        if (path == "") return;
        var temp = Regex.Split(path, "/Assets/");
        path = "Assets/" + temp[1];
        LoadGraph(path);
    }
    

    public void SaveGraph(string path)
    {
        var edges = _graphView.edges.ToList();
        var nodes = _graphView.nodes.ToList().Cast<GraphNodeExample>().ToList();

        if(!edges.Any()) return;

        var nodeContainer = ScriptableObject.CreateInstance<NodeContainer>();
        var connetecPorts = edges.Where(x => x.input.node != null).ToArray();
        foreach (var port in connetecPorts)
        {
            var outputNode = port.output.node as GraphNodeExample;
            var inputNode = port.input.node as GraphNodeExample;
            
            nodeContainer.NodeLinkDatas.Add(new NodeLinkData()
            {
                BaseNodeGUID = outputNode.GUID,
                PortName = port.output.portName,
                TargetGUID = inputNode.GUID
            });
        }

        foreach (var node in nodes)
        {
            nodeContainer.NodeDatas.Add(new NodeData()
            {
                NodeGUID = node.GUID,
                NodeType = node.type,
                Position = node.GetPosition().position
            });
        }
        
        AssetDatabase.CreateAsset(nodeContainer, path);
        AssetDatabase.SaveAssets();
    }

    public void LoadGraph(string path)
    {
        var cache = AssetDatabase.LoadAssetAtPath<NodeContainer>(path);
        if (cache == null) return;

        ClearView();
        GenerateNodes(cache);
        ConnectNodes(cache);


    }

    private void ConnectNodes(NodeContainer cache)
    {
        var nodes = _graphView.nodes.ToList().Cast<GraphNodeExample>().ToList();
        for (var i = 0; i < nodes.Count; i++)
        {
            var k = i;
            var connections = cache.NodeLinkDatas.Where(x => x.BaseNodeGUID == nodes[k].GUID).ToList();
            for (var j = 0; j < connections.Count; j++)
            {
                var targetGUID = connections[j].TargetGUID;
                var baseGUID = connections[j].BaseNodeGUID;
                var targetNode = nodes.First(x => x.GUID == targetGUID);
                var baseNode = nodes.First(x => x.GUID == baseGUID);

                //LinkNode((Port)baseNode.outputContainer[0], (Port) targetNode.inputContainer[0]);


            }
        }

    }

    private void LinkNode(Port inputPort, Port outputPort)
    {
        var temp = new Edge()
        {
            output = outputPort,
            input = inputPort
        };
        temp?.input.Connect(temp);
        temp?.output.Connect(temp);
        _graphView.Add(temp);
    }

    private void GenerateNodes(NodeContainer container)
    {
        foreach (var node in container.NodeDatas)
        {
            var temp = NodeFactory.Create(node.NodeType);
            temp.GUID = node.NodeGUID;
            temp.SetPosition(new Rect(node.Position, new Vector2(200,50)));
            _graphView.AddElement(temp);
        }
        
    }

    private void ClearView()
    {
        var edges = _graphView.edges.ToList();
        var nodes = _graphView.nodes.ToList().Cast<GraphNodeExample>().ToList();
        foreach (var node in nodes)
        {
            edges.Where(x => x.input.node == node).ToList()
                .ForEach(edge => _graphView.RemoveElement(edge));
            _graphView.RemoveElement(node);
        }
    }
}
