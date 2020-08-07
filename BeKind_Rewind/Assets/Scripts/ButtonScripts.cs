using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour
{
    public void PlayButtonClicked() {
        Debug.Log("play clicked");
        SceneManager.LoadScene("MainScene");
    }

    public void OptionsButtonClicked() {
        SceneManager.LoadScene("OptionsScene");
    }
}
