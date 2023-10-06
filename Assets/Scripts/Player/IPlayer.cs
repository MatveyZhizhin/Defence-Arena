

using System;

namespace Assets.Scripts.Player
{
    public interface IPlayer
    {
        public float Speed { get; set; }
        public float CurrentHealth { get; set; }
        public float StartHealth { get; }
        public float Damage { get; set; }
        public event Action OnPlayerDeath;
        public void TakeDamage(float damage);
        public void UpdateHealth();
    }
}
