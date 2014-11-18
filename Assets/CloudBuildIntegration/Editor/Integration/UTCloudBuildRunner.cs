namespace AncientLightStudios.UTomate.CloudBuild
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class UTCloudBuildRunner
    {
        public static void OnPreExport()
        {
            var plan = UTUnityCloudBuildConfiguration.UnityCloudBuildConfiguration.runOnPreExport;
            if (plan != null)
            {
                PlanRunHack(plan);
            }
            else
            {
                Debug.Log("No plan for pre-export. Skipping.");
            }
        }

        public static void OnPostExport(string currentlyIgnored)
        {
            var plan = UTUnityCloudBuildConfiguration.UnityCloudBuildConfiguration.runOnPostExport;
            if (plan != null)
            {
                PlanRunHack(plan);
            }
            else
            {
                Debug.Log("No plan for post-export. Skipping.");
            }
        }

        private static void PlanRunHack(UTAutomationPlan plan)
        {
            // this is a hack around Unity Cloud Build not supporting coroutine semantics.
            // will be removed once coroutine semantics are there.
            var enumerator = RunPlan(plan);
            while (enumerator.MoveNext())
            {
                // loop until done.
            }
        }

        private static IEnumerator RunPlan(UTAutomationPlan plan)
        {
            UTPreferences.DebugMode = UTUnityCloudBuildConfiguration.UnityCloudBuildConfiguration.debugMode;

            Debug.LogWarning("About to run the plan: " + plan.name);
            var start = Time.realtimeSinceStartup;

            global::UTomate.Run(plan);

            var took = Time.realtimeSinceStartup - start;
            while (UTomateRunner.Instance.IsRunning)
            {
                UTomateRunner.Instance.ContinueRunning();
                yield return null;
            }

            Debug.LogWarning("Plan ran. Took " + took + "ms");
        }
    }
}
