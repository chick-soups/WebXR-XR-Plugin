using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Scripting;
using System;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEngine.SubsystemsImplementation;
using AOT;

namespace PureMilk.XR.WebXR
{
    [Preserve]
    public class WebXRSessionSubSystem : XRSessionSubsystem
    {
        public const string k_SubsystemId = "WebXR-Session";
        class WebXRProvider : Provider
        {
            /// <summary>
            /// Invoked to start or resume a session. This is different from <see cref="OnApplicationResume"/>.
            /// </summary>
            public override void Start() {

             }

            /// <summary>
            /// Invoked to pause a running session. This is different from <see cref="OnApplicationPause"/>.
            /// </summary>
            public override void Stop() { }

            /// <summary>
            /// Perform any per-frame update logic here.
            /// </summary>
            /// <param name="updateParams">Parameters about the current state that may be needed to inform the session.</param>
            public override void Update(XRSessionUpdateParams updateParams) { }

            /// <summary>
            /// Perform any per-frame update logic here. The session should use the configuration indicated by
            /// <paramref name="configuration.descriptor.identifier"/>, which should be one of the ones returned
            /// by <see cref="GetConfigurationDescriptors(Unity.Collections.Allocator)"/>.
            /// </summary>
            /// <param name="updateParams">Parameters about the current state that might be needed to inform the session.</param>
            /// <param name="configuration">The configuration the session should use.</param>
            public override void Update(XRSessionUpdateParams updateParams, Configuration configuration) { }

            /// <summary>
            /// Should return the features requested by the enabling of other <c>Subsystem</c>s.
            /// </summary>
            public override Feature requestedFeatures => Feature.None;

            /// <summary>
            /// Get or set the requested tracking mode (for example, the <see cref="Feature.AnyTrackingMode"/> bits).
            /// </summary>
            public override Feature requestedTrackingMode
            {
                get => Feature.None;
                set { }
            }

            /// <summary>
            /// Get the current tracking mode (for example, the <see cref="Feature.AnyTrackingMode"/> bits).
            /// </summary>
            public override Feature currentTrackingMode => Feature.None;

            /// <summary>
            /// This getter should allocate a new <c>NativeArray</c> using <paramref name="allocator"/>
            /// and populate it with the supported <see cref="ConfigurationDescriptor"/>s.
            /// </summary>
            /// <param name="allocator">The <c>[Allocator](https://docs.unity3d.com/ScriptReference/Unity.Collections.Allocator.html)</c>
            /// to use to create the returned <c>NativeArray</c>.</param>
            /// <returns>A newly allocated <c>NativeArray</c> of <see cref="ConfigurationDescriptor"/>s that describes the capabilities
            /// of all the supported configurations.</returns>
            public override NativeArray<ConfigurationDescriptor> GetConfigurationDescriptors(Allocator allocator) => default;

            /// <summary>
            /// Stop the session and destroy all associated resources.
            /// </summary>
            public override void Destroy() { }

            /// <summary>
            /// Reset the session. The behavior should be equivalent to destroying and recreating the session.
            /// </summary>
            public override void Reset() { }

            /// <summary>
            /// Invoked when the application is paused.
            /// </summary>
            public override void OnApplicationPause() { }

            /// <summary>
            /// Invoked when the application is resumed.
            /// </summary>
            public override void OnApplicationResume() { }

            /// <summary>
            /// Get a pointer to an object associated with the session.
            /// Callers should be able to manipulate the session in their own code using this.
            /// </summary>
            public override IntPtr nativePtr => IntPtr.Zero;

            /// <summary>
            /// Get the session's availability, such as whether the platform supports XR.
            /// </summary>
            /// <returns>A <see cref="Promise{T}"/> that the caller can yield on until availability is determined.</returns>
            public override Promise<SessionAvailability> GetAvailabilityAsync()
            {
                return Promise<SessionAvailability>.CreateResolvedPromise(SessionAvailability.Installed);
                // return ExecuteAsync<SessionAvailability>((context)=>{
                //    NativeApi.WebXR_XRSystem_IsSessionSupported(context,OnIsSessionSupported);
                // });
                
            }

            /// <summary>
            /// Attempt to update or install necessary XR software. Will only be called if
            /// <see cref="XRSessionSubsystemDescriptor.supportsInstall"/> is true.
            /// </summary>
            /// <returns></returns>
            public override Promise<SessionInstallationStatus> InstallAsync()
            {
                return Promise<SessionInstallationStatus>.CreateResolvedPromise(SessionInstallationStatus.ErrorInstallNotSupported);
            }

            /// <summary>
            /// Get the <see cref="TrackingState"/> for the session.
            /// </summary>
            public override TrackingState trackingState => TrackingState.None;

            /// <summary>
            /// Get the <see cref="NotTrackingReason"/> for the session.
            /// </summary>
            public override NotTrackingReason notTrackingReason => NotTrackingReason.Unsupported;

            /// <summary>
            /// Get a unique identifier for this session.
            /// </summary>
            public override Guid sessionId => Guid.Empty;

            /// <summary>
            /// Whether the AR session update is synchronized with the Unity frame rate.
            /// If <c>true</c>, <see cref="Update(XRSessionUpdateParams)"/> will block until the next AR frame is available.
            /// </summary>
            public override bool matchFrameRateEnabled => false;

            /// <summary>
            /// Whether the AR session update should be synchronized with the Unity frame rate.
            /// If <c>true</c>, <see cref="Update(XRSessionUpdateParams)"/> should block until the next AR frame is available.
            /// Must be implemented if
            /// <see cref="XRSessionSubsystemDescriptor.supportsMatchFrameRate"/>
            /// is <c>True</c>.
            /// </summary>
            public override bool matchFrameRateRequested
            {
                get => false;
                set
                {
                    if (value)
                    {
                        throw new NotSupportedException("Matching frame rate is not supported.");
                    }
                }
            }

            /// <summary>
            /// The native update rate of the AR Session. Must be implemented if
            /// <see cref="XRSessionSubsystemDescriptor.supportsMatchFrameRate"/>
            /// is <c>True</c>.
            /// </summary>
            public override int frameRate =>
                throw new NotSupportedException("Querying the frame rate is not supported by this session subsystem.");


            private static Promise<T> ExecuteAsync<T>(Action<IntPtr> callback) where T : struct
            {
                WebXRPromise<T> promise = new WebXRPromise<T>();
                GCHandle gchandle = GCHandle.Alloc(promise);
                IntPtr intPtr = GCHandle.ToIntPtr(gchandle);
                callback(intPtr);
                return promise;
            }

            private static void ResolvePromise<T>(IntPtr context, T arg) where T : struct
            {
                GCHandle gch = GCHandle.FromIntPtr(context);
                var promise = (WebXRPromise<T>)gch.Target;
                if (promise != null)
                    promise.Resolve(arg);
                gch.Free();
            }

            [MonoPInvokeCallback(typeof(Action<IntPtr,bool>))]
            private static void OnIsSessionSupported(IntPtr context,bool isSupported){
                SessionAvailability availability=SessionAvailability.None;
                if(isSupported){
                    availability=SessionAvailability.Installed;
                }
                ResolvePromise<SessionAvailability>(context,availability);
            }
        }


        [UnityEngine.RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
            XRSessionSubsystemDescriptor.RegisterDescriptor(new XRSessionSubsystemDescriptor.Cinfo()
            {
                id = k_SubsystemId,
                providerType = typeof(WebXRProvider),
                subsystemTypeOverride = typeof(WebXRSessionSubSystem),
                supportsInstall = false,
                supportsMatchFrameRate = true
            });
        }

        internal static class NativeApi
        {
             [DllImport("__Internal")]
             public extern static void WebXR_XRSystem_IsSessionSupported(IntPtr context,Action<IntPtr,bool> callback);


        }
    }

}

