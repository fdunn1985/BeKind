using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManagerScript : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("BG_Volume")) {
            audioSource.volume = PlayerPrefs.GetFloat("BG_Volume");
        } else {
            audioSource.volume = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
