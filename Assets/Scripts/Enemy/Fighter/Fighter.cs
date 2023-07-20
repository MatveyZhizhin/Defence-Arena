
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy.Fighter
{   
    public class Fighter : Enemy
    {       
        protected override IEnumerator Attack()
        {
            while (true)
            {               
                print("attack");
                yield return new WaitForSeconds(1);
            }
        }
    }
}