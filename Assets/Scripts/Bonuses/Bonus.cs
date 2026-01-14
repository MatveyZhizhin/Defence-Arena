using Assets.Scripts.Player;
using Triggers;
using UnityEngine;

namespace Bonuses
{
    public abstract class Bonus : Trigger<_Player>
    {
        [SerializeField] protected float _value;
        [SerializeField] protected float _lifeTime;

        private void Start()
        {
            Destroy(gameObject, _lifeTime);
        }
        protected override void OnEnter(_Player triggered)
        {
            UseBuff(triggered);
            Destroy(gameObject);
        }
        
        protected abstract void UseBuff(_Player player);
    }
}