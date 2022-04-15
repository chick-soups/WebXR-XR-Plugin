using UnityEngine;
using UnityEngine.XR.Management;
using System.IO;
using UnityEditor;

namespace PureMilk.XR.WebXR
{
    /// <summary>
    /// Holds settings that are used to configure the Unity ARCore Plugin.
    /// </summary>
    [System.Serializable]
    [XRConfigurationData("WebXR", "PureMilk.XR.WebXR.WebXRSettings")]
    public class WebXRSettings : ScriptableObject
    {
       
    }
}

