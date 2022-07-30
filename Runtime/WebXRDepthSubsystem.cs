using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using Unity.Collections;
namespace PureMilk.XR.WebXR
{
    public class WebXRDepthSubsystem : XRDepthSubsystem
    {
        public const string k_SubsystemId = "WebXR-Depth";
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
            var cinfo = new XRDepthSubsystemDescriptor.Cinfo()
            {
                id = k_SubsystemId,
#if UNITY_2020_2_OR_NEWER
                providerType = typeof(WebXRDepthSubsystem.WebXRProvider),
                subsystemTypeOverride = typeof(WebXRDepthSubsystem),
#else
                implementationType = typeof(WebXRDepthSubsystem),
#endif
                supportsFeaturePoints = true,
                supportsUniqueIds = true,
                supportsConfidence = true
            };
            XRDepthSubsystemDescriptor.RegisterDescriptor(cinfo);
        }
        class WebXRProvider : Provider
        {
            public override TrackableChanges<XRPointCloud> GetChanges(XRPointCloud defaultPointCloud, Allocator allocator)
            {
                throw new System.NotImplementedException();
            }

            public override XRPointCloudData GetPointCloudData(TrackableId trackableId, Allocator allocator)
            {
                 throw new System.NotImplementedException();
            }

        }
    }
}