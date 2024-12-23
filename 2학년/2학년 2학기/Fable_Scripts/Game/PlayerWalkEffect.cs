using System.Collections;
using UnityEngine;

public class PlayerWalkEffect : MonoBehaviour
{
    [SerializeField] private GameObject walkEffectPrefab;
    [SerializeField] private Transform spawntrm;

    private PoolManager poolManager;
    private PlayerInput player;

    private float loopTime = 0f;
    private float loopCount = 0f;

    private string WalkEffect = "WalkEffect";
    private void Start()
    {
        float bpm = Information.Instance.currentSong.SongBPM;
        loopTime = Information.Instance.currentDiff == DifficultType.Nightmare ? (60f / bpm) * 0.125f : (60f / bpm) * 0.25f;
        player = GetComponent<PlayerInput>();
        poolManager = FindObjectOfType<PoolManager>();
    }

    private void Update()
    {
        if(player.isPlaying == false)
            return;

        if (loopCount > loopTime)
        {
            loopCount -= loopTime;
            InstantiateWalkEffect();
        }

        loopCount += Time.deltaTime;
    }

    private void InstantiateWalkEffect()
    {
        Vector3 position = spawntrm.position;
        position.z += 0.5f;
        GameObject newEffect = poolManager.GetObject(WalkEffect);
        newEffect.transform.position = position;
        StartCoroutine(ReturnEffect(newEffect));
    }

    private IEnumerator ReturnEffect(GameObject effectObject)
    {
        yield return new WaitForSeconds(0.15f);
        poolManager.SetObject(WalkEffect, effectObject);
    }
}
