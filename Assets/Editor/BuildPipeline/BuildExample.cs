using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;

public static class BuildExample
{
    private static string buildPath = Application.dataPath + "/../Build";

    public static void CreateBuildFolder()
    {
        if (!System.IO.Directory.Exists(buildPath))
        {
            System.IO.Directory.CreateDirectory(buildPath);
        }
    }


    [MenuItem("Custom/Build")]
    public static void BuildMenu()
    {

        if (EditorUtility.DisplayDialog("build", "Win64用にビルドしますか?", "OK", "CANCEL"))
        {

            CreateBuildFolder();

            string[] scenes = GetEnabledScene();
            string fullPath = buildPath + "/" + BuildTarget.StandaloneWindows64 + "/" + "BuildExample";

            BuildPipeline.BuildPlayer(scenes, fullPath, BuildTarget.StandaloneWindows64, BuildOptions.None);


            EditorUtility.DisplayDialog("build", "ビルドが完了しました。", "OK");

        }
    }


    private static string[] GetEnabledScene()
    {
        List<string> scenes = new List<string>();
        foreach (var s in EditorBuildSettings.scenes)
        {
            if(s.enabled) scenes.Add(s.path);
        }

        return scenes.ToArray();
    }
    
    
}
