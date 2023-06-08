using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
    AsyncOperation operation;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene()
    {
        operation=SceneManager.LoadSceneAsync("MyScene");
        operation.allowSceneActivation = false;
        yield return operation;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(operation.progress);
        if(Input.GetKeyDown(KeyCode.Return))
        {
            operation.allowSceneActivation = true;
        }
    }
}
