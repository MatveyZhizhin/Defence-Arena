using Assets.Scripts.Enemy;

namespace Triggers
{
    public class SpawnPointTrigger : Trigger<_Enemy>
    {
        private bool _hasSpace = false;

        public bool HasSpace => _hasSpace;

        protected override void OnEnter(_Enemy triggered)
        {
            _hasSpace = false;
        }

        protected override void OnExit(_Enemy triggered)
        {
            _hasSpace = true;
        }
    }
}

