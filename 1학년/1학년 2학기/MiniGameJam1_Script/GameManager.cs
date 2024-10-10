using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public Car car;
    public EnemyCar enemyCar;

    public TextMeshProUGUI countDownText;
    public TextMeshProUGUI currentTimer;
    public TextMeshProUGUI bestScoreText;

    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;

    public GameObject panel;
    public GameObject Re;

    private AudioSource audioSource;
    public AudioClip startClip;

    private float bestScore = 0;
    private float timer = 0;
    private int lap = 0;

    private void Awake()
    {
        panel.SetActive(false);
        Re.SetActive(false);
        redLight.SetActive(false);
        yellowLight.SetActive(false);
        greenLight.SetActive(false);

        audioSource = this.GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("BestScore"))
        {
            
            bestScore = PlayerPrefs.GetFloat("BestScore");

            bestScoreText.text = "BestScore " + TimeSpan.FromSeconds(bestScore).ToString("mm\\:ss\\:ff");
        }
        else
        {
            bestScore = Mathf.Infinity;
        }
    }

    private void Start()
    {
        car.start = false;
        enemyCar.start = false;

        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(startClip);
        countDownText.text = "3";
        yield return new WaitForSeconds(1);
        countDownText.text = "2";
        redLight.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownText.text = "1";
        yellowLight.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownText.text = "GO";
        greenLight.SetActive(true);
        car.start = true;
        enemyCar.start = true;
        yield return new WaitForSeconds(1);
        countDownText.text = "";
    }

    private void Update()
    {
        if (lap == 2) Fin();
        if (!car.start) return;

        timer += Time.deltaTime;

        currentTimer.text = "Timer " + TimeSpan.FromSeconds(timer).ToString("mm\\:ss\\:ff");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnOff();
        }
    }

    private void OnOff()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lap++;
        }
    }

    private void Fin()
    {
        car.start = false;
        if(bestScore > timer)
        {
            PlayerPrefs.SetFloat("BestScore", timer);

            bestScoreText.text = "BestScore " + TimeSpan.FromSeconds(timer).ToString("mm\\:ss\\:ff");
        }

        Re.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
