using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//ノードを選択するためのUI作成
public class GraphViewProviderExample : ScriptableObject, ISearchWindowProvider
{

    private GraphViewExample graphView;

    public void Initialize(GraphViewExample graphView)
    {
        this.graphView = graphView;
    }
    
    //メニューツリーのリストを追加する
    public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
    {
        var entries = new List<SearchTreeEntry>();
        entries.Add(new SearchTreeGroupEntry(new GUIContent("Create Node")));
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsClass && !type.IsAbstract && (type.IsSubclassOf(typeof(GraphNodeExample))))
                {
                    entries.Add(new SearchTreeEntry(new GUIContent(type.Name))
                    {
                        level = 1, userData = type
                    });
                }
            }
        }
        return entries;
    }

    //作成ノードを追加する
    public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
    {
        var type = SearchTreeEntry.userData as System.Type;
        var node = Activator.CreateInstance(type) as GraphNodeExample;
        graphView.AddElement(node);
        return true;
    }
}
