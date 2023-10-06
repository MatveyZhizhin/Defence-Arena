using Assets.Scripts.Enemy;
using Assets.Scripts.Player;
using UnityEngine;
enum Bullet
{
    playerBullet,
    enemyBullet
}

public class _Bullet : MonoBehaviour
{        
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float distance;

    [SerializeField] private LayerMask solid;
    [SerializeField] private Bullet bullet;

    private float damage;

    private void FixedUpdate()
    {
        Fire();
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;       
    }

    private void Fire()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, solid))
        {                
            if (hitInfo.collider != null)
            {
                if (bullet == Bullet.enemyBullet && hitInfo.collider.TryGetComponent(out IPlayer player))
                {
                    player.TakeDamage(damage);
                }

                if (bullet == Bullet.playerBullet && hitInfo.collider.TryGetComponent(out IEnemy enemy))
                {
                    enemy.TakeDamage(damage);
                }
                Destroy(gameObject);
            }               
        }
        Destroy(gameObject, lifeTime);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);            
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
    }
}

