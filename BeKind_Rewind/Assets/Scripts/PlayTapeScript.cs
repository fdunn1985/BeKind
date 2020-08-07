using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTapeScript : MonoBehaviour
{

    public AudioClip pickUp;
    public AudioSource audioSource;

    private void Start() {
        if (PlayerPrefs.HasKey("SFX_Volume")) {
            audioSource.volume = PlayerPrefs.GetFloat("SFX_Volume");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "player") {
            audioSource.PlayOneShot(pickUp);
            GameManager.Instance.SetPlayTapeCount(GameManager.Instance.GetPlayTapeCount() + 1);
            Destroy(gameObject, pickUp.length/2);
        }
    }
}
