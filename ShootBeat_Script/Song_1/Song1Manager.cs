using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Song1Manager : MonoBehaviour
{
    public static Song1Manager instance;

    public SongPause pause;

    [SerializeField] private TextMeshProUGUI timeLine;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI ContinueText;

    [SerializeField] private AudioSource jingleBells;

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

    int song1Time = 220;
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
        for(int i = 0; i < 30; i++)
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
        if(efcPool.Count > 0)
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

                if (combo == 388) Score += 318;
            }
        }
    }

    public int perfect { get; set; }
    public int good { get; set; }
    public int bad { get; set; }
    public int miss { get; set; }


    int Song1Time
    {
        get
        {
            return song1Time;
        }
        set
        {
            if (value < 0) return;
            else
            {
                song1Time = value;
                Song1Text(Song1Time);
            }

            if (song1Time == 0)
            {
                SongEnd();
            }
        }
    }

    void Start()
    {
        jingleBells.pitch = PlayerPrefs.GetFloat("SpeedRate");
        jingleBells.time = 0;
        jingleBells.Play();
        StartCoroutine("TimeText");
    }

    IEnumerator TimeText()
    {
        for (int i = Song1Time; i >= 0; i--)
        {
            Song1Time = i;
            yield return new WaitForSeconds(1);
        }
    }

    void Song1Text(int time)
    {
        minute = time / 60;
        second = time % 60;

        timeLine.text = $"{minute} : {second}";
    }

    void SongEnd()
    {
        if(score > PlayerPrefs.GetInt("HighScore1") && Time.timeScale == 1)
        {
            PlayerPrefs.SetInt("HighScore1", score);
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
            pause.IsPause(stopPanel, jingleBells);
        }
    }

    public void CallContinue()
    {
        pause.CallContinue(stopPanel, jingleBells);
        isPause = false;
    }
}
