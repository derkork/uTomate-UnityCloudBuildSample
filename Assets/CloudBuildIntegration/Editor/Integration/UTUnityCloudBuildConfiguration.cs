namespace AncientLightStudios.UTomate.CloudBuild
{
    using System.Collections;
    using UnityEditor;
    using UnityEngine;

    public class UTUnityCloudBuildConfiguration : ScriptableObject
    {
        private const string CloudBuildConfigurationPath = "Assets/uTomateCloudBuildConfiguration.asset";

        [SerializeField]
        public UTAutomationPlan runOnPreExport;

        [SerializeField]
        public UTAutomationPlan runOnPostExport;

        public bool debugMode;

        public static void Create()
        {
        }

        private static UTUnityCloudBuildConfiguration cloudBuildConfiguration;

        [MenuItem("Window/uTomate/Edit Cloud Build Configuration", priority = 10000)]
        public static void ShowCloudBuildConfiguration()
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = UnityCloudBuildConfiguration;
        }

        public static UTUnityCloudBuildConfiguration UnityCloudBuildConfiguration
        {
            get
            {
                if (cloudBuildConfiguration == null)
                {
                    try
                    {
                        cloudBuildConfiguration = (UTUnityCloudBuildConfiguration)AssetDatabase.LoadAssetAtPath(CloudBuildConfigurationPath, typeof(UTUnityCloudBuildConfiguration));
                    }
                    catch (UnityException)
                    {
                        // ok asset might not exist yet.
                    }
                    if (cloudBuildConfiguration == null)
                    {
                        Debug.Log("Creating uTomate Cloud Build Configuration.");
                        // create it
                        cloudBuildConfiguration = ScriptableObject.CreateInstance<UTUnityCloudBuildConfiguration>();
                        AssetDatabase.CreateAsset(cloudBuildConfiguration, CloudBuildConfigurationPath);
                        EditorUtility.SetDirty(cloudBuildConfiguration);
                    }
                }
                return cloudBuildConfiguration;
            }
        }
    }
}
