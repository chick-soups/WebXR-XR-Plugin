
using UnityEngine;
using UnityEditor.XR.Management.Metadata;
using UnityEditor;
using System.Collections.Generic;

namespace PureMilk.XR.WebXR.Editor
{
    public class WebXRPackage : IXRPackage
    {
        private class WebXRLoaderMetadata : IXRLoaderMetadata
        {
            public string loaderName { get;set; }
            public string loaderType { get;set; }
            public List<BuildTargetGroup> supportedBuildTargets { get;set; }
        }

        private class WebXRPakcageMetadata : IXRPackageMetadata
        {
            public string packageName { get; set; }
            public string packageId { get; set; }
            public string settingsType { get; set; }
            public List<IXRLoaderMetadata> loaderMetadata { get; set; }
        }
        private IXRPackageMetadata m_IXRPackageMetadata;
        public IXRPackageMetadata metadata
        {
            get
            {
               if(m_IXRPackageMetadata==null){
                   m_IXRPackageMetadata=new WebXRPakcageMetadata()
                   {
                        packageId="com.puremilk.xr.webxr",
                        packageName="WebXR XR Plugin",
                        settingsType="PureMilk.XR.WebXR.WebXRSettings",
                        loaderMetadata=new List<IXRLoaderMetadata>(){
                            new WebXRLoaderMetadata(){
                                loaderName="WebXR",
                                loaderType="PureMilk.XR.WebXR.WebXRLoaderHelper",
                                supportedBuildTargets=new List<BuildTargetGroup>(){
                                    BuildTargetGroup.WebGL
                                }
                            }
                        }
                   };
               }
               return m_IXRPackageMetadata;
            }
        }

        public bool PopulateNewSettingsInstance(ScriptableObject obj)
        {
            WebXRSettings packageSettings = obj as WebXRSettings;
            if (packageSettings != null)
            {
                //TODO:初始化
                // Do something here if you need to...
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
