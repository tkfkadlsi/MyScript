using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveTime;
    [SerializeField] private AnimationCurve move_animationCurve;

    [SerializeField] private GameObject ridial;

    private Judgement judgement;
    private KeytarInput keytarInput;
    private KeyboardInput keyboardInput;
    private SoundEnergy soundEnergy;
    private GameSetter gameSetter;
    public PlayerSkill playerSkill;

    private Rigidbody2D rigid;

    private Vector2 currentDir = Vector2.up;

    private void Awake()
    {
        soundEnergy = FindObjectOfType<SoundEnergy>();
        gameSetter = FindObjectOfType<GameSetter>();
        keytarInput = this.GetComponent<KeytarInput>();
        keyboardInput = this.GetComponent<KeyboardInput>();
        judgement = this.GetComponent<Judgement>();
        playerSkill = this.GetComponent<PlayerSkill>();
        rigid = this.GetComponent<Rigidbody2D>();
        if (Information.Instance.Keymode == "Keytar")
        {
            keytarInput.enabled = true;
            keyboardInput.enabled = false;

            keytarInput.setDirection += SetDirection;
            keytarInput.onKeytarMove += Move;
            keytarInput.onAttack += Attack;
        }
        else
        {
            keytarInput.enabled = false;
            keyboardInput.enabled = true;

            keyboardInput.setDirection += SetDirection;
            keyboardInput.onKKeyboardMove += Move;
            keyboardInput.onAttack += Attack;
        }
        playerSkill.enabled = false;
    }

    private void SetDirection(Vector2 dir)
    {
        currentDir = dir;
    }

    private void Move()
    {
        if (!CheckCommand())
        {
            if (!judgement.Judge()) return;
        }
        StartCoroutine("MoveLerp");
        if (gameSetter != null)
            gameSetter.resultCount.Moving++;
        else
            gameSetter = FindObjectOfType<GameSetter>();
        EnergyAccurary();
    }

    private IEnumerator MoveLerp()
    {
        float t = 0f;
        Vector2 startPos = (Vector2)transform.position;
        Vector2 endPos = (Vector2)transform.position + currentDir.normalized;

        float maxDistance = 1f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, currentDir, maxDistance, LayerMask.GetMask("Wall"));

        if (hit.collider != null) StopCoroutine("MoveLerp");

        while (t < moveTime)
        {
            rigid.position = Vector2.Lerp(startPos, endPos, move_animationCurve.Evaluate(t / moveTime));
            t += Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        rigid.position = new Vector2(Mathf.Round(rigid.position.x), Mathf.Round(rigid.position.y));
    }

    private bool CheckCommand()
    {
        if (!keytarInput) return false;
        if (!keytarInput.readyCommand) return false;
        return true;
    }

    private void Attack()
    {
        if (judgement.Judge())
        {
            if (keytarInput)
            {
                StartCoroutine(OnCommnad());
            }
            EnergyAccurary();
            GameObject r = Instantiate(ridial);
            r.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
    }

    private void EnergyAccurary()
    {
        if (gameSetter != null)
            gameSetter.resultCount.EnergySum += soundEnergy.energySlider.value;
    }

    public void Hit(float damage)
    {
        soundEnergy.SoundEnergyUp(-damage);
    }

    private IEnumerator OnCommnad()
    {
        keytarInput.readyCommand = true;
        yield return new WaitForSeconds(0.125f);
        keytarInput.readyCommand = false;
    }
}