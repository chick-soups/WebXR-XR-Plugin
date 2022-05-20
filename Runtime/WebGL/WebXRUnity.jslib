mergeInto(LibraryManager.library, {
    WebXR_XRSystem_IsSessionSupported: function (context, callback) {
        console.log("javascript");

    if (navigator.xr) {
      navigator.xr.isSessionSupported("immersive-ar").then(
        function (result) {
          console.log("javascript "+result);
          Runtime.dynCall("vii", callback, context, result);
        },
        function (result) {
            console.log("javascript "+result);
            Runtime.dynCall("vii", callback, context, result);
        }
      );
    } else {
        console.log("javascript "+false);
      Runtime.dynCall("vii", callback, context, false);
    }
  },
});
