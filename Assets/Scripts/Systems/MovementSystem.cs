using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private EcsFilter<MovableComponent> _filter;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);

                ref var direction = ref entity.Get<DirectionComponent>();
                ref var movable = ref entity.Get<MovableComponent>();

                var motion = direction.Direction * Time.deltaTime * movable.MaxPositionVariation;
                
                // vibrato
                movable.Rigidbody.MovePosition(motion + movable.Rigidbody.position);
            }
        }
    }
}