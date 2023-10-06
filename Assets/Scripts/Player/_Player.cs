using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class _Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private float speed;
        [SerializeField] private float startHealth;
        private float currentHealth;

        public event Action OnPlayerDeath;

        [SerializeField] private TextMeshProUGUI healthText;

        private Rigidbody playerRigidbody;
        private Animator animator;
        [SerializeField] private Joystick joystick;

        public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public float StartHealth { get => startHealth;}
        [field: SerializeField] public float Damage { get; set; }
        public float Speed { get => speed; set => speed = value; }

        private void Awake()
        {
            TryGetComponent(out playerRigidbody);
            TryGetComponent(out animator);
        }

        private void Start()
        {
            currentHealth = startHealth;
            healthText.SetText($"Health: {currentHealth}");         
        }

        public void UpdateHealth()
        {
            healthText.SetText($"Health: {currentHealth}");
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void TakeDamage(float damage)
        {           
            currentHealth -= damage;
            healthText.SetText($"Health: {currentHealth}");

            if (currentHealth <= 0)
            {
                OnPlayerDeath?.Invoke();
            }
        }


        private void Move()
        {
            var movement = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);

           if (movement != new Vector3(0f, 0f, 0f))
           {
                animator.SetBool("isRunning", true);
           }
           else
           {
                animator.SetBool("isRunning", false);
           }

            playerRigidbody.velocity = movement * speed;
            transform.LookAt(-movement + transform.position);
        }
    }
}
