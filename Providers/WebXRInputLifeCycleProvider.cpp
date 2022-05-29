#pragma once
#include "WebXRInputLifeCycleProvider.h"
#include "WebXRInputProvider.h"

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputLifeCycleProvider::Initialize(UnitySubsystemHandle handle, void *data)
{
    UnityXRInputProvider inputProvider{
        nullptr,
        &WebXRInputProvider::Tick,
        &WebXRInputProvider::FillDeviceDefinition,
        &WebXRInputProvider::UpdateDeviceConfig,
        &WebXRInputProvider::UpdateDeviceState,
        &WebXRInputProvider::HandleEvent,
        &WebXRInputProvider::HandleRecenter,
        &WebXRInputProvider::HandleHapticImpulse,
        &WebXRInputProvider::HandleHapticBuffer,
        &WebXRInputProvider::QueryHapticCapabilities,
        &WebXRInputProvider::HandleHapticStop,
        &WebXRInputProvider::QueryTrackingOriginMode,
        &WebXRInputProvider::QuerySupportedTrackingOriginModes,
        &WebXRInputProvider::HandleSetTrackingOriginMode,
        &WebXRInputProvider::TryGetDeviceStateAtTime};
    s_XrInput->RegisterInputProvider(handle, &inputProvider);
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputLifeCycleProvider::Start(UnitySubsystemHandle handle, void *data)
{
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
    UnityLifecycleProvider inputLifeCycleProvider{
        nullptr,
        &WebXRInputLifeCycleProvider::Initialize,
        &WebXRInputLifeCycleProvider::Start,
        &WebXRInputLifeCycleProvider::Stop,
        &WebXRInputLifeCycleProvider::Shutdown};
    s_XrInput->RegisterLifecycleProvider("UnityNative", "WebAR-Input", &inputLifeCycleProvider);
}