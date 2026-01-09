namespace Bonuses
{
    public class HealthBuff: Bonus
    {
        protected override void UseBuff()
        {
            _player.CurrentHealth += _meaning;
            _player.UpdateHealth();
        }
    }
}