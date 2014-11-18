using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class UTPrintManifestInfoAction : UTAction
{
    public override IEnumerator Execute(UTContext context)
    {
        var manifest = UnityCloud.API.CloudBuildAPI.GetBuildManifest();
        Debug.Log("Manifest Info: \n" +
            "Project: " + manifest.ProjectId + "\n" +
            "Start Time: " + manifest.BuildStartTime + "\n" +
            "SCM Commit-ID: " + manifest.ScmCommitId + "\n" +
            "SCM Branch: " + manifest.ScmBranch + "\n" +
            "Build Number: " + manifest.BuildNumber + "\n" +
            "Bundle-ID: " + manifest.BundleId + "\n" +
            "Target Name: " + manifest.CloudBuildTargetName + "\n" +
            "Unity Version: " + manifest.UnityVersion + "\n" +
            "XCode Version: " + manifest.XCodeVersion + "\n");
        yield break;
    }

    [MenuItem("Assets/Create/uTomate/Unity Cloud/Print Manifest Info")]
    public static void Make()
    {
        Create<UTPrintManifestInfoAction>();
    }
}
