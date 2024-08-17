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
        public event Action OnPlayerRevive;

        [SerializeField] private TextMeshProUGUI healthText;

        private Rigidbody playerRigidbody;
        private Animator animator;
        [SerializeField] private Joystick joystick;
        [SerializeField] private DeviceTypeDetector detector;

        public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public float StartHealth { get => startHealth;}
        [field: SerializeField] public float Damage { get; set; }
        public float Speed { get => speed; set => speed = value; }

        private const int ReviveAdId = 1;

        private void Awake()
        {
            TryGetComponent(out playerRigidbody);
            TryGetComponent(out animator);
            detector = FindObjectOfType<DeviceTypeDetector>();
        }

        private void Start()
        {
            currentHealth = startHealth;
            healthText.SetText($"Çהמנמגüו: {currentHealth}");         
        }

        public void UpdateHealth()
        {
            healthText.SetText($"Çהמנמגüו: {currentHealth}");
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
            healthText.SetText($"Çהמנמגüו: {currentHealth}");

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

        private void Revive(int id)
        {
            if (ReviveAdId == id)
            {
                currentHealth = startHealth;
                OnPlayerRevive?.Invoke();
            }          
        }
    }
}
