using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorScript : MonoBehaviour
{
    public Animator anim;
    private bool isDoorOpen = false;

    //public int level = 0;

    private void FixedUpdate() {
        if (GameManager.Instance.GetLevelTvCount() == 0) {
            anim.SetTrigger("OpenDoor");
            isDoorOpen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "player" && isDoorOpen) {
            Debug.Log("You passed the level! - " + GameManager.Instance.GetCurrentLevel());

            //int level = GameManager.Instance.GetCurrentLevel();
            //GameObject.Find("Level " + level).SetActive(false);

            //if (level == GameManager.Instance.GetCurrentLevel()) {
                GameManager.Instance.GoToNextLevel();
            //}
            
        }
    }
}
