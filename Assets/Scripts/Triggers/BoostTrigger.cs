using Assets.Scripts.Player;
using UnityEngine;

namespace Triggers
{
    public class BoostTrigger : Trigger<_Player>
    {
        [SerializeField] private float _boostForce;

        protected override void OnEnter(_Player triggered)
        {
            triggered.GetComponent<Rigidbody>().AddForce(-transform.forward * _boostForce);
        }
    }
}
