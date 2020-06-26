using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WindowExample : EditorWindow
{

    public static WindowExample instance;


    //#_Sはホットキー Shift+S
    //%...Ctrl / コマンド
    //#...Shift
    //LEFT/RIGHT/UP/DOWN...矢印
    //F1～F12...Fキー
    //HOME, END, PGUP, PGDN
    //_X...キー
    [MenuItem("Custom/Window/Show Window #_S")]
    public static void ShowWindow()
    {
        instance = EditorWindow.GetWindow(typeof(WindowExample)) as WindowExample;
        instance.titleContent = new GUIContent("Window");
    }


    private List<string> tabCategories;

    private string _prefabPath = "Assets/Prefabs/Items";
    private List<Item> _items;
    private Dictionary<Item.Category, List<Item>> _categorizedItems;
    private Dictionary<Item, Texture2D> _previews;
    private Vector2 _scrollPosition;
    private readonly float ButtonWidth = 80;
    private readonly float ButtonHeight = 90;
    

    private void Init()
    {
        InitTab();

        _items = EditorUtil.GetAssetWithScript<Item>(_prefabPath);
        _categorizedItems = new Dictionary<Item.Category, List<Item>>();
        _previews = new Dictionary<Item, Texture2D>();

        foreach (var category in Enum.GetValues(typeof(Item.Category)))
        {
            _categorizedItems.Add((Item.Category)category, new List<Item>());
        }
        
        foreach (var item in _items)
        {
            _categorizedItems[item.category].Add(item);
        }



        foreach (var item in _items)
        {
            if (!_previews.ContainsKey(item))
            {
                Texture2D preview = AssetPreview.GetAssetPreview(item.gameObject);
                if (preview != null)
                {
                    _previews.Add(item, preview);
                }
            }
        }
        
        
    }

    private void InitTab()
    {
        if (tabCategories == null)
        {
            tabCategories = new List<string>();
            foreach (var value in Enum.GetValues(typeof(Item.Category)))
            {
                tabCategories.Add(Enum.GetName(typeof(Item.Category), value));
            }
        }
    }


    private void OnGUI()
    {
        EditorGUILayout.LabelField("OnGUI内で描画します。");

        DrawTab();
        DrawScroll();
    }

    private void OnEnable()
    {
        Init();
    }


    private Item.Category _categorySelected;


    private void DrawTab()
    {
        int index = (int) _categorySelected;
        index = GUILayout.Toolbar(index,tabCategories.ToArray());
        _categorySelected = (Item.Category)index;
    }


    private void DrawScroll()
    {
        if (_categorizedItems[_categorySelected].Count == 0)
        {
            EditorGUILayout.HelpBox("このカテゴリは空です", MessageType.Info);
            return;
        }

        int row = Mathf.FloorToInt(position.width / ButtonWidth);
        _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
        int selectionGrid = -1;
        selectionGrid = GUILayout.SelectionGrid(
            selectionGrid,
            GetGUIContentsFromItems(),
            row,
            GetGUIStyle()
            );

        if (selectionGrid != -1)
        {
            var selectItem = _categorizedItems[_categorySelected][selectionGrid];
            Debug.Log($"{selectItem.name}を選択しました。");
        }
        
        GUILayout.EndScrollView();


    }



    private GUIContent[] GetGUIContentsFromItems()
    {
        List<GUIContent> guiContents = new List<GUIContent>();
        if (_previews.Count == _items.Count)
        {
            int totalItem = _categorizedItems[_categorySelected].Count;
            for (int i = 0; i < totalItem; i++)
            {
                GUIContent content = new GUIContent();
                content.text = _categorizedItems[_categorySelected][i].name;
                content.image = _previews[_categorizedItems[_categorySelected][i]];
                guiContents.Add(content);
            }
        }
        
        return guiContents.ToArray();
    }

    private GUIStyle GetGUIStyle()
    {
        GUIStyle guiStyle = new GUIStyle(GUI.skin.button);
        guiStyle.alignment = TextAnchor.LowerCenter;
        guiStyle.imagePosition = ImagePosition.ImageAbove;
        guiStyle.fixedHeight = ButtonHeight;
        guiStyle.fixedWidth = ButtonWidth;
        return guiStyle;
    }
    
    
    
}
