using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
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

    //スライドバーを表示 (最小,最大を指定)
    [Range(0,100)]
    public int range = 0;


    //マルチライン (テキストの行数を指定します)
    [Multiline(3)]
    public string Multiline;
    
    //スクロール可能なテキスト領域
    [TextArea(2, 4)] public string TextArea;

    [ContextMenu("コンテキストメニューに表示")]
    public void ContextMsg()
    {
        Debug.Log("コンテキストメニューから選択しました。");
    }
    
    //コンテキストメニューのアイテム
    [ContextMenuItem("値を0クリア", "ValueReset")]
    public int reset = 10;

    //メソッドは非静的でないとダメ
    public void ValueReset()
    {
        reset = 0;
    }

    [Header("ヘッダーです")] public int head1 = 1;
    public int head2 = 2;

    //指定された分のスペースを追加します。
    [Space(20)] public int space = 1;
    
    //ツールチップ
    [Tooltip("ツールチップを表示")] public int tooltip = 1;
    
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
