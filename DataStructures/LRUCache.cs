namespace DataStructure;

public class LRUCache<K, V>(int capacity) where K : notnull
{
    private readonly int _capacity = capacity;
    private readonly Dictionary<K, LinkedListNode<CacheItem>> cache = [];
    private readonly LinkedList<CacheItem> list = new();

    public V? Get(K key)
    {
        if (!cache.TryGetValue(key, out var node))
            return default;

        list.Remove(node);
        list.AddLast(node);
        return node.Value.Value;
    }

    public void Set(K key, V value)
    {
        if (cache.TryGetValue(key, out var existing))
        {
            list.Remove(existing);
        }
        else if (cache.Count >= _capacity)
        {
            cache.Remove(list.First!.Value.Key);
            list.RemoveFirst();
        }

        LinkedListNode<CacheItem> node = new(new(key, value));

        list.AddLast(node);
        cache[key] = node;
    }

    record CacheItem(K Key, V Value);
}
