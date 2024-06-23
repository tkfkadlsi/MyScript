public class DataKey
{
    public static string ReturnKey(SongTitle song, DiffcultType diff)
    {
        return $"{song.ToString()},{diff.ToString()}";
    }
}
