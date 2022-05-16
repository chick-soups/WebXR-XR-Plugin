using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Scripting;

namespace PureMilk.XR.WebXR
{
    [Preserve]
    public class WebXRRaycastSubSystem : XRRaycastSubsystem
    {
        public const string k_SubsystemId = "WebXR-Raycast";
        class WebXRProvider : Provider
        {

        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void RegisterDescriptor()
        {
            XRRaycastSubsystemDescriptor.Cinfo cinfo = new XRRaycastSubsystemDescriptor.Cinfo()
            {
                id = k_SubsystemId,
                providerType = typeof(WebXRProvider),
                subsystemTypeOverride = typeof(WebXRRaycastSubSystem),
                supportsViewportBasedRaycast = true,
                supportsWorldBasedRaycast = true,
                supportedTrackableTypes = (TrackableType.Planes & ~TrackableType.PlaneWithinInfinity) |
                    TrackableType.FeaturePoint,
                supportsTrackedRaycasts = true,

            };
            XRRaycastSubsystemDescriptor.RegisterDescriptor(cinfo);
        }
    }
}

