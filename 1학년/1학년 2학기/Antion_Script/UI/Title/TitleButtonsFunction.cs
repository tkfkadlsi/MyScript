using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tkfkadlsi
{
    public class TitleButtonsFunction : MonoBehaviour
    {
        [SerializeField] private GameObject DictionaryPanel;
        [SerializeField] private GameObject QuestionPanel;
        [SerializeField] private GameObject SettingPanel;

        private void Awake()
        {
            int w = Screen.width;
            int h = (w * 9) / 16;

            Screen.SetResolution(w, h, true);
        }

        private void Start()
        {
            ResetPanels();
        }

        private void ResetPanels()
        {
            DictionaryPanel.SetActive(false);
            SettingPanel.SetActive(false);
            QuestionPanel.SetActive(false);
        }

        private void PlayClickSound()
        {
            AudioManager.Instance.PlaySound("UIClick", AudioType.SFX);
        }

        public void OnStart()
        {
            PlayClickSound();
            SceneManager.LoadScene(1);
        }

        public void OnDictionaryPanel()
        {
            PlayClickSound();
            ResetPanels();
            DictionaryPanel.SetActive(true);
        }

        public void OnQuestionPanel()
        {
            PlayClickSound();
            ResetPanels();
            QuestionPanel.SetActive(true);
        }

        public void OnSettingPanel()
        {
            PlayClickSound();
            ResetPanels();
            SettingPanel.SetActive(true);
        }

        public void ExitDictionaryPanel()
        {
            PlayClickSound();
            DictionaryPanel.SetActive(false);
        }

        public void ExitQuestionPanel()
        {
            PlayClickSound();
            QuestionPanel.SetActive(false);
        }

        public void ExitSettingPanel()
        {
            PlayClickSound();
            SettingPanel.SetActive(false);
        }

        public void ExitGame()
        {
            PlayClickSound();
            Application.Quit();
        }
    }
}
