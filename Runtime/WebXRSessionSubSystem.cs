using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Scripting;

namespace PureMilk.XR.WebXR
{
    [Preserve]
    public class WebXRSessionSubSystem :XRSessionSubsystem
    {
        public const string k_SubSystemId="WebXR-Session";
       class WebXRProvider:Provider{

       }
       [UnityEngine.RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
       static void RegisterDescriptor(){
           XRSessionSubsystemDescriptor.RegisterDescriptor(new XRSessionSubsystemDescriptor.Cinfo(){
               id=k_SubSystemId,
               providerType=typeof(WebXRProvider),
               subsystemTypeOverride=typeof(WebXRSessionSubSystem),
               supportsInstall=false,
               supportsMatchFrameRate = true
           });
       }
    }

}

