namespace UnityCloud.API
{
    using System.Collections.Generic;

    // usings go INSIDE the namespace so they don't conflict with the rest
    using UnityEngine;

#if UNITY_CLOUD_BUILD
    using UnityCloud;
#endif

    /// <summary>
    /// API against Unity's build manifest object. Works locally (on a mock dictionary) and in the cloud.
    /// </summary>
    public class CloudBuildManifest
    {
#if UNITY_CLOUD_BUILD
        private BuildManifestObject buildManifestObject;
#else
        private Dictionary<string, string> contents;
#endif

#if UNITY_CLOUD_BUILD
        internal CloudBuildManifest(BuildManifestObject buildManifestObject)
        {
            this.buildManifestObject = buildManifestObject;
        }
#else

        internal CloudBuildManifest()
        {
            this.contents = new Dictionary<string, string>();
        }

#endif

        public string ScmCommitId
        {
            get
            {
                return Get("scmCommitId", null);
            }
            set
            {
                Set("scmCommitId", value);
            }
        }

        public string ScmBranch
        {
            get
            {
                return Get("scmBranch", null);
            }
            set
            {
                Set("scmBranch", value);
            }
        }

        public string BuildNumber
        {
            get
            {
                return Get("buildNumber", null);
            }
            set
            {
                Set("buildNumber", value);
            }
        }

        public string BuildStartTime
        {
            get
            {
                return Get("buildStartTime", null);
            }
            set
            {
                Set("buildStartTime", value);
            }
        }

        public string ProjectId
        {
            get
            {
                return Get("projectId", null);
            }
            set
            {
                Set("projectId", value);
            }
        }

        public string BundleId
        {
            get
            {
                return Get("bundleId", null);
            }
            set
            {
                Set("bundleId", value);
            }
        }

        public string UnityVersion
        {
            get
            {
                return Get("unityVersion", null);
            }
            set
            {
                Set("unityVersion", value);
            }
        }

        public string XCodeVersion
        {
            get
            {
                return Get("xCodeVersion", null);
            }
            set
            {
                Set("xCodeVersion", value);
            }
        }

        public string CloudBuildTargetName
        {
            get
            {
                return Get("cloudBuildTargetName", null);
            }
            set
            {
                Set("cloudBuildTargetName", value);
            }
        }

        public string Get(string key, string defaultValue)
        {
#if UNITY_CLOUD_BUILD
            return buildManifestObject.GetValue(key, defaultValue);
#else
            string result;
            if (!contents.TryGetValue(key, out result))
            {
                return defaultValue;
            }
            return result;
#endif
        }

        public void Set(string key, string value)
        {
#if UNITY_CLOUD_BUILD
            buildManifestObject.SetValue(key, value);
#else
            contents[key] = value;
#endif
        }
    }
}
