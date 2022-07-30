using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using Unity.Collections;
namespace PureMilk.XR.WebXR
{
    public class WebXRAnchorSubsystem : XRAnchorSubsystem
    {
         public const string k_SubsystemId = "WebXR-Anchor";
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
            var cinfo = new XRAnchorSubsystemDescriptor.Cinfo
            {
                id = k_SubsystemId,
#if UNITY_2020_2_OR_NEWER
                providerType = typeof(WebXRAnchorSubsystem.WebXRProvider),
                subsystemTypeOverride = typeof(WebXRAnchorSubsystem),
#else
                subsystemImplementationType = typeof(WebXRAnchorSubsystem),
#endif
                supportsTrackableAttachments = true

            };
            XRAnchorSubsystemDescriptor.Create(cinfo);
        }

        class WebXRProvider:Provider{

            public override TrackableChanges<XRAnchor> GetChanges(XRAnchor defaultAnchor, Allocator allocator){
                   throw new System.NotImplementedException();
            }
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


        }
    }
  


}
