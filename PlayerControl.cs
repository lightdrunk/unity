using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public CreatePlayer recreate;
    public int bulleted=0;
    private NavMeshAgent agent;
    private Animator move;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        Vector3 a=new Vector3(-130, 0, 0);  
        agent.SetDestination(a);
        transform.rotation = Quaternion.LookRotation(a);
        transform.Translate(Vector3.forward*1*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 1.6f)
        {
            Vector3 b=new Vector3(-130, 0, -10); 
            agent.SetDestination(b);
            transform.rotation = Quaternion.LookRotation(b);
            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
            if (agent.remainingDistance < 0.8f)
            {
                gameObject.SetActive(false);
                Time.timeScale = 0;
                SceneManager.LoadScene("SampleScene");
                Time.timeScale = 1;
                recreate.getj();
            }
        }
        if(bulleted > 5)
        {
           gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bulleted++;
    }
}
