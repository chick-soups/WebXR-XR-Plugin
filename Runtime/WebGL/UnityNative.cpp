#pragma once
#include "../../CommonHeaders/ProviderInterface/IUnityInterface.h";
#include "../../Providers/WebXRInputLifeCycleProvider.h";


extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API
UnityPluginLoad(IUnityInterfaces *unityInterfaces)
{
    WebXRInputLifeCycleProvider::Register(unityInterfaces);
}
extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API
UnityPluginUnload()
{
   
}
