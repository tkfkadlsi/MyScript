using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSetter : MonoBehaviour
{
    [SerializeField] private GameObject choice1;
    [SerializeField] private TextMeshProUGUI choice1Name;
    [SerializeField] private TextMeshProUGUI choice1Detail;
    [SerializeField] private GameObject choice2;
    [SerializeField] private TextMeshProUGUI choice2Name;
    [SerializeField] private TextMeshProUGUI choice2Detail;
    public PlayerSkill playerSkill;

    [SerializeField] private List<Attribute> attributes;

    private PlayerController playerController;
    private int[] choiced = new int[2];

    public ResultCount resultCount = new ResultCount();

    private float _playTime = 0f;

    private void Awake()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerSkill = playerController.playerSkill;

        playerController.transform.position = new Vector3(0, 0);
        Information.Instance.PlayTime = 0f;
    }

    private void Update()
    {
        _playTime += Time.deltaTime;
        Information.Instance.PlayTime = _playTime;
    }

    public void ChoiceAttribute()
    {
        Time.timeScale = 0;
        int cnt = 0;

        for(int i = 0; i < attributes.Count; i++)
        {
            int rand = Random.Range(0, 2);

            if(i - cnt == attributes.Count - i)
            {
                rand = 1;
            }

            if (rand == 1)
            {
                choiced[cnt] = i;
                cnt++;
            }

            if(cnt == 2)
            {
                break;
            }
        }

        if(Information.Instance.Language == "ÇÑ±¹¾î")
        {
            choice1Name.text = attributes[choiced[0]].Name_Kor;
            choice1Detail.text = attributes[choiced[0]].Detail_Kor;
            choice2Name.text = attributes[choiced[1]].Name_Kor;
            choice2Detail.text = attributes[choiced[1]].Detail_Kor;
        }
        else if(Information.Instance.Language == "English")
        {
            choice1Name.text = attributes[choiced[0]].Name_Eng;
            choice1Detail.text = attributes[choiced[0]].Detail_Eng;
            choice2Name.text = attributes[choiced[1]].Name_Eng;
            choice2Detail.text = attributes[choiced[1]].Detail_Eng;
        }

        choice1.SetActive(true);
        choice2.SetActive(true);
    }


    public void Choice1()
    {
        Time.timeScale = 1;
        Apply(choiced[0]);
        choice1.SetActive(false);
        choice2.SetActive(false);
    }

    public void Choice2()
    {
        Time.timeScale = 1;
        Apply(choiced[1]);
        choice1.SetActive(false);
        choice2.SetActive(false);
    }

    private void Apply(int qwerasdf)
    {
        switch (qwerasdf)
        {
            case 0:
                GameManager.Instance.isAtkUp = true;
                break;

            case 1:
                Information.Instance.CurrentChaebo.bpm += 40;
                break;

            case 2:
                playerSkill.enabled = true;
                break;
        }
    }

    public void GameFin()
    {
        StartCoroutine(GameFinish());
    }

    private IEnumerator GameFinish()
    {
        Information.Instance.ResultCount = resultCount;
        Information.Instance.isClear = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }
}
