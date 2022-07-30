#include "WebXRInputProvider.h"

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::Tick(UnitySubsystemHandle handle, void *userData, UnityXRInputUpdateType updateType)
{
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}
UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::FillDeviceDefinition(UnitySubsystemHandle handle, void *userData, UnityXRInternalInputDeviceId deviceId, UnityXRInputDeviceDefinition *definition)
{
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::UpdateDeviceConfig(UnitySubsystemHandle handle, void *userData, UnityXRInternalInputDeviceId deviceId, UnityXRInputDeviceConfig *config)
{
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::UpdateDeviceState(UnitySubsystemHandle handle, void *userData, UnityXRInternalInputDeviceId deviceId, UnityXRInputUpdateType updateType, UnityXRInputDeviceState *state) {
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::HandleEvent(UnitySubsystemHandle handle, void *userData, unsigned int eventType, UnityXRInternalInputDeviceId deviceId, void *buffer, unsigned int size) {
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::HandleRecenter(UnitySubsystemHandle handle, void *userData) {
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::HandleHapticImpulse(UnitySubsystemHandle handle, void *userData, UnityXRInternalInputDeviceId deviceId, int channel, float amplitude, float duration) {
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::HandleHapticBuffer(UnitySubsystemHandle handle, void *userData, UnityXRInternalInputDeviceId deviceId, int channel, unsigned int bufferSize, const unsigned char *const buffer) {
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::QueryHapticCapabilities(UnitySubsystemHandle handle, void *userData, UnityXRInternalInputDeviceId deviceId, UnityXRHapticCapabilities *capabilities) {
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::HandleHapticStop(UnitySubsystemHandle handle, void *userData, UnityXRInternalInputDeviceId deviceId) {
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::QueryTrackingOriginMode(UnitySubsystemHandle handle, void *userData, UnityXRInputTrackingOriginModeFlags *trackingOriginMode) {
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::QuerySupportedTrackingOriginModes(UnitySubsystemHandle handle, void *userData, UnityXRInputTrackingOriginModeFlags *supportedTrackingOriginModes) {
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::HandleSetTrackingOriginMode(UnitySubsystemHandle handle, void *userData, UnityXRInputTrackingOriginModeFlags trackingOriginMode) {
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}

UnitySubsystemErrorCode UNITY_INTERFACE_API WebXRInputProvider::TryGetDeviceStateAtTime(UnitySubsystemHandle handle, void *userData, UnityXRTimeStamp time, UnityXRInternalInputDeviceId deviceId, UnityXRInputDeviceState *state) {
    UnitySubsystemErrorCode errorCode(kUnitySubsystemErrorCodeSuccess);
    return errorCode;
}
