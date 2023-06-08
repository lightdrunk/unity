using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    List<GameObject> playersc= new List<GameObject>();
    List<GameObject> bloodbars = new List<GameObject>();
    
    public int j = 0;
    float timer = 0;
    int i = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    GameObject game;
    GameObject bloodbar;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > i)
        {
            i += 6;
            createplayer(j);
        }
        for(int a = 0; a < playersc.Count; a++)
        {
            Vector3 truegame = new Vector3(playersc[a].transform.position.x-3.5f,
                5f + playersc[a].transform.position.y, playersc[a].transform.position.z);
            bloodbars[a].transform.position = Vector3.Lerp(bloodbars[a].transform.position,truegame,Time.deltaTime * 1f);
        } 
    }
    void createplayer(int i)
    {
        if (j < 5)
        {
            j++;
            Vector3 gamep = new Vector3(5, 0, 0);
            Vector3 bloodbarp = new Vector3(5,5,0);
            game = Instantiate(Resources.Load("Player")) as GameObject;
            bloodbar = Instantiate(Resources.Load("Bloodbar")) as GameObject;
            game.transform.position = gamep;
            bloodbar.transform.position = bloodbarp;
            playersc.Add(game);
            bloodbars.Add(bloodbar);
        }
    }
    public void getj()
    {
        timer = 0;
        j =0;
        i = 3;
    }
}
