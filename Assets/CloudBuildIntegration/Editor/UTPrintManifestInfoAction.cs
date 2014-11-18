using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class UTPrintManifestInfoAction : UTAction
{
    public override IEnumerator Execute(UTContext context)
    {
        var manifest = UnityCloud.API.CloudBuildAPI.GetBuildManifest();
        Debug.Log("You are building " + manifest.ProjectId + " commit " + manifest.ScmCommitId + " on Unity " + manifest.UnityVersion);
        yield break;
    }

    [MenuItem("Assets/Create/uTomate/Unity Cloud/Print Manifest Info")]
    public static void Make()
    {
        Create<UTPrintManifestInfoAction>();
    }
}
