using UnityEngine;

public class GamePoint : MonoBehaviour
{
    public SongTitle SongTitle;

    private void Awake()
    {
        gameObject.name = SongTitle.ToString();
    }
}
