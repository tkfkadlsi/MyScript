using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    public static Information instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }


    public KeyCode _attack1;
    public KeyCode _attack2;
    public KeyCode _defend1;
    public KeyCode _defend2;

    public float _noteSpeed;

    public int _plusOffset;

    public Color _attackNoteColor;
    public Color _defendNoteColor;

    public int Stage;

    public bool clearGame;

    public int _critical;
    public int _nice;
    public int _miss;
    public int _defense;
    public int _safe;
    public int _break;

    public int _highCombo;
}
