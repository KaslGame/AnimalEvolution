using System;
using System.Collections.Generic;

namespace GameBehaviors
{
    public class GameBehaviorChanger
    {
        private Dictionary<Type, IGameBehavior> _behaviors = new Dictionary<Type, IGameBehavior>();

        private IGameBehavior _currentBehavior;

        public void AddBehavior(IGameBehavior gameBehavior)
        {
            if (gameBehavior == null)
                return;

            _behaviors.Add(gameBehavior.GetType(), gameBehavior);
        }

        public void SetBehavior<T>() where T : IGameBehavior
        {
            var type = typeof(T);

            if (_currentBehavior?.GetType() == type)
                return;

            if (_behaviors.TryGetValue(type, out IGameBehavior gameBehavior))
            {
                _currentBehavior?.Exit();

                _currentBehavior = gameBehavior;

                _currentBehavior?.Enter();
            }
        }
    }
}