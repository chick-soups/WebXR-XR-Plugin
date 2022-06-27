#include "WebXRInputLifeCycleProvider.h"
#include "WebXRInputProvider.h"

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputLifeCycleProvider::Initialize(UnitySubsystemHandle handle, void *data)
{

    UnityXRInputProvider inputProvider;
    inputProvider.userData = nullptr;
    inputProvider.Tick = &WebXRInputProvider::Tick;
    inputProvider.FillDeviceDefinition = &WebXRInputProvider::FillDeviceDefinition;
    inputProvider.UpdateDeviceConfig = &WebXRInputProvider::UpdateDeviceConfig;
    inputProvider.UpdateDeviceState = &WebXRInputProvider::UpdateDeviceState;
    inputProvider.HandleEvent = &WebXRInputProvider::HandleEvent;
    inputProvider.HandleRecenter = &WebXRInputProvider::HandleRecenter;
    inputProvider.HandleHapticImpulse = &WebXRInputProvider::HandleHapticImpulse;
    inputProvider.HandleHapticBuffer = &WebXRInputProvider::HandleHapticBuffer;
    inputProvider.QueryHapticCapabilities = &WebXRInputProvider::QueryHapticCapabilities;
    inputProvider.HandleHapticStop = &WebXRInputProvider::HandleHapticStop;
    inputProvider.QueryTrackingOriginMode = &WebXRInputProvider::QueryTrackingOriginMode;
    inputProvider.QuerySupportedTrackingOriginModes = &WebXRInputProvider::QuerySupportedTrackingOriginModes;
    inputProvider.HandleSetTrackingOriginMode = &WebXRInputProvider::HandleSetTrackingOriginMode;
    inputProvider.TryGetDeviceStateAtTime = &WebXRInputProvider::TryGetDeviceStateAtTime;
    return s_XrInput->RegisterInputProvider(handle, &inputProvider);
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputLifeCycleProvider::Start(UnitySubsystemHandle handle, void *data)
{
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

void UNITY_INTERFACE_API WebXRInputLifeCycleProvider::Stop(UnitySubsystemHandle handle, void *data)
{
}

void UNITY_INTERFACE_API WebXRInputLifeCycleProvider::Shutdown(UnitySubsystemHandle handle, void *data)
{
}

void WebXRInputLifeCycleProvider::Register(IUnityInterfaces *unityInterfaces)
{
    s_XrInput = unityInterfaces->Get<IUnityXRInputInterface>();
    UnityLifecycleProvider inputLifeCycleProvider;
    inputLifeCycleProvider.userData = nullptr;
    inputLifeCycleProvider.Initialize = &WebXRInputLifeCycleProvider::Initialize;
    inputLifeCycleProvider.Start = &WebXRInputLifeCycleProvider::Start;
    inputLifeCycleProvider.Stop = &WebXRInputLifeCycleProvider::Stop;
    inputLifeCycleProvider.Shutdown = &WebXRInputLifeCycleProvider::Shutdown;
    s_XrInput->RegisterLifecycleProvider("UnityNative", "WebAR-Input", &inputLifeCycleProvider);
}