using Client.Components;
using Client.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class CharacterInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private GameData _gameData;
        
        public void Init()
        {
            for (int i = 0; i < _gameData.CharactersCount; i++)
            {
                EcsEntity characterEntity = _world.NewEntity();

                ref MovableComponent movable = ref characterEntity.Get<MovableComponent>();
                ref DirectionComponent direction = ref characterEntity.Get<DirectionComponent>();
                ref ColorComponent color = ref characterEntity.Get<ColorComponent>();

                var characterGameObject = _gameData.InstanceCreator.CreateInstance(_gameData.StandardCharacterPrefab);

                color.Renderer = characterGameObject.GetComponent<Renderer>();

                color.StartColor = _gameData.AvailableColors[Random.Range(0, _gameData.AvailableColors.Count)];
                color.EndColor = _gameData.AvailableColors[Random.Range(0, _gameData.AvailableColors.Count)];
                
                movable.MaxPositionVariation = _gameData.CharacterMaxPositionVariation;
                movable.Rigidbody = characterGameObject.GetComponent<Rigidbody>();
            }
        }
    }
}