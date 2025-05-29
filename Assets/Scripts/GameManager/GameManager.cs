using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameObject youLoseCanvas;
        public GameObject youWinCanvas;
        public GameObject hudCanvas;
        public TMP_Text roundsInfo;
        public TMP_Text WinroundsText;
        public TMP_Text LoseroundsText;
        public TMP_Text WinkillsText;
        public TMP_Text LosekillsText;

        private int enemiesKilled = 0;
        private int currentRound = 1;

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            youLoseCanvas.SetActive(false);
            youWinCanvas.SetActive(false);
        }

        void Update()
        {
            if (TowerHealth.Instance.currentHealth <= 0)
            {
                YouLost();
            }
            roundsInfo.text = ("Round: " + currentRound.ToString());
        }

        public void AddKill()
        {
            enemiesKilled++;
        }

        public void SetCurrentRound(int round)
        {
            currentRound = round;
        }

        public void YouLost()
        {
            hudCanvas.SetActive(false);
            youLoseCanvas.SetActive(true);
            LoseroundsText.text = ("Round Reached:" + currentRound);
            LosekillsText.text = ("Enemies Defeated:" + enemiesKilled);
            Time.timeScale = 0;
        }

        public void YouWin()
        {
            hudCanvas.SetActive(false);
            youWinCanvas.SetActive(true);
            WinroundsText.text = ("Round Reached:" + currentRound);
            WinkillsText.text = ("Enemies Defeated:" + enemiesKilled);
            Time.timeScale = 0;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        
        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        }
    }
}