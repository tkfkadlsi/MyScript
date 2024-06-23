using System.Collections.Generic;

public class GameData
{
    public int playCount = 0;

    public Dictionary<string, int> PlayerHighScore = new Dictionary<string, int>();
    public Dictionary<string, float> PlayerHighRate = new Dictionary<string, float>();
}
