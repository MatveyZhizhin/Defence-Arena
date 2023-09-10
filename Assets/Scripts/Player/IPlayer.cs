

namespace Assets.Scripts.Player
{
    public interface IPlayer
    {
        public float Speed { get; set; }
        public float Health { get; set; }
        public float Damage { get; set; }
        public void TakeDamage(float damage);
    }
}
