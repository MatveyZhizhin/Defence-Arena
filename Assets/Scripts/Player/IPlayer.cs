

using System;

namespace Assets.Scripts.Player
{
    public interface IPlayer
    {
        public float Speed { get; set; }
        public float CurrentHealth { get; set; }
        public float StartHealth { get; }
        public event Action OnPlayerDeath;
        public event Action OnPlayerRevive;
        public void TakeDamage(float damage);
        public void UpdateHealth();
    }
}
