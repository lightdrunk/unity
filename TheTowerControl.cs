using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TheTowerControl : MonoBehaviour
{
    //private MeshRenderer mesh;
    public GameObject[] thetower;
    // Start is called before the first frame update
    void Start()
    {
        //mesh = this.GetComponent<MeshRenderer>();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool res = Physics.Raycast(ray, out hit);
            if (res == true)
            {
                thetower = GameObject.FindGameObjectsWithTag("TheTower");
                if (!hit.transform.CompareTag("stone"))
                {
                    Debug.Log("请点击左边石阶");
                    return;
                }
                bool repeat=true ;
                for(int i = 0;i < thetower.Length;i++)
                {
                    if (thetower[i].transform.position == hit.transform.position)
                    {
                       repeat = false;
                    }
                }
                if (thetower.Length <=4)
                {
                    if (repeat)
                    {
                        GameObject thetower1 = Instantiate(Resources.Load("TheTower")) as GameObject;
                        thetower1.transform.position = hit.transform.position;
                        int b = 4 - thetower.Length;
                        Debug.Log("防御塔剩余"+b+"座");
                    }   
                }
                else  {
                    Debug.Log("防御塔已无");
                 }  
            }
        }
    }

}
