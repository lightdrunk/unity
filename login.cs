using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{
    AsyncOperation openation;
    public anumin anums;
    public cipherin cnums;
    public logon GetLogons;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator loadScene()
    {
        openation = SceneManager.LoadSceneAsync(1);
        openation.allowSceneActivation=false;
        yield return openation;
    }

    public void ButtonCilck()
    {
        string usings=anums.inputField.text+cnums.inputField.text;
        for(int j=0; j<GetLogons.storage.Count; j++)
        {
            if (GetLogons.storage[j] == usings)
            {
                openation.allowSceneActivation = true;
            }
        }
    }

    
}
