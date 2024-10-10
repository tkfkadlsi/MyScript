using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Key
{
    public string KeyName;
    public KeyCode Code;
}

[System.Serializable]
public class Keys
{
    public string ListName;

    public List<Key> KeyList = new List<Key>();
}