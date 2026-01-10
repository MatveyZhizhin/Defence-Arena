using System;
using TMPro;
using UnityEngine;
using YG;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class _Player : Attacker, IPlayer
    {
        [SerializeField] private float speed;
        [SerializeField] private float startHealth;
        private float currentHealth;

        public event Action OnPlayerDeath;
        public event Action OnPlayerRevive;

        [SerializeField] private TextMeshProUGUI healthText;

        private Rigidbody playerRigidbody;
        private Animator animator;
        [SerializeField] private Joystick joystick;

        public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public float StartHealth { get => startHealth;}

        public float Speed { get => speed; set => speed = value; }

        private const int ReviveAdId = 1;

        private void Awake()
        {
            TryGetComponent(out playerRigidbody);
            TryGetComponent(out animator);
        }

        private void Start()
        {
            currentHealth = startHealth;
            healthText.SetText(currentHealth.ToString());         
        }

        public void UpdateHealth()
        {
            healthText.SetText(currentHealth.ToString());
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += Revive;
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= Revive;
        }

        public void TakeDamage(float damage)
        {           
            currentHealth -= damage;
            if (damage > currentHealth)
            {
                currentHealth = 0;
            }

            healthText.SetText(currentHealth.ToString());

            if (currentHealth <= 0)
            {
                OnPlayerDeath?.Invoke();
            }
        }


        private void Move()
        {
            Vector3 movement;

            if (YandexGame.EnvironmentData.isMobile)
            {
               movement = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
            }
            else
            {
                movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
                joystick.gameObject.SetActive(false);
            }
            
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

        private void Revive(int id)
        {
            if (ReviveAdId == id)
            {
                currentHealth = startHealth;
                healthText.SetText(currentHealth.ToString());
                OnPlayerRevive?.Invoke();
            }          
        }
    }
}
