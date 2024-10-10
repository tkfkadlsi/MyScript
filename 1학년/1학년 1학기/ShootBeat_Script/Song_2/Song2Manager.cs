using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Song2Manager : MonoBehaviour
{
    public static Song2Manager instance;

    public SongPause pause;

    [SerializeField] private TextMeshProUGUI timeLine;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI ContinueText;

    [SerializeField] private AudioSource franchise;

    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject efcPrefab;
    [SerializeField] private GameObject stopPanel;
    [SerializeField] private GameObject information;

    [SerializeField] private Transform poolStorage;

    public GameObject player;

    Queue<GameObject> notePool = new Queue<GameObject>();
    Queue<GameObject> laserPool = new Queue<GameObject>();
    Queue<GameObject> efcPool = new Queue<GameObject>();

    public bool isPause;

    int song2Time = 84;
    int minute;
    int second;
    int score = 0;
    int combo = 0;
    int highCombo = 0;

    private void Awake()
    {
        Time.timeScale = PlayerPrefs.GetFloat("SpeedRate");
        instance = this;

        isPause = false;

        for (int i = 0; i < 30; i++)
        {
            notePool.Enqueue(CreateNote());
        }
        for (int i = 0; i < 30; i++)
        {
            laserPool.Enqueue(CreateLaser());
        }
        for (int i = 0; i < 30; i++)
        {
            efcPool.Enqueue(CreateEfc());
        }

        stopPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause == false)
                Pause();
            else if (isPause == true)
                CallContinue();
        }
    }

    GameObject CreateNote()
    {
        GameObject obj = Instantiate(notePrefab);
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(poolStorage);
        return obj;
    }

    GameObject CreateLaser()
    {
        GameObject obj = Instantiate(laserPrefab);
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(poolStorage);
        return obj;
    }

    GameObject CreateEfc()
    {
        GameObject obj = Instantiate(efcPrefab);
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(poolStorage);
        return obj;
    }

    public GameObject NoteGet()
    {
        if (notePool.Count > 0)
        {
            GameObject returnObj = notePool.Dequeue();
            returnObj.SetActive(true);
            return returnObj;
        }
        else
        {
            GameObject returnObj = CreateNote();
            returnObj.SetActive(true);
            return returnObj;
        }
    }

    public GameObject LaserGet()
    {
        if (laserPool.Count > 0)
        {
            GameObject returnObj = laserPool.Dequeue();
            returnObj.SetActive(true);
            return returnObj;
        }
        else
        {
            GameObject returnObj = CreateLaser();
            returnObj.SetActive(true);
            return returnObj;
        }
    }

    public GameObject EfcGet()
    {
        if (efcPool.Count > 0)
        {
            GameObject returnObj = efcPool.Dequeue();
            returnObj.SetActive(true);
            return returnObj;
        }
        else
        {
            GameObject returnObj = CreateEfc();
            returnObj.SetActive(true);
            return returnObj;
        }
    }

    public void noteDel(GameObject inObj)
    {
        inObj.transform.SetParent(poolStorage);
        inObj.SetActive(false);
        notePool.Enqueue(inObj);
    }

    public void LaserDel(GameObject inObj)
    {
        inObj.transform.SetParent(poolStorage);
        inObj.SetActive(false);
        laserPool.Enqueue(inObj);
    }

    public void EfcDel(GameObject inObj)
    {
        inObj.transform.SetParent(poolStorage);
        inObj.SetActive(false);
        efcPool.Enqueue(inObj);
    }

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = $"Score : {score}";
        }
    }

    public int Combo
    {
        get
        {
            return combo;
        }
        set
        {
            if (value < 0) return;
            else
            {
                combo = value;
                comboText.text = $"{combo}";
                Score += combo;

                if (combo > highCombo) highCombo = combo;

                if (combo == 465) Score += 250;
            }
        }
    }

    public int perfect { get; set; }
    public int good { get; set; }
    public int bad { get; set; }
    public int miss { get; set; }


    int Song2Time
    {
        get
        {
            return song2Time;
        }
        set
        {
            if (value < 0) return;
            else
            {
                song2Time = value;
                Song2Text(Song2Time);
            }

            if (song2Time == 0)
            {
                SongEnd();
            }
        }
    }

    public void Start()
    {
        franchise.pitch = PlayerPrefs.GetFloat("SpeedRate");
        franchise.time = 0f;
        franchise.Play();
        StartCoroutine("TimeText");
    }

    IEnumerator TimeText()
    {
        for (int i = Song2Time; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
            Song2Time = i;
        }
    }

    void Song2Text(int time)
    {
        minute = time / 60;
        second = time % 60;

        timeLine.text = $"{minute} : {second}";
    }

    void SongEnd()
    {
        if (score > PlayerPrefs.GetInt("HighScore2") && Time.timeScale == 1)
        {
            PlayerPrefs.SetInt("HighScore2", score);
        }

        DontDestroyOnLoad(information);
        Song2Information.instance.score1 = score;
        Song2Information.instance.combo1 = highCombo;
        Song2Information.instance.perfect1 = perfect;
        Song2Information.instance.good1 = good;
        Song2Information.instance.bad1 = bad;
        Song2Information.instance.miss1 = miss;

        SceneManager.LoadScene(3);
    }

    public void Pause()
    {
        if (isPause == false)
        {
            isPause = true;
            pause.IsPause(stopPanel, franchise);
        }
    }

    public void CallContinue()
    {
        pause.CallContinue(stopPanel, franchise);
        isPause = false;
    }
}