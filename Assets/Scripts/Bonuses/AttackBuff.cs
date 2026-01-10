
namespace Bonuses
{
    public class AttackBuff: Bonus
    {
        protected override void UseBuff()
        {
            _player.Damage += _value;
        }
        
    }
}