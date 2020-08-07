using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTVScript : MonoBehaviour
{
    public Animator anim;
    public AudioClip staticClip;
    public AudioSource audioSource;

    private bool beenActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SFX_Volume")) {
            audioSource.volume = PlayerPrefs.GetFloat("SFX_Volume");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "player" && GameManager.Instance.GetPlayTapeCount() > 0 && !beenActivated) {
            audioSource.PlayOneShot(staticClip);
            anim.SetTrigger("Activated");
            beenActivated = true;

            //yield WaitForAnimation(anim);
            while(anim.GetCurrentAnimatorStateInfo(0).IsName("TV_Static") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 2.0f) {
                
            }

            GameManager.Instance.SetPlayTapeCount(GameManager.Instance.GetPlayTapeCount() - 1);
            GameManager.Instance.SetLevelTvCount(GameManager.Instance.GetLevelTvCount()- 1);
        }
    }
}
