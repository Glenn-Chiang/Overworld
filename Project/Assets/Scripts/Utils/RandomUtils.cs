using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public static class RandomUtils
{
    public static T RandomSelect<T>(IReadOnlyList<T> items)
    {
        int index = Random.Range(0, items.Count);
        return items[index];
    }

    public static T WeightedRandomSelect<T>(IList<T> items)
    {
        // TODO: Implement weighted random select
        int index = Random.Range(0, items.Count);
        return items[index];
    }
}