using System.Collections.Generic;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Management;
using UnityEngine;
using UnityEngine.XR;

namespace PureMilk.XR.WebXR
{
    /// <summary>
    /// Manages the lifecycle of WebXR subsystems.
    /// </summary>
    public class WebXRLoaderHelper : XRLoaderHelper
    {
        static List<XRSessionSubsystemDescriptor> s_SessionSubsystemDescriptors = new List<XRSessionSubsystemDescriptor>();
        static List<XRCameraSubsystemDescriptor> s_CameraSubsystemDescriptors = new List<XRCameraSubsystemDescriptor>();
        static List<XRDepthSubsystemDescriptor> s_DepthSubsystemDescriptors = new List<XRDepthSubsystemDescriptor>();
        static List<XRPlaneSubsystemDescriptor> s_PlaneSubsystemDescriptors = new List<XRPlaneSubsystemDescriptor>();
        static List<XRAnchorSubsystemDescriptor> s_AnchorSubsystemDescriptors = new List<XRAnchorSubsystemDescriptor>();
        static List<XRInputSubsystemDescriptor> s_InputSubsystemDescriptors = new List<XRInputSubsystemDescriptor>();
        static List<XRRaycastSubsystemDescriptor> s_RaycastSubsystemDescriptors=new List<XRRaycastSubsystemDescriptor>();
        /// <summary>
        /// The `XRSessionSubsystem` whose lifecycle is managed by this loader.
        /// </summary>
        /// <value>The session subsystem instance.</value>
        public XRSessionSubsystem sessionSubsystem => GetLoadedSubsystem<XRSessionSubsystem>();

        /// <summary>
        /// The `XRCameraSubsystem` whose lifecycle is managed by this loader.
        /// </summary>
        /// <value>The camera subsystem instance.</value>
        public XRCameraSubsystem cameraSubsystem => GetLoadedSubsystem<XRCameraSubsystem>();

        /// <summary>
        /// The `XRDepthSubsystem` whose lifecycle is managed by this loader.
        /// </summary>
        /// <value>The XR depth subsystem instance.</value>
        public XRDepthSubsystem depthSubsystem => GetLoadedSubsystem<XRDepthSubsystem>();

        /// <summary>
        /// The `XRPlaneSubsystem` whose lifecycle is managed by this loader.
        /// </summary>
        /// <value>The XR plane subsystem instance.</value>
        public XRPlaneSubsystem planeSubsystem => GetLoadedSubsystem<XRPlaneSubsystem>();

        /// <summary>
        /// The `XRAnchorSubsystem` whose lifecycle is managed by this loader.
        /// </summary>
        /// <value>The XR anchor subsystem instance.</value>
        public XRAnchorSubsystem anchorSubsystem => GetLoadedSubsystem<XRAnchorSubsystem>();

        /// <summary>
        /// The `XRRaycastSubsystem` whose lifecycle is managed by this loader.
        /// </summary>
        /// <value>The XR raycast subsystem instance.</value>
        public XRRaycastSubsystem raycastSubsystem => GetLoadedSubsystem<XRRaycastSubsystem>();
        /// <summary>
        /// The `XRInputSubsystem` whose lifecycle is managed by this loader.
        /// </summary>
        /// <value>The XR input subsystem instance.</value>
        public XRInputSubsystem inputSubsystem => GetLoadedSubsystem<XRInputSubsystem>();
        /// <summary>
        /// Initializes the loader.
        /// </summary>
        /// <returns>`True` if the session subsystem was successfully created, otherwise `false`.</returns>
        public override bool Initialize()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            CreateSubsystem<XRSessionSubsystemDescriptor, XRSessionSubsystem>(s_SessionSubsystemDescriptors, WebXRSessionSubSystem.k_SubsystemId);
            CreateSubsystem<XRCameraSubsystemDescriptor, XRCameraSubsystem>(s_CameraSubsystemDescriptors, WebXRCameraSubSystem.k_SubsystemId);
            CreateSubsystem<XRDepthSubsystemDescriptor, XRDepthSubsystem>(s_DepthSubsystemDescriptors, WebXRDepthSubsystem.k_SubsystemId);
            CreateSubsystem<XRPlaneSubsystemDescriptor, XRPlaneSubsystem>(s_PlaneSubsystemDescriptors, WebXRPlaneSubsystem.k_SubsystemId);
            CreateSubsystem<XRAnchorSubsystemDescriptor, XRAnchorSubsystem>(s_AnchorSubsystemDescriptors, WebXRAnchorSubsystem.k_SubsystemId);
            CreateSubsystem<XRRaycastSubsystemDescriptor, XRRaycastSubsystem>(s_RaycastSubsystemDescriptors, WebXRRaycastSubSystem.k_SubsystemId);
            CreateSubsystem<XRInputSubsystemDescriptor, XRInputSubsystem>(s_InputSubsystemDescriptors, "WebXR-Input");

            if (sessionSubsystem == null)
            {
                Debug.LogError("Failed to load session subsystem.");
            }

            return sessionSubsystem != null;
#else
            return false;
#endif
        }

        /// <summary>
        /// Starts all subsystems.
        /// </summary>
        /// <returns>`True` if the subsystems were started, otherwise `false`.</returns>
        public override bool Start()
        {
            return true;
        }

        /// <summary>
        /// Stops all subsystems.
        /// </summary>
        /// <returns>`True` if the subsystems were stopped, otherwise `false`.</returns>
        public override bool Stop()
        {
            return true;
        }

        /// <summary>
        /// Destroys each subsystem.
        /// </summary>
        /// <returns>Always returns `true`.</returns>
        public override bool Deinitialize()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            DestroySubsystem<XRCameraSubsystem>();
            DestroySubsystem<XRDepthSubsystem>();
            DestroySubsystem<XRPlaneSubsystem>();
            DestroySubsystem<XRAnchorSubsystem>();
            DestroySubsystem<XRRaycastSubsystem>();
            DestroySubsystem<XRInputSubsystem>();
            DestroySubsystem<XRSessionSubsystem>();
#endif
            return true;
        }
    }
}
