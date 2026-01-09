using System.Collections.Generic;
using UnityEngine;

public static class Randomizer
{  
    public static int GetRandomIndexWithChance(List<int> chances)
    {
        var randomValue = Random.Range(1, 101);
        var possibleChances = new List<int>();

        foreach (var chance in chances)
        {
            if (randomValue <=  chance)
                possibleChances.Add(chance);
        }    

        if (possibleChances.Count > 0 )
            return chances.IndexOf(possibleChances[Random.Range(0, possibleChances.Count)]);

        return chances.IndexOf(Mathf.Max(chances.ToArray()));
    }
}
