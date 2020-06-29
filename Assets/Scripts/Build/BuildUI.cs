using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : MonoBehaviour
{
    public Text Date;
    public Text Arg;

    void Start()
    {
        Date.text = "Date : " + Build.BuildInfo.Date;
        Arg.text = "コマンド引数 : " + Build.BuildInfo.Arg;
    }
}
