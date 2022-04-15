using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.XR.Management;
using UnityEditor.Build.Reporting;
using UnityEditor;

namespace PureMilk.XR.WebXR.Editor
{
    public class WebXRBuildProcessor : XRBuildHelper<WebXRSettings>
    {
        public override string BuildSettingsKey
        {
            get
            {
                return "PureMilk.XR.WebXR.Editor.WebXRSettings";
            }
        }
        public override void OnPreprocessBuild(BuildReport report)
        {
            //Should call base class implementation
            base.OnPreprocessBuild(report);
        }
        public override void OnPostprocessBuild(BuildReport report)
        {
            //Should call base class implementation
            base.OnPostprocessBuild(report);
        }

        public override Object SettingsForBuildTargetGroup(BuildTargetGroup buildTargetGroup)
        {
            if (buildTargetGroup == BuildTargetGroup.WebGL)
            {
                Object settings;
                if (EditorBuildSettings.TryGetConfigObject(BuildSettingsKey, out settings))
                {
                    return settings;
                }
                else
                {
                      Debug.LogError("can not find config objecct:"+BuildSettingsKey);
                }
            }
            {
                return null;
            }
        }
    }
}