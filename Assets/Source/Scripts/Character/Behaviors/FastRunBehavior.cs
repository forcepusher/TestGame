using UnityEngine;

namespace Faraway.TestGame
{
    public class FastRunBehavior : IBehavior
    {
        private readonly IRunner _runner;
        private Vector3 _velocity;

        public FastRunBehavior(IRunner runner)
        {
            _runner = runner;
        }

        public void End() => throw new System.NotImplementedException();
        public void Start() => throw new System.NotImplementedException();

        public void Tick()
        {
            
        }
    }
}
