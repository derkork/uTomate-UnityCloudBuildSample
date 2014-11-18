namespace UnityCloud.API
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

#if UNITY_CLOUD_BUILD
    using UnityCloud;
#endif

    public class CloudBuildAPI
    {
        public static CloudBuildManifest GetBuildManifest()
        {
#if  UNITY_CLOUD_BUILD
            return new CloudBuildManifest(BuildManifestObject.LoadCloudBuildManifest());
#else
            var result = new CloudBuildManifest();
            // add a few dummy values
            result.ProjectId = "com.yourproject.id[Local Dummy]";
            result.ScmBranch = "master[Local Dummy]";
            result.ScmCommitId = "da39a3ee5e6b4b0d3255bfef95601890afd80709[Local Dummy]";
            result.UnityVersion = Application.unityVersion;
            result.XCodeVersion = "5.5 [Local Dummy]";
            result.BuildNumber = "182 [Local Dummy]";
            result.BuildStartTime = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
            result.BundleId = "com.yourbundle.id[Local Dummy]";
            return result;
#endif
        }
    }
}
