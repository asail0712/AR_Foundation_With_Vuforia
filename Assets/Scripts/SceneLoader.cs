using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

//using Vuforia;

public class SceneLoader : MonoBehaviour
{

	private void Update()
	{
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Alpha1))
#else
		if (Input.touchCount == 2)
#endif
		{
			XRGeneralSettings xrSetting = XRGeneralSettings.Instance;

			if (xrSetting != null)
			{
				xrSetting.Manager.StopSubsystems();
				xrSetting.Manager.DeinitializeLoader();

				xrSetting.Manager.InitializeLoaderSync();
				xrSetting.Manager.StartSubsystems();
			}

			SceneManager.LoadSceneAsync(1);
		}

#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Alpha2))
#else
		if (Input.touchCount == 3)
#endif
		{
			SceneManager.LoadSceneAsync(2);
		}
	}
}
