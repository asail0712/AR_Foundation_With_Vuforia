using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Management;

//using Vuforia;

public class SceneLoader : MonoBehaviour
{
	private bool bARFoundation = false;

	private void Start()
	{
		XRGeneralSettings xrSetting = XRGeneralSettings.Instance;

		if (xrSetting != null)
		{
			xrSetting.Manager.StopSubsystems();
			xrSetting.Manager.DeinitializeLoader();

			xrSetting.Manager.InitializeLoaderSync();
			xrSetting.Manager.StartSubsystems();
		}


		CheckARSupport((b) => 
		{
			bARFoundation = b;
		});
	}


	private void Update()
	{
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Alpha1))
#else
		if (Input.touchCount == 2)
#endif
		{
			if(bARFoundation)
			{
				SceneManager.LoadSceneAsync(1);
			}
			else
			{
				SceneManager.LoadSceneAsync(2);
			}
		}
	}

	public void CheckARSupport(Action<bool> finishAction)
	{
		StartCoroutine(CheckARSupport_Internal(finishAction));
	}

	private IEnumerator CheckARSupport_Internal(Action<bool> finishAction)
	{
		Debug.Log("Check for AR Support");

#if UNITY_EDITOR
		yield return new WaitForEndOfFrame();
		Debug.LogWarning("Windows support AR");
		finishAction?.Invoke(true);
#else
		yield return ARSession.CheckAvailability();

		Debug.LogWarning($"ARSession State is {ARSession.state}");

		switch (ARSession.state)
		{
			case ARSessionState.Unsupported:
				Debug.LogWarning("Your device does Not support AR");
				finishAction?.Invoke(false);
				break;
			case ARSessionState.NeedsInstall:
				Debug.Log("Your device Need to install");
				finishAction?.Invoke(false);
				break;
			case ARSessionState.Ready:
				Debug.Log("Your device support AR");
				finishAction?.Invoke(true);
				break;
		}		
#endif
	}
}
