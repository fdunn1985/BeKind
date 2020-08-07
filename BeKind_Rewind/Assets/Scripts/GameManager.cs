using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject[] LevelArr;
    public GameObject Player;

    public GameObject playCountText;
    public GameObject revCountText;
    public GameObject levelText;

    public GameObject GameTimerGUI;
    public GameObject GameOverTimeTextGUI;
    public GameObject GameOverPanel;

    public AudioSource audioSource;

    private int playTapeCount = 0;
    private int revTapeCount = 0;

    private int levelTvCount = 0;

    private int currentLevel = 1;
    private int maxLevel;

    private float gameTimer;
    private float startTime;
    private bool isGameOver = false;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(this);
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        //TODO: Figure out how to make this dynamic
        levelTvCount = 1;
        currentLevel = 1;

        maxLevel = LevelArr.Length;

        if (PlayerPrefs.HasKey("BG_Volume")) {
            audioSource.volume = PlayerPrefs.GetFloat("BG_Volume");
        }

        LoadLevel(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) {
            gameTimer = Time.time - startTime;
            int min = (int)gameTimer / 60;
            int sec = (int)gameTimer % 60;

            TextMeshProUGUI tm = GameTimerGUI.GetComponent<TextMeshProUGUI>();
            string textMin = (min < 10) ? "0" + min : "" + min;
            string textSec = (sec < 10) ? "0" + sec : "" + sec; ;
            
            tm.text = textMin + ":" + textSec;
        }
        
    }

    public int GetCurrentLevel() {
        return currentLevel;
    }

    public void SetCurrentLevel(int level) {
        currentLevel = level;
    }

    public void GameOver() {
        TextMeshProUGUI gameOverTM = GameOverTimeTextGUI.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI tm = GameTimerGUI.GetComponent<TextMeshProUGUI>();
        gameOverTM.text = "Your time was: " + tm.text;
        
        GameOverPanel.SetActive(true);
    }

    public void ReturnToMainMenuBtn() {
        SceneManager.LoadScene("StartScene");
    }

    public void GoToNextLevel() {
        if (currentLevel == maxLevel) {
            Debug.Log("Game Over!");
            isGameOver = true;
            GameOver();
        }
        else if (currentLevel != 0) { 
            GameObject.Find("Level " + currentLevel).SetActive(false);
            currentLevel++;
            LoadLevel(currentLevel);
        }
        
    }

    public void RepeatLevel() {
        LoadLevel(currentLevel);
    }

    private void LoadLevel(int level) {

        TextMeshProUGUI tm = levelText.GetComponent<TextMeshProUGUI>();
        tm.text = "Level " + level;

        ResetTapeCount();

        switch (level) {
            case 1:
                LevelArr[level - 1].SetActive(true);
                SetPlayerPosition(-5.5f, -4f);
                levelTvCount = 1;
                break;
            case 2:
                LevelArr[level - 1].SetActive(true);
                SetPlayerPosition(-5.5f, -4f);
                levelTvCount = 2;
                break;
            case 3:
                LevelArr[level - 1].SetActive(true);
                SetPlayerPosition(-5.5f, -4f);
                levelTvCount = 1;
                break;
            case 4:
                LevelArr[level - 1].SetActive(true);
                SetPlayerPosition(-5.5f, -4f);
                levelTvCount = 1;
                break;
            case 5:
                LevelArr[level - 1].SetActive(true);
                SetPlayerPosition(-5.5f, -4f);
                levelTvCount = 1;
                break;
            case 6:
                LevelArr[level - 1].SetActive(true);
                SetPlayerPosition(-5.5f, -4f);
                levelTvCount = 1;
                break;
            case 7:
                LevelArr[level - 1].SetActive(true);
                SetPlayerPosition(-5.5f, -4f);
                levelTvCount = 2;
                break;
            case 8:
                LevelArr[level - 1].SetActive(true);
                SetPlayerPosition(-5f, -4f);
                levelTvCount = 1;
                break;
            case 9:
                LevelArr[level - 1].SetActive(true);
                SetPlayerPosition(-5.5f, -4f);
                levelTvCount = 2;
                break;
            case 10:
                LevelArr[level - 1].SetActive(true);
                SetPlayerPosition(-5.5f, -4f);
                levelTvCount = 8;
                break;
            default:
                LevelArr[0].SetActive(true);
                SetPlayerPosition(-5.5f, -4f);
                levelTvCount = 1;
                break;
        }
    }

    private void ResetTapeCount() {
        SetPlayTapeCount(0);
        SetRevTapeCount(0);
    }

    private void SetPlayerPosition(float x, float y) {
        Vector3 temp = Player.transform.position;
        temp.x = x;
        temp.y = y;
        Player.transform.position = temp;
    }


    public int GetLevelTvCount() {
        return levelTvCount;
    }

    public void SetLevelTvCount(int count) {
        levelTvCount = count;
    }

    public int GetPlayTapeCount() {
        return playTapeCount;
    }

    public void SetPlayTapeCount(int count) {
        playTapeCount = count;

        TextMeshProUGUI tm = playCountText.GetComponent<TextMeshProUGUI>();
        tm.text = "x" + playTapeCount;
    }

    public int GetRevTapeCount() {
        return revTapeCount;
    }

    public void SetRevTapeCount(int count) {
        revTapeCount = count;

        TextMeshProUGUI tm = revCountText.GetComponent<TextMeshProUGUI>();
        tm.text = "x" + revTapeCount;
    }
}
