using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManagerScript : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider bgSlider;
    public GameObject bgSliderText;

    public Slider sfxSlider;
    public GameObject sfxSliderText;

    private void Start() {
        if (PlayerPrefs.HasKey("BG_Volume")) { 
            bgSlider.value = PlayerPrefs.GetFloat("BG_Volume") * 100;
            TextMeshProUGUI tm = bgSliderText.GetComponent<TextMeshProUGUI>();
            tm.text = "" + bgSlider.value;
        }

        if (PlayerPrefs.HasKey("SFX_Volume")) {
            sfxSlider.value = PlayerPrefs.GetFloat("SFX_Volume") * 100;
            TextMeshProUGUI tmSfx = sfxSliderText.GetComponent<TextMeshProUGUI>();
            tmSfx.text = "" + sfxSlider.value;
        }
    }

    private void Update() {
        TextMeshProUGUI tm = bgSliderText.GetComponent<TextMeshProUGUI>();
        tm.text = "" + bgSlider.value;
        audioSource.volume = bgSlider.value/100;

        TextMeshProUGUI tmSfx = sfxSliderText.GetComponent<TextMeshProUGUI>();
        tmSfx.text = "" + sfxSlider.value;

        PlayerPrefs.SetFloat("BG_Volume", bgSlider.value / 100);
        PlayerPrefs.SetFloat("SFX_Volume", sfxSlider.value / 100);
    }

   public void backButtonClicked() {
        SceneManager.LoadScene("StartScene");
    }
}
