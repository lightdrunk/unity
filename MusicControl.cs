using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private AudioSource audiocontrol;
    // Start is called before the first frame update
    void Start()
    {
        audiocontrol = GetComponent<AudioSource>();
        audiocontrol.loop = true;
        audiocontrol.volume = 0.5f;
        audiocontrol.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audiocontrol.volume += 0.2f;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)&&audiocontrol.volume<1.0f)
        {
            audiocontrol.volume -= 0.2f;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audiocontrol.isPlaying)
            {
                audiocontrol.Pause();
            }
            else
            {
                audiocontrol.Play();
            }
        }
    }
}
