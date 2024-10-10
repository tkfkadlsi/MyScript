using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyOption : MonoBehaviour
{
    public static KeyOption instance;

    public TMP_InputField inputRight;
    public TMP_InputField inputLeft;
    public TMP_InputField inputUp;
    public TMP_InputField inputDown;

    public KeyCode _right;
    public KeyCode _left;
    public KeyCode _up;
    public KeyCode _down;

    public GameObject savePanel;
    public TextMeshProUGUI saveText;

    public AudioClip saveSFX;

    bool rightOX, leftOX, upOX, downOX;

    AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _left = KeyInfo.instance._left;
        _right = KeyInfo.instance._right;
        _up = KeyInfo.instance._up;
        _down = KeyInfo.instance._down;

        inputLeft.text = PlayerPrefs.GetString("InputLeft");
        inputRight.text = PlayerPrefs.GetString("InputRight");
        inputUp.text = PlayerPrefs.GetString("InputUp");
        inputDown.text = PlayerPrefs.GetString("InputDown");

        KeySave();
    }

    public void ChangeLeftKey()
    {
        string input = inputLeft.text;

        input = input.ToUpper();

        leftOX = true;
        switch (input)
        {
            case "A":
                _left = KeyCode.A;
                break;

            case "B":

                _left = KeyCode.B;
                break;

            case "C":
                _left = KeyCode.C;
                break;

            case "D":
                _left = KeyCode.D;
                break;

            case "E":
                _left = KeyCode.E;
                break;

            case "F":
                _left = KeyCode.F;
                break;

            case "G":
                _left = KeyCode.G;
                break;

            case "H":
                _left = KeyCode.H;
                break;

            case "I":
                _left = KeyCode.I;
                break;

            case "J":
                _left = KeyCode.J;
                break;

            case "K":
                _left = KeyCode.K;
                break;

            case "L":
                _left = KeyCode.L;
                break;

            case "M":
                _left = KeyCode.M;
                break;

            case "N":
                _left = KeyCode.N;
                break;

            case "O":
                _left = KeyCode.O;
                break;

            case "P":
                _left = KeyCode.P;
                break;

            case "Q":
                _left = KeyCode.Q;
                break;

            case "R":
                _left = KeyCode.R;
                break;

            case "S":
                _left = KeyCode.S;
                break;

            case "T":
                _left = KeyCode.T;
                break;

            case "U":
                _left = KeyCode.U;
                break;

            case "V":
                _left = KeyCode.V;
                break;

            case "W":
                _left = KeyCode.W;
                break;

            case "X":
                _left = KeyCode.X;
                break;

            case "Y":
                _left = KeyCode.Y;
                break;

            case "Z":
                _left = KeyCode.Z;
                break;

            case ",":
                _left = KeyCode.Comma;
                break;

            case ".":
                _left = KeyCode.Period;
                break;

            case "/":
                _left = KeyCode.Slash;
                break;

            case ";":
                _left = KeyCode.Semicolon;
                break;

            case "'":
                _left = KeyCode.Quote;
                break;

            case "[":
                _left = KeyCode.LeftBracket;
                break;

            case "]":
                _left = KeyCode.RightBracket;
                break;

            case "|":
                _left = KeyCode.Dollar;
                break;

            default:
                _left = KeyCode.D;
                inputLeft.text = "D";
                leftOX = false;
                break;
        }

        KeyInfo.instance._left = _left;
    }


    public void ChangeRightKey()
    {
        string input = inputRight.text;

        input = input.ToUpper();

        rightOX = true;
        switch (input)
        {
            case "A":
                _right = KeyCode.A;
                break;

            case "B":
                _right = KeyCode.B;
                break;

            case "C":
                _right = KeyCode.C;
                break;

            case "D":
                _right = KeyCode.D;
                break;

            case "E":
                _right = KeyCode.E;
                break;

            case "F":
                _right = KeyCode.F;
                break;

            case "G":
                _right = KeyCode.G;
                break;

            case "H":
                _right = KeyCode.H;
                break;

            case "I":
                _right = KeyCode.I;
                break;

            case "J":
                _right = KeyCode.J;
                break;

            case "K":
                _right = KeyCode.K;
                break;

            case "L":
                _right = KeyCode.L;
                break;

            case "M":
                _right = KeyCode.M;
                break;

            case "N":
                _right = KeyCode.N;
                break;

            case "O":
                _right = KeyCode.O;
                break;

            case "P":
                _right = KeyCode.P;
                break;

            case "Q":
                _right = KeyCode.Q;
                break;

            case "R":
                _right = KeyCode.R;
                break;

            case "S":
                _right = KeyCode.S;
                break;

            case "T":
                _right = KeyCode.T;
                break;

            case "U":
                _right = KeyCode.U;
                break;

            case "V":
                _right = KeyCode.V;
                break;

            case "W":
                _right = KeyCode.W;
                break;

            case "X":
                _right = KeyCode.X;
                break;

            case "Y":
                _right = KeyCode.Y;
                break;

            case "Z":
                _right = KeyCode.Z;
                break;

            case ",":
                _right = KeyCode.Comma;
                break;

            case ".":
                _right = KeyCode.Period;
                break;

            case "/":
                _right = KeyCode.Slash;
                break;

            case ";":
                _right = KeyCode.Semicolon;
                break;

            case "'":
                _right = KeyCode.Quote;
                break;

            case "[":
                _right = KeyCode.LeftBracket;
                break;

            case "]":
                _right = KeyCode.RightBracket;
                break;

            case "|":
                _right = KeyCode.Dollar;
                break;

            default:
                _right = KeyCode.K;
                inputRight.text = "K";
                rightOX = false;
                break;
        }

        KeyInfo.instance._right = _right;
    }

    public void ChangeUpKey()
    {
        string input = inputUp.text;

        input = input.ToUpper();

        upOX = true;
        switch (input)
        {
            case "A":
                _up = KeyCode.A;
                break;

            case "B":
                _up = KeyCode.B;
                break;

            case "C":
                _up = KeyCode.C;
                break;

            case "D":
                _up = KeyCode.D;
                break;

            case "E":
                _up = KeyCode.E;
                break;

            case "F":
                _up = KeyCode.F;
                break;

            case "G":
                _up = KeyCode.G;
                break;

            case "H":
                _up = KeyCode.H;
                break;

            case "I":
                _up = KeyCode.I;
                break;

            case "J":
                _up = KeyCode.J;
                break;

            case "K":
                _up = KeyCode.K;
                break;

            case "L":
                _up = KeyCode.L;
                break;

            case "M":
                _up = KeyCode.M;
                break;

            case "N":
                _up = KeyCode.N;
                break;

            case "O":
                _up = KeyCode.O;
                break;

            case "P":
                _up = KeyCode.P;
                break;

            case "Q":
                _up = KeyCode.Q;
                break;

            case "R":
                _up = KeyCode.R;
                break;

            case "S":
                _up = KeyCode.S;
                break;

            case "T":
                _up = KeyCode.T;
                break;

            case "U":
                _up = KeyCode.U;
                break;

            case "V":
                _up = KeyCode.V;
                break;

            case "W":
                _up = KeyCode.W;
                break;

            case "X":
                _up = KeyCode.X;
                break;

            case "Y":
                _up = KeyCode.Y;
                break;

            case "Z":
                _up = KeyCode.Z;
                break;

            case ",":
                _up = KeyCode.Comma;
                break;

            case ".":
                _up = KeyCode.Period;
                break;

            case "/":
                _up = KeyCode.Slash;
                break;

            case ";":
                _up = KeyCode.Semicolon;
                break;

            case "'":
                _up = KeyCode.Quote;
                break;

            case "[":
                _up = KeyCode.LeftBracket;
                break;

            case "]":
                _up = KeyCode.RightBracket;
                break;

            case "|":
                _up = KeyCode.Dollar;
                break;

            default:
                _up = KeyCode.J;
                inputUp.text = "J";
                upOX = false;
                break;
        }

        KeyInfo.instance._up = _up;
    }


    public void ChangeDownKey()
    {
        string input = inputDown.text;

        input = input.ToUpper();

        downOX = true;
        switch (input)
        {
            case "A":
                _down = KeyCode.A;
                break;

            case "B":
                _down = KeyCode.B;
                break;

            case "C":
                _down = KeyCode.C;
                break;

            case "D":
                _down = KeyCode.D;
                break;

            case "E":
                _down = KeyCode.E;
                break;

            case "F":
                _down = KeyCode.F;
                break;

            case "G":
                _down = KeyCode.G;
                break;

            case "H":
                _down = KeyCode.H;
                break;

            case "I":
                _down = KeyCode.I;
                break;

            case "J":
                _down = KeyCode.J;
                break;

            case "K":
                _down = KeyCode.K;
                break;

            case "L":
                _down = KeyCode.L;
                break;

            case "M":
                _down = KeyCode.M;
                break;

            case "N":
                _down = KeyCode.N;
                break;

            case "O":
                _down = KeyCode.O;
                break;

            case "P":
                _down = KeyCode.P;
                break;

            case "Q":
                _down = KeyCode.Q;
                break;

            case "R":
                _down = KeyCode.R;
                break;

            case "S":
                _down = KeyCode.S;
                break;

            case "T":
                _down = KeyCode.T;
                break;

            case "U":
                _down = KeyCode.U;
                break;

            case "V":
                _down = KeyCode.V;
                break;

            case "W":
                _down = KeyCode.W;
                break;

            case "X":
                _down = KeyCode.X;
                break;

            case "Y":
                _down = KeyCode.Y;
                break;

            case "Z":
                _down = KeyCode.Z;
                break;

            case ",":
                _down = KeyCode.Comma;
                break;

            case ".":
                _down = KeyCode.Period;
                break;

            case "/":
                _down = KeyCode.Slash;
                break;

            case ";":
                _down = KeyCode.Semicolon;
                break;

            case "'":
                _down = KeyCode.Quote;
                break;

            case "[":
                _down = KeyCode.LeftBracket;
                break;

            case "]":
                _down = KeyCode.RightBracket;
                break;

            case "|":
                _down = KeyCode.Dollar;
                break;

            default:
                _down = KeyCode.F;
                inputDown.text = "F";
                downOX = false;
                break;
        }

        KeyInfo.instance._down = _down;
    }

    public void KeySave()
    {
        ChangeDownKey();
        ChangeLeftKey();
        ChangeRightKey();
        ChangeUpKey();

        if (_right == _left || _right == _up || _right == _down || _left == _up || _left == _down || _up == _down)
        {
            saveText.text = "Don't Overlap Key Setting";
            audioSource.PlayOneShot(saveSFX);
            savePanel.SetActive(true);
            StartCoroutine(SaveActiveFalse());
            BasicKeySetting();
        }
        else if(leftOX && rightOX && upOX && downOX)
        {
            saveText.text = "Success Your Key Setting";
            audioSource.PlayOneShot(saveSFX);
            savePanel.SetActive(true);
            
            StartCoroutine(SaveActiveFalse());
            PlayerPrefs.SetString("InputLeft", inputLeft.text);
            PlayerPrefs.SetString("InputRight", inputRight.text);
            PlayerPrefs.SetString("InputUp", inputUp.text);
            PlayerPrefs.SetString("InputDown", inputDown.text);
        }
        else
        {
            saveText.text = "Please Different Key Setting";
            audioSource.PlayOneShot(saveSFX);
            savePanel.SetActive(true);
            StartCoroutine(SaveActiveFalse());
        }
    }

    IEnumerator SaveActiveFalse()
    {
        yield return new WaitForSeconds(0.5f);
        savePanel.SetActive(false);
    }

    void BasicKeySetting()
    {
        _right = KeyCode.K;
        _left = KeyCode.D;
        _up = KeyCode.J;
        _down = KeyCode.F;

        inputRight.text = "K";
        inputLeft.text = "D";
        inputUp.text = "J";
        inputDown.text = "F";

        KeyInfo.instance._right = _right;
        KeyInfo.instance._left = _left;
        KeyInfo.instance._up = _up;
        KeyInfo.instance._down = _down;
    }
}
