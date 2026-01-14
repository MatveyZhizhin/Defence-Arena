using System;
using System.Collections;
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
        private Animator[] animators;
        [SerializeField] private Joystick joystick;
        [SerializeField] private GameObject shield;

        private bool isInvincible;

        public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public float StartHealth { get => startHealth;}

        public float Speed { get => speed; set => speed = value; }

        private const int ReviveAdId = 1;

        private void Awake()
        {
            TryGetComponent(out playerRigidbody);
            animators = GetComponentsInChildren<Animator>();
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
            if (isInvincible)
                return;

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

        public IEnumerator MakeInvincible(float duration)
        {
            isInvincible = true;
            shield.SetActive(true);
            yield return new WaitForSeconds(duration);
            shield.SetActive(false);
            isInvincible = false;
        }

        public IEnumerator AddDamageTemporarily(float damage, float duration)
        {
            Damage += damage;
            yield return new WaitForSeconds(duration);
            Damage -= damage;
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
                GetActiveAnimator().SetBool("isRunning", true);
            }
            else
            {
                GetActiveAnimator().SetBool("isRunning", false);
            }

            playerRigidbody.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
            transform.LookAt(movement + transform.position);
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

        private Animator GetActiveAnimator()
        {
            foreach (var animator in animators)
            {
                if (animator.gameObject.activeInHierarchy)
                    return animator;
            }
            return null;
        }
    }
}
