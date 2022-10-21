using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class DirectionSetSystem : IEcsRunSystem
    {
        private EcsFilter<DirectionComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var direction = ref _filter.Get1(i);
                direction.Direction = new Vector3(Random.value * (Random.value > 0.5f ? 1 : -1),
                    Random.value * (Random.value > 0.5f ? 1 : -1), Random.value * (Random.value > 0.5f ? 1 : -1));
            }
        }
    }
}