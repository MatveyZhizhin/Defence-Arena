
namespace Assets.Scripts.Enemy
{
    public interface IEnemy
    {
        public void TakeDamage(float damage);
        public void IncreaseHealth(int health);
        public void IncreaseSpeed(float speed);
    }
}
