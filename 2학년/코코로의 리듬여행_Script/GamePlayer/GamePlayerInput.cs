using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInputs;
public class GamePlayerInput : MonoBehaviour, IGameInputActions
{
    [SerializeField] private MeshRenderer keyBeamLL;
    [SerializeField] private MeshRenderer keyBeamLM;
    [SerializeField] private MeshRenderer keyBeamRM;
    [SerializeField] private MeshRenderer keyBeamRR;

    public bool isInputOK;

    private KeyCode LS;
    private KeyCode LL;
    private KeyCode LM;
    private KeyCode RM;
    private KeyCode RR;
    private KeyCode RS;

    private bool LLDown;
    private bool LMDown;
    private bool RMDown;
    private bool RRDown;

    private GamePlayerMove gamePlayerMove;
    private PlayerInputs playerInputs;

    private float speed = 10f;

    private void Awake()
    {
        gamePlayerMove = GetComponent<GamePlayerMove>();
    }

    private void Start()
    {
        Information.Instance.PlayerInputs.GameInput.SetCallbacks(this);

        LS = Information.Instance.OptionData.LS;
        LL = Information.Instance.OptionData.LL;
        LM = Information.Instance.OptionData.LM;
        RM = Information.Instance.OptionData.RM;
        RR = Information.Instance.OptionData.RR;
        RS = Information.Instance.OptionData.RS;

        LLDown = false;
        LMDown = false;
        RMDown = false;
        RRDown = false;

        keyBeamLL.enabled = false;
        keyBeamLM.enabled = false;
        keyBeamRM.enabled = false;
        keyBeamRR.enabled = false;

        isInputOK = true;
    }

    private void Update()
    {
        if (!isInputOK) return;

        bool isleft = Input.GetKeyDown(LS);
        bool isright = Input.GetKeyDown(RS);
        int dir = 0;

        if (isleft)
        {
            gamePlayerMove.CallMove(-1);
        }
        if (isright)
        {
            gamePlayerMove.CallMove(1);
        }
    }

    private void FixedUpdate()
    {
        if (!isInputOK) return;

        if (Input.GetKeyDown(LL) && !LLDown)
        {
            LLDown = true;
            CallDownJudgement(LL);
        }
        if (Input.GetKeyDown(LM) && !LMDown)
        {
            LMDown = true;
            CallDownJudgement(LM);
        }
        if (Input.GetKeyDown(RM) && !RMDown)
        {
            RMDown = true;
            CallDownJudgement(RM);
        }
        if (Input.GetKeyDown(RR) && !RRDown)
        {
            RRDown = true;
            CallDownJudgement(RR);
        }



        if (Input.GetKeyUp(LL) && LLDown)
        {
            LLDown = false;
            CallUpJudgement(LL);
        }
        if (Input.GetKeyUp(LM) && LMDown)
        {
            LMDown = false;
            CallUpJudgement(LM);
        }
        if (Input.GetKeyUp(RM) && RMDown)
        {
            RMDown = false;
            CallUpJudgement(RM);
        }
        if (Input.GetKeyUp(RR) && RRDown)
        {
            RRDown = false;
            CallUpJudgement(RR);
        }
    }

    private void CallDownJudgement(KeyCode input)
    {
        Note note = null;
        if (input == LL)
        {
            keyBeamLL.enabled = true;
            note = GameManager.Instance.GetNote(0);
            if (note != null)
                note.Judgement();
        }
        if (input == LM)
        {
            keyBeamLM.enabled = true;
            note = GameManager.Instance.GetNote(1);
            if (note != null)
                note.Judgement();
        }
        if (input == RM)
        {
            keyBeamRM.enabled = true;
            note = GameManager.Instance.GetNote(2);
            if (note != null)
                note.Judgement();
        }
        if (input == RR)
        {
            keyBeamRR.enabled = true;
            note = GameManager.Instance.GetNote(3);
            if (note != null)
                note.Judgement();
        }
    }

    private void CallUpJudgement(KeyCode input)
    {
        Note note = null;
        if (input == LL)
        {
            keyBeamLL.enabled = false;
            note = GameManager.Instance.GetNote(0);
            if (note != null)
                note.LongJudgement();
        }
        if (input == LM)
        {
            keyBeamLM.enabled = false;
            note = GameManager.Instance.GetNote(1);
            if (note != null)
                note.LongJudgement();
        }
        if (input == RM)
        {
            keyBeamRM.enabled = false;
            note = GameManager.Instance.GetNote(2);
            if (note != null)
                note.LongJudgement();
        }
        if (input == RR)
        {
            keyBeamRR.enabled = false;
            note = GameManager.Instance.GetNote(3);
            if (note != null)
                note.LongJudgement();
        }
    }

    public void OnCamLock(InputAction.CallbackContext context)
    {

    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressUp();
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressDown();
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressLeft();
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressRight();
    }

    public void OnEnter(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressEnter();
    }

    public void OnESC(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressExit();
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressSpace();
    }
}