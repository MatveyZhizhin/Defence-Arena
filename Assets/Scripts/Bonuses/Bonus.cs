using Assets.Scripts.Player;
using Triggers;
using UnityEngine;

namespace Bonuses
{
    public abstract class Bonus : Trigger<_Player>
    {
        protected _Player _player;
        [SerializeField] protected float _value;
        [SerializeField] protected float _lifeTime;

        private void Start()
        {
            _player = FindFirstObjectByType<_Player>();
            Destroy(gameObject, _lifeTime);
        }
        protected override void OnEnter(_Player triggered)
        {
            UseBuff();
            Destroy(gameObject);
        }
        
        protected abstract void UseBuff();
    }
}