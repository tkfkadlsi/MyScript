using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeySetting : MonoBehaviour
{
    public KeyCode attack1, attack2;
    public KeyCode defend1, defend2;
    public KeyCode evasion;

    [SerializeField] private TMP_InputField inputAttack1;
    [SerializeField] private TMP_InputField inputAttack2;
    [SerializeField] private TMP_InputField inputDefend1;
    [SerializeField] private TMP_InputField inputDefend2;


    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI resultText;

    bool isDup = false;

    private void Start()
    {
        resultPanel.SetActive(false);



        inputAttack1.text = PlayerPrefs.GetString("attackKey1");
        inputAttack2.text = PlayerPrefs.GetString("attackKey2");
        inputDefend1.text = PlayerPrefs.GetString("defendKey1");
        inputDefend2.text = PlayerPrefs.GetString("defendKey2");

        KeyChangeSign();

        evasion = KeyCode.Space;
    }

    void ChangeAttackKey1(string input)
    {
        input = input.ToUpper();

        switch (input)
        {
            case "1":
                attack1 = KeyCode.Alpha1;
                break;


            case "2":
                attack1 = KeyCode.Alpha2;
                break;


            case "3":
                attack1 = KeyCode.Alpha3;
                break;


            case "4":
                attack1 = KeyCode.Alpha4;
                break;


            case "5":
                attack1 = KeyCode.Alpha5;
                break;


            case "6":
                attack1 = KeyCode.Alpha6;
                break;


            case "7":
                attack1 = KeyCode.Alpha7;
                break;


            case "8":
                attack1 = KeyCode.Alpha8;
                break;


            case "9":
                attack1 = KeyCode.Alpha9;
                break;


            case "0":
                attack1 = KeyCode.Alpha0;
                break;


            case "Q":
                attack1 = KeyCode.Q;
                break;


            case "W":
                attack1 = KeyCode.W;
                break;


            case "E":
                attack1 = KeyCode.E;
                break;


            case "R":
                attack1 = KeyCode.R;
                break;


            case "T":
                attack1 = KeyCode.T;
                break;


            case "Y":
                attack1 = KeyCode.Y;
                break;


            case "U":
                attack1 = KeyCode.U;
                break;


            case "I":
                attack1 = KeyCode.I;
                break;


            case "O":
                attack1 = KeyCode.O;
                break;


            case "P":
                attack1 = KeyCode.P;
                break;


            case "A":
                attack1 = KeyCode.A;
                break;


            case "S":
                attack1 = KeyCode.S;
                break;


            case "D":
                attack1 = KeyCode.D;
                break;


            case "F":
                attack1 = KeyCode.F;
                break;


            case "G":
                attack1 = KeyCode.G;
                break;


            case "H":
                attack1 = KeyCode.H;
                break;


            case "J":
                attack1 = KeyCode.J;
                break;


            case "K":
                attack1 = KeyCode.K;
                break;


            case "L":
                attack1 = KeyCode.L;
                break;


            case "Z":
                attack1 = KeyCode.Z;
                break;


            case "X":
                attack1 = KeyCode.X;
                break;


            case "C":
                attack1 = KeyCode.C;
                break;


            case "V":
                attack1 = KeyCode.V;
                break;


            case "B":
                attack1 = KeyCode.B;
                break;


            case "N":
                attack1 = KeyCode.N;
                break;


            case "M":
                attack1 = KeyCode.M;
                break;


            case "-":
                attack1 = KeyCode.Minus;
                break;


            case "=":
                attack1 = KeyCode.Equals;
                break;


            case "[":
                attack1 = KeyCode.LeftBracket;
                break;


            case "]":
                attack1 = KeyCode.RightBracket;
                break;


            case ";":
                attack1 = KeyCode.Semicolon;
                break;


            case ":":
                attack1 = KeyCode.Colon;
                break;


            case "'":
                attack1 = KeyCode.Quote;
                break;


            case ",":
                attack1 = KeyCode.Comma;
                break;


            case ".":
                attack1 = KeyCode.Period;
                break;


            case "/":
                attack1 = KeyCode.Slash;
                break;


            default:
                isDup = true;

                inputAttack1.text = "D";
                inputAttack2.text = "F";
                inputDefend1.text = "J";
                inputDefend2.text = "K";

                attack1 = KeyCode.D;
                attack2 = KeyCode.F;
                defend1 = KeyCode.J;
                defend2 = KeyCode.K;

                StartCoroutine(ResultPanel("Please Different Key"));
                break;
        }
    }



    void ChangeAttackKey2(string input)
    {
        input = input.ToUpper();

        switch (input)
        {
            case "1":
                attack2 = KeyCode.Alpha1;
                break;


            case "2":
                attack2 = KeyCode.Alpha2;
                break;


            case "3":
                attack2 = KeyCode.Alpha3;
                break;


            case "4":
                attack2 = KeyCode.Alpha4;
                break;


            case "5":
                attack2 = KeyCode.Alpha5;
                break;


            case "6":
                attack2 = KeyCode.Alpha6;
                break;


            case "7":
                attack2 = KeyCode.Alpha7;
                break;


            case "8":
                attack2 = KeyCode.Alpha8;
                break;


            case "9":
                attack2 = KeyCode.Alpha9;
                break;


            case "0":
                attack2 = KeyCode.Alpha0;
                break;


            case "Q":
                attack2 = KeyCode.Q;
                break;


            case "W":
                attack2 = KeyCode.W;
                break;


            case "E":
                attack2 = KeyCode.E;
                break;


            case "R":
                attack2 = KeyCode.R;
                break;


            case "T":
                attack2 = KeyCode.T;
                break;


            case "Y":
                attack2 = KeyCode.Y;
                break;


            case "U":
                attack2 = KeyCode.U;
                break;


            case "I":
                attack2 = KeyCode.I;
                break;


            case "O":
                attack2 = KeyCode.O;
                break;


            case "P":
                attack2 = KeyCode.P;
                break;


            case "A":
                attack2 = KeyCode.A;
                break;


            case "S":
                attack2 = KeyCode.S;
                break;


            case "D":
                attack2 = KeyCode.D;
                break;


            case "F":
                attack2 = KeyCode.F;
                break;


            case "G":
                attack2 = KeyCode.G;
                break;


            case "H":
                attack2 = KeyCode.H;
                break;


            case "J":
                attack2 = KeyCode.J;
                break;


            case "K":
                attack2 = KeyCode.K;
                break;


            case "L":
                attack2 = KeyCode.L;
                break;


            case "Z":
                attack2 = KeyCode.Z;
                break;


            case "X":
                attack2 = KeyCode.X;
                break;


            case "C":
                attack2 = KeyCode.C;
                break;


            case "V":
                attack2 = KeyCode.V;
                break;


            case "B":
                attack2 = KeyCode.B;
                break;


            case "N":
                attack2 = KeyCode.N;
                break;


            case "M":
                attack2 = KeyCode.M;
                break;


            case "-":
                attack2 = KeyCode.Minus;
                break;


            case "=":
                attack2 = KeyCode.Equals;
                break;


            case "[":
                attack2 = KeyCode.LeftBracket;
                break;


            case "]":
                attack2 = KeyCode.RightBracket;
                break;


            case ";":
                attack2 = KeyCode.Semicolon;
                break;


            case ":":
                attack2 = KeyCode.Colon;
                break;


            case "'":
                attack2 = KeyCode.Quote;
                break;


            case ",":
                attack2 = KeyCode.Comma;
                break;


            case ".":
                attack2 = KeyCode.Period;
                break;


            case "/":
                attack2 = KeyCode.Slash;
                break;


            default:
                isDup = true;

                inputAttack1.text = "D";
                inputAttack2.text = "F";
                inputDefend1.text = "J";
                inputDefend2.text = "K";

                attack1 = KeyCode.D;
                attack2 = KeyCode.F;
                defend1 = KeyCode.J;
                defend2 = KeyCode.K;

                StartCoroutine(ResultPanel("Please Different Key"));
                break;
        }
    }



    void ChangeDefendKey1(string input)
    {
        input = input.ToUpper();

        switch (input)
        {
            case "1":
                defend1 = KeyCode.Alpha1;
                break;


            case "2":
                defend1 = KeyCode.Alpha2;
                break;


            case "3":
                defend1 = KeyCode.Alpha3;
                break;


            case "4":
                defend1 = KeyCode.Alpha4;
                break;


            case "5":
                defend1 = KeyCode.Alpha5;
                break;


            case "6":
                defend1 = KeyCode.Alpha6;
                break;


            case "7":
                defend1 = KeyCode.Alpha7;
                break;


            case "8":
                defend1 = KeyCode.Alpha8;
                break;


            case "9":
                defend1 = KeyCode.Alpha9;
                break;


            case "0":
                defend1 = KeyCode.Alpha0;
                break;


            case "Q":
                defend1 = KeyCode.Q;
                break;


            case "W":
                defend1 = KeyCode.W;
                break;


            case "E":
                defend1 = KeyCode.E;
                break;


            case "R":
                defend1 = KeyCode.R;
                break;


            case "T":
                defend1 = KeyCode.T;
                break;


            case "Y":
                defend1 = KeyCode.Y;
                break;


            case "U":
                defend1 = KeyCode.U;
                break;


            case "I":
                defend1 = KeyCode.I;
                break;


            case "O":
                defend1 = KeyCode.O;
                break;


            case "P":
                defend1 = KeyCode.P;
                break;


            case "A":
                defend1 = KeyCode.A;
                break;


            case "S":
                defend1 = KeyCode.S;
                break;


            case "D":
                defend1 = KeyCode.D;
                break;


            case "F":
                defend1 = KeyCode.F;
                break;


            case "G":
                defend1 = KeyCode.G;
                break;


            case "H":
                defend1 = KeyCode.H;
                break;


            case "J":
                defend1 = KeyCode.J;
                break;


            case "K":
                defend1 = KeyCode.K;
                break;


            case "L":
                defend1 = KeyCode.L;
                break;


            case "Z":
                defend1 = KeyCode.Z;
                break;


            case "X":
                defend1 = KeyCode.X;
                break;


            case "C":
                defend1 = KeyCode.C;
                break;


            case "V":
                defend1 = KeyCode.V;
                break;


            case "B":
                defend1 = KeyCode.B;
                break;


            case "N":
                defend1 = KeyCode.N;
                break;


            case "M":
                defend1 = KeyCode.M;
                break;


            case "-":
                defend1 = KeyCode.Minus;
                break;


            case "=":
                defend1 = KeyCode.Equals;
                break;


            case "[":
                defend1 = KeyCode.LeftBracket;
                break;


            case "]":
                defend1 = KeyCode.RightBracket;
                break;


            case ";":
                defend1 = KeyCode.Semicolon;
                break;


            case ":":
                defend1 = KeyCode.Colon;
                break;


            case "'":
                defend1 = KeyCode.Quote;
                break;


            case ",":
                defend1 = KeyCode.Comma;
                break;


            case ".":
                defend1 = KeyCode.Period;
                break;


            case "/":
                defend1 = KeyCode.Slash;
                break;


            default:
                isDup = true;

                inputAttack1.text = "D";
                inputAttack2.text = "F";
                inputDefend1.text = "J";
                inputDefend2.text = "K";

                attack1 = KeyCode.D;
                attack2 = KeyCode.F;
                defend1 = KeyCode.J;
                defend2 = KeyCode.K;

                StartCoroutine(ResultPanel("Please Different Key"));
                break;
        }
    }



    void ChangeDefendKey2(string input)
    {
        input = input.ToUpper();

        switch (input)
        {
            case "1":
                defend2 = KeyCode.Alpha1;
                break;


            case "2":
                defend2 = KeyCode.Alpha2;
                break;


            case "3":
                defend2 = KeyCode.Alpha3;
                break;


            case "4":
                defend2 = KeyCode.Alpha4;
                break;


            case "5":
                defend2 = KeyCode.Alpha5;
                break;


            case "6":
                defend2 = KeyCode.Alpha6;
                break;


            case "7":
                defend2 = KeyCode.Alpha7;
                break;


            case "8":
                defend2 = KeyCode.Alpha8;
                break;


            case "9":
                defend2 = KeyCode.Alpha9;
                break;


            case "0":
                defend2 = KeyCode.Alpha0;
                break;


            case "Q":
                defend2 = KeyCode.Q;
                break;


            case "W":
                defend2 = KeyCode.W;
                break;


            case "E":
                defend2 = KeyCode.E;
                break;


            case "R":
                defend2 = KeyCode.R;
                break;


            case "T":
                defend2 = KeyCode.T;
                break;


            case "Y":
                defend2 = KeyCode.Y;
                break;


            case "U":
                defend2 = KeyCode.U;
                break;


            case "I":
                defend2 = KeyCode.I;
                break;


            case "O":
                defend2 = KeyCode.O;
                break;


            case "P":
                defend2 = KeyCode.P;
                break;


            case "A":
                defend2 = KeyCode.A;
                break;


            case "S":
                defend2 = KeyCode.S;
                break;


            case "D":
                defend2 = KeyCode.D;
                break;


            case "F":
                defend2 = KeyCode.F;
                break;


            case "G":
                defend2 = KeyCode.G;
                break;


            case "H":
                defend2 = KeyCode.H;
                break;


            case "J":
                defend2 = KeyCode.J;
                break;


            case "K":
                defend2 = KeyCode.K;
                break;


            case "L":
                defend2 = KeyCode.L;
                break;


            case "Z":
                defend2 = KeyCode.Z;
                break;


            case "X":
                defend2 = KeyCode.X;
                break;


            case "C":
                defend2 = KeyCode.C;
                break;


            case "V":
                defend2 = KeyCode.V;
                break;


            case "B":
                defend2 = KeyCode.B;
                break;


            case "N":
                defend2 = KeyCode.N;
                break;


            case "M":
                defend2 = KeyCode.M;
                break;


            case "-":
                defend2 = KeyCode.Minus;
                break;


            case "=":
                defend2 = KeyCode.Equals;
                break;


            case "[":
                defend2 = KeyCode.LeftBracket;
                break;


            case "]":
                defend2 = KeyCode.RightBracket;
                break;


            case ";":
                defend2 = KeyCode.Semicolon;
                break;


            case ":":
                defend2 = KeyCode.Colon;
                break;


            case "'":
                defend2 = KeyCode.Quote;
                break;


            case ",":
                defend2 = KeyCode.Comma;
                break;


            case ".":
                defend2 = KeyCode.Period;
                break;


            case "/":
                defend2 = KeyCode.Slash;
                break;


            default:
                isDup = true;

                inputAttack1.text = "D";
                inputAttack2.text = "F";
                inputDefend1.text = "J";
                inputDefend2.text = "K";

                attack1 = KeyCode.D;
                attack2 = KeyCode.F;
                defend1 = KeyCode.J;
                defend2 = KeyCode.K;

                StartCoroutine(ResultPanel("Please Different Key"));
                break;
        }
    }


    public void KeyChangeSign()
    {
        isDup = false;

        ChangeAttackKey1(inputAttack1.text);
        ChangeAttackKey2(inputAttack2.text);
        ChangeDefendKey1(inputDefend1.text);
        ChangeDefendKey2(inputDefend2.text);

        if(isDup == false)
        {
            if (attack1 == attack2 || attack1 == defend1 || attack1 == defend2 || attack2 == defend1 || attack2 == defend2 || defend1 == defend2)
            {
                inputAttack1.text = "D";
                inputAttack2.text = "F";
                inputDefend1.text = "J";
                inputDefend2.text = "K";

                attack1 = KeyCode.D;
                attack2 = KeyCode.F;
                defend1 = KeyCode.J;
                defend2 = KeyCode.K;

                StartCoroutine(ResultPanel("No Duplication Key"));
            }
            else
            {
                StartCoroutine(ResultPanel("Success Change Key"));
            }
        }


        PlayerPrefs.SetString("attackKey1", inputAttack1.text);
        PlayerPrefs.SetString("attackKey2", inputAttack2.text);
        PlayerPrefs.SetString("defendKey1", inputDefend1.text);
        PlayerPrefs.SetString("defendKey2", inputDefend2.text);
    }


    IEnumerator ResultPanel(string str)
    {
        KeyChange();
        resultPanel.SetActive(true);
        resultText.text = str;
        yield return new WaitForSeconds(0.5f);
        resultPanel.SetActive(false);
    }

    void KeyChange()
    {
        Information.instance._attack1 = attack1;
        Information.instance._attack2 = attack2;
        Information.instance._defend1 = defend1;
        Information.instance._defend2 = defend2;
    }
}