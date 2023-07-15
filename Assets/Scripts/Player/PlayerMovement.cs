
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody playerRigidbody;

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
            var movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

           playerRigidbody.AddForce(movement * speed);
           transform.LookAt(movement + transform.position);
        }
    }
}
