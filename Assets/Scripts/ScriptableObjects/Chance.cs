using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewChance", menuName = "ScriptableObjects/Chance")]
    public class Chance : ScriptableObject
    {
        public List<int> Chances;
    }
}
