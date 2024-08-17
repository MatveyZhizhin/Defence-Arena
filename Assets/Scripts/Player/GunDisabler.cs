using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class GunDisabler : MonoBehaviour
    {
        [SerializeField] private Gun[] guns;

        public void EnableGun()
        {
            foreach (var gun in guns)
            {
                if (gun.gameObject.activeInHierarchy)
                {
                    gun.enabled = true;
                }
            }
        }

        public void DisableGun()
        {
            foreach(var gun in guns)
            {
                if (gun.gameObject.activeInHierarchy)
                {
                    gun.enabled = false;
                }
            }
        }
    }
}
