
namespace Assets.Scripts.Enemy
{
    public interface IEnemy
    {
        public void TakeDamage(float damage);
        public void AddHealth(int health);
        public void AddSpeed(float speed);
    }
}
