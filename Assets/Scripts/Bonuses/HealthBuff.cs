using Assets.Scripts.Player;

namespace Bonuses
{
    public class HealthBuff: Bonus
    {
        protected override void UseBuff(_Player player)
        {
            player.CurrentHealth += _value;
            player.UpdateHealth();
        }
    }
}