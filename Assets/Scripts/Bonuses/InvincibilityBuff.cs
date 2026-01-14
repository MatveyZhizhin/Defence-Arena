using Assets.Scripts.Player;

namespace Bonuses
{
    public class InvincibilityBuff : Bonus
    {
        protected override void UseBuff(_Player player)
        {
            player.StartCoroutine(player.MakeInvincible(_value));
        }
    }
}
