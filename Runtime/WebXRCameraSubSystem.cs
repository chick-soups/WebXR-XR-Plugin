using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Scripting;

namespace PureMilk.XR.WebXR
{
    [Preserve]
    public class WebXRCameraSubSystem : XRCameraSubsystem
    {
        public const string k_SubSystemId = "WebXR-Camera";
        class WebXRProvider : Provider
        {

        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void RegisterDescriptor()
        {
            XRCameraSubsystemCinfo cinfo = new XRCameraSubsystemCinfo()
            {
                id = k_SubSystemId,
                providerType = typeof(WebXRProvider),
                subsystemTypeOverride = typeof(WebXRCameraSubSystem),
                supportsAverageBrightness = false,
                supportsAverageColorTemperature = false,
                supportsColorCorrection = false,
                supportsDisplayMatrix = true,
                supportsProjectionMatrix = true,
                supportsTimestamp = true,
                supportsCameraConfigurations = true,
                supportsCameraImage = true,
                supportsAverageIntensityInLumens = false,
                supportsFocusModes = true,
                supportsFaceTrackingAmbientIntensityLightEstimation = false,
                supportsFaceTrackingHDRLightEstimation = false,
                supportsWorldTrackingAmbientIntensityLightEstimation = false,
                supportsWorldTrackingHDRLightEstimation = false,
                supportsCameraGrain = false
            };
            if (!XRCameraSubsystem.Register(cinfo))
            {
                Debug.LogError($"false to regiser {k_SubSystemId} subsystem");
            }
        }
    }

}

