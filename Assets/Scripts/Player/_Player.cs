using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class _Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private float speed;
        [SerializeField] private float health;

        private Rigidbody playerRigidbody;
        [SerializeField] private Joystick joystick;

        public float Health { set => health = value; }
        [field: SerializeField] public float Damage { get; set; }

        private void Awake()
        {
            TryGetComponent(out playerRigidbody);
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void TakeDamage(float damage)
        {           
            health -= damage;

            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


        private void Move()
        {
            var movement = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);

            playerRigidbody.velocity = movement * speed;
            transform.LookAt(movement + transform.position);
        }
    }
}
