

namespace Assets.Scripts.Player
{
    public interface IPlayer
    {
        public float Health { set; }
        public float Damage { get; set; }
        public void TakeDamage(float damage);
    }
}
