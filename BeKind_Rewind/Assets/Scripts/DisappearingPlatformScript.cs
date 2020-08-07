using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformScript : MonoBehaviour
{
    public GameObject tile;
    public bool isVisible = true;
    public float awakeTime = 2f;
    public float sleepTime = 2f;

    float currentTime = 0f;

    private void Start() {
        currentTime = Time.time;
        
        if (!isVisible) {
            tile.SetActive(false);
        }
    }

    private void FixedUpdate() {
        if (isVisible) {
            if (Time.time - currentTime > awakeTime) {
                
                tile.SetActive(false);
                currentTime = Time.time;
                isVisible = false;
            }
        } else {
            if (Time.time - currentTime > sleepTime) {
                
                tile.SetActive(true);
                currentTime = Time.time;
                isVisible = true;
            }
        }
    }
}
