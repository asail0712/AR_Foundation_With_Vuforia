using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //[SerializeField] private int unloadSceneIdx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha1))
#else
		if (Input.touchCount == 2)
#endif
        { 
            SceneManager.LoadSceneAsync(0);
        }
    }
}
