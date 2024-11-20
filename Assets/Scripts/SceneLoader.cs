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
		if (Input.GetKeyDown(KeyCode.Alpha1))
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

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			SceneManager.LoadSceneAsync(2);
		}
	}
}
