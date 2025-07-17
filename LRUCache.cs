namespace Algorithm;

public class LRUCache<K, V>(int capacity) where K : notnull
{
    private readonly int _capacity = capacity;
    private readonly Dictionary<K, LinkedListNode<CacheItem>> cache = [];
    private readonly LinkedList<CacheItem> list = new();

    public V? Get(K key)
    {
        if (cache.TryGetValue(key, out var node))
        {
            var value = node.Value.Value;
            list.Remove(node);
            list.AddLast(node);
            return value;
        }

        return default;
    }

    public void Set(K key, V val)
    {
        if (cache.TryGetValue(key, out var existingNode))
        {
            list.Remove(existingNode);
        }
        else if (cache.Count >= _capacity)
        {
            RemoveFirst();
        }

        CacheItem cacheItem = new(key, val);
        LinkedListNode<CacheItem> node = new(cacheItem);

        list.AddLast(node);
        cache[key] = node;
    }

    private void RemoveFirst()
    {
        if (list.First is null)
            throw new InvalidOperationException("Cache is empty, cannot remove item.");

        var node = list.First;

        // Remove from LRUPriority
        list.RemoveFirst();
        // Remove from cache
        cache.Remove(node.Value.Key);
    }

    record CacheItem(K Key, V Value);
}
