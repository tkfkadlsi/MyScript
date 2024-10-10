using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private GameObject[] DontDestroyList;

    private ParentObject parentObject;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneOpen;
    }
    private void SceneOpen(Scene scene, LoadSceneMode mode)
    {
        parentObject = FindObjectOfType<ParentObject>();

        if (parentObject == null) return;

        foreach(GameObject gameObject in DontDestroyList)
        {
            gameObject.transform.SetParent(parentObject.transform);
        }
        Destroy(gameObject);
    }

    public void SceneClose()
    {
        if(Information.Instance.stageDifficult == Difficult.Tutorial)
        {
            SceneManager.LoadScene(4);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(GameObject gameObject in DontDestroyList)
        {
            DontDestroyOnLoad(gameObject);
        }
        SceneManager.LoadScene(2);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneOpen;
    }
}
