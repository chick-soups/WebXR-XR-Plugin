using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace PureMilk.XR.WebXR
{
    public class WebXRPlaneSubsystem : XRPlaneSubsystem
    {
        public const string k_SubsystemId = "WebXR-Plane";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
            var cinfo = new XRPlaneSubsystemDescriptor.Cinfo()
            {
                id = k_SubsystemId,
#if UNITY_2020_2_OR_NEWER
                providerType = typeof(WebXRPlaneSubsystem.WebXRProvider),
                subsystemTypeOverride = typeof(WebXRPlaneSubsystem),
#else
                subsystemImplementationType = typeof(WebXRPlaneSubsystem),
#endif
                supportsHorizontalPlaneDetection = true,
                supportsVerticalPlaneDetection = true,
                supportsArbitraryPlaneDetection = false,
                supportsBoundaryVertices = true
            };
            XRPlaneSubsystemDescriptor.Create(cinfo);
        }

        class WebXRProvider : Provider
        {
            public override void Start()
            {
                throw new System.NotImplementedException();
            }

            public override void Stop()
            {
                throw new System.NotImplementedException();
            }

            public override void Destroy()
            {
                throw new System.NotImplementedException();
            }

            public override TrackableChanges<BoundedPlane> GetChanges(BoundedPlane defaultPlane, Allocator allocator)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
