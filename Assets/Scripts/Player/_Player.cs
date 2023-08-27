using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class _Player : MonoBehaviour, IUnit
    {
        [SerializeField] private float speed;
        [field: SerializeField] public float Health { get; set; }

        private Rigidbody playerRigidbody;
        [SerializeField] private Joystick joystick;     
        
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
            Health -= damage;

            if (Health <= 0)
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
