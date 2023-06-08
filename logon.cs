using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logon : MonoBehaviour
{
    public anumin anum;
    public cipherin cnum;
    public List<string> storage;
    // Start is called before the first frame update
    void Start()
    {
        string[] storage = new string[10];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonCilck()
    {
        string use=anum.inputField.text+cnum.inputField.text; 
        storage.Add(use);
        Debug.Log("ÒÑ×¢²áÕËºÅ£¬ÇëµÇÂ½");
    }
}
