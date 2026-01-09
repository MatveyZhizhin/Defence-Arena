
namespace Bonuses
{
    public class AttackBonus: Bonus
    {
        protected override void UseBuff()
        {
            _player.Damage += _value;
        }
        
    }
}