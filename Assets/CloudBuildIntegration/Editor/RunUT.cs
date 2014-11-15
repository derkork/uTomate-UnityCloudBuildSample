using System;
using System.Collections;
using UnityEngine;

public class RunUT
{
    public static void RunPlan()
    {
        UTAutomationPlan thePlan = UTomate.UTAutomationPlanByName("Prepare");
        if (thePlan == null)
        {
            throw new ArgumentException("There is no plan.");
        }

        UTomate.Run(thePlan);
    }
}
