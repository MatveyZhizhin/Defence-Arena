
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class _Player : MonoBehaviour
    {
        [SerializeField] private float speed;
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

        private void Move()
        {
            var movement = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);

            playerRigidbody.velocity = movement * speed;
            transform.LookAt(movement + transform.position);
        }
    }
}
