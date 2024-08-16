using RimuruDev;
using System;
using TMPro;
using UnityEngine;
using YG;

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
        [SerializeField] private DeviceTypeDetector detector;

        public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public float StartHealth { get => startHealth;}
        [field: SerializeField] public float Damage { get; set; }
        public float Speed { get => speed; set => speed = value; }

        private void Awake()
        {
            TryGetComponent(out playerRigidbody);
            TryGetComponent(out animator);
            detector = FindObjectOfType<DeviceTypeDetector>();
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
            Vector3 movement;

            if (detector.CurrentDeviceType == CurrentDeviceType.WebMobile)
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
    }
}
