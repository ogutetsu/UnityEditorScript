using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Serializable属性を使用することでクラスのpublicをシリアル化する
[Serializable]
public class ScritableExample : ScriptableObject
{
    public int hp = 10;
    public int pow = 5;
    public float spawnTime = 5.0f;
    public Sprite background;
}
