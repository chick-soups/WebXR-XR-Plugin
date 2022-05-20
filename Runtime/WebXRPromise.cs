using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.ARSubsystems;
namespace PureMilk.XR.WebXR
{
    public class WebXRPromise<T> : Promise<T>
    {
        protected override void OnKeepWaiting()
        {
            
        }

        internal new void Resolve(T result)
        {
            base.Resolve(result);
        }
    }
}


