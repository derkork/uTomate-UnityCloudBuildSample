using System.Collections;
using UnityEditor;
using UnityEngine;

public class UTDumpTextAction : UTAction
{
    public UTString file;

    public override IEnumerator Execute(UTContext context)
    {
        var fileName = file.EvaluateIn(context);

        var text = System.IO.File.ReadAllText(fileName);
        Debug.Log(text);
        yield break;
    }

    [MenuItem("Assets/Create/uTomate/Misc/Dump Text")]
    public static void Make()
    {
        Create<UTDumpTextAction>();
    }
}
