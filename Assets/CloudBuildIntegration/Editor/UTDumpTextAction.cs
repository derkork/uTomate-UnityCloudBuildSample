using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class UTDumpTextAction : UTAction
{
    public UTString[] includes;
    public UTString[] excludes;

    public override IEnumerator Execute(UTContext context)
    {
        var theIncludes = EvaluateAll(includes, context);
        var theExcludes = EvaluateAll(excludes, context);
        var files = UTFileUtils.CalculateFileset(UTFileUtils.ProjectAssets, theIncludes, theExcludes, UTFileUtils.FileSelectionMode.Files);
        foreach (var file in files)
        {
            var text = System.IO.File.ReadAllText(file);
            Debug.Log(file + "\n" + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text)));
        }
        yield break;
    }

    [MenuItem("Assets/Create/uTomate/Misc/Dump Text")]
    public static void Make()
    {
        Create<UTDumpTextAction>();
    }
}
