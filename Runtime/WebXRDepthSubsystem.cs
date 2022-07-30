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
        class XRProvider : Provider
        {
            public override TrackableChanges<XRPointCloud> GetChanges(XRPointCloud defaultPointCloud, Allocator allocator)
            {
                return new TrackableChanges<XRPointCloud>();
            }

            public override XRPointCloudData GetPointCloudData(TrackableId trackableId, Allocator allocator)
            {
                return new XRPointCloudData();
            }

        }
    }
}