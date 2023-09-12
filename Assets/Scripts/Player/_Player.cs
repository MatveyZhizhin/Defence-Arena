using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class _Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private float speed;
        [SerializeField] private float health;

        public event Action OnPlayerDeath;

        [SerializeField] private TextMeshProUGUI healthText;

        private Rigidbody playerRigidbody;
        [SerializeField] private Joystick joystick;

        public float Health { get => health; set => health = value; }
        [field: SerializeField] public float Damage { get; set; }
        public float Speed { get => speed; set => speed = value; }

        private void Awake()
        {
            TryGetComponent(out playerRigidbody);
        }

        private void Start()
        {
            healthText.SetText($"Health: {health}");
        }

        public void UpdateHealth()
        {
            healthText.SetText($"Health: {health}");
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void TakeDamage(float damage)
        {           
            health -= damage;
            healthText.SetText($"Health: {health}");

            if (health <= 0)
            {
                OnPlayerDeath.Invoke();
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
