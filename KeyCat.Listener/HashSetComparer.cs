namespace KeyCat.Listener;

internal sealed class HashSetComparer : IEqualityComparer<HashSet<Keys>>
{
    public static readonly HashSetComparer Instance = new();

    public bool Equals(HashSet<Keys> x, HashSet<Keys> y)
    {
        return x.SetEquals(y);
    }

    public int GetHashCode(HashSet<Keys> obj)
    {
        var hash = 0;
        foreach (var key in obj)
        {
            hash ^= key.GetHashCode();
        }
        return hash;
    }
}