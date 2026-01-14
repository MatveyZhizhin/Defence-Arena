using Assets.Scripts.Player;
using UnityEngine;

namespace Bonuses
{
    public class AttackBuff: Bonus
    {
        [SerializeField] private float _duration;

        protected override void UseBuff(_Player player)
        {
            player.StartCoroutine(player.AddDamageTemporarily(_value, _duration));
        }
    }
}