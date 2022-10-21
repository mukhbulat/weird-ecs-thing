using Client.Components;
using Client.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class ColorChangeSystem : IEcsRunSystem
    {
        private GameData _gameData;
        private EcsFilter<ColorComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var color = ref _filter.Get1(i);
                float lerp = Mathf.PingPong(Time.time, _gameData.ColorChangeDuration) / _gameData.ColorChangeDuration;
                color.Renderer.material.color = Color.Lerp(color.StartColor, color.EndColor, lerp);
            }
        }
    }
}