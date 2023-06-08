using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    float timer = 0;
    Vector3 pos1,pos=new Vector3 ();
    int i,z= 0;
    private LineRenderer line;
    List<GameObject> bullet=new List<GameObject>();
    List<GameObject> players = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        Lineini(line);
        pos1 = transform.position;
        float pos2 = transform.position.y + 4.1f;
        Vector3 v = new Vector3(pos1.x, pos2, pos1.z);
        pos = v;
    }

    void Lineini(LineRenderer lineRenderer)
    {
        lineRenderer .positionCount = 2;
        lineRenderer .material.color = Color.red;
        lineRenderer .useWorldSpace=true;
    }
    Vector3 truetime = new Vector3();
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            timer = 0;
            GameObject lss = Instantiate(Resources.Load("Bullet")) as GameObject;
            lss.transform.position = pos;
            lss.SetActive(false);
            bullet.Add(lss);
        }
        if (!players[i].activeSelf)
        {
            line.enabled = false;
            i++;
            bullet[z].SetActive(false);
            z++;
            bullet[z].SetActive(true);
        }
    }
    Vector3 b = new Vector3();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            line.enabled = true;
            players.Add(other.gameObject);
            line.SetPosition(0, pos);
            if (i < players.Count)
            {
                Vector3 pos3 = new Vector3(players[i].transform.position.x,
                    players[i].transform.position.y + 3.2f, players[i].transform.position.z);
                line.SetPosition(1, pos3);
                b = pos3;
                if(players.Count==1)
                {
                    GameObject ls= Instantiate(Resources.Load("Bullet")) as GameObject;
                    ls.transform.position = pos;
                    bullet.Add(ls);
                } 
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(i<players.Count)
        {
            Vector3 t=new Vector3(players[i].transform.position.x,
                players[i].transform.position.y + 3.2f, players[i].transform.position.z);
            truetime = t;
            line.enabled = false;
            line.SetPosition(0, pos);
            line.SetPosition(1,truetime);
            line.enabled = true;
            /*bullet.transform.LookAt(truetime);
            bullet.transform.position = Vector3.Lerp(bullet.transform.position, truetime, Time.deltaTime * 0.5f);*/
            if (z < bullet.Count) 
            {
                bool bulletactive = bullet[z].activeSelf;
                if (bulletactive)
                {
                    Debug.Log(bulletactive);             
                }
                else
                {
                    z++;
                    bullet[z].transform.position = pos;
                }
                if (z < bullet.Count)
                {
                    bullet[z].SetActive(true);
                    bullet[z].transform.LookAt(truetime);
                    bullet[z].transform.position = Vector3.Lerp(bullet[z].transform.position, truetime, Time.deltaTime * 0.2f); 
                }
                
            }   
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if(z<bullet.Count)
            { 
                bullet[z].SetActive(false);
            }
            z++;
            if (z < bullet.Count)
            {
                bullet[z].SetActive(true);
            }
            
            //bullet[z].gameObject.SetActive(false );
            //bullet.SetActive(false);
            i++;

            if (i < players.Count)
            {
                line.SetPosition(0, pos);
                Vector3 pos4 = new Vector3(players[i].transform.position.x,
                    players[i].transform.position.y + 3.2f, players[i].transform.position.z);
                line.SetPosition(1, pos4);
            }
            else
            {
                line.enabled = false;
            }
        }
    }
}
