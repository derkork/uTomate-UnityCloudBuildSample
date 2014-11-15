using System;
using System.Collections;
using UnityEngine;

public class RunUT
{
    public static void RunPlan(string name)
    {
        UTAutomationPlan thePlan = UTomate.UTAutomationPlanByName(name);
        if (thePlan == null)
        {
            throw new ArgumentException("There is no plan named '" + name + "'");
        }

        UTomate.Run(thePlan);
    }
}
