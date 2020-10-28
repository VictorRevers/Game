using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenAudioController : MonoBehaviour
{
    AudioSource ChickenAudioSource;
  public string leftKey = "";
    public string rightKey = "";
    public string upKey = "";
    public string downKey = "";
    
    // Start is called before the first frame update
    void Start()
    {
        ChickenAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(rightKey)) 
         {
           ChickenAudioSource.Play();
         }
          if (Input.GetKeyDown(leftKey)) 
          {
            ChickenAudioSource.Play();
          }
           if (Input.GetKeyDown(downKey)) 
           {
            ChickenAudioSource.Play();
           }
            if (Input.GetKeyDown(upKey)) 
            {
            ChickenAudioSource.Play();
            }
    }
}