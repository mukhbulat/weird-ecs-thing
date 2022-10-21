using Client.Systems;
using Client.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class EcsStartup : MonoBehaviour 
    {
        EcsWorld _world;
        EcsSystems _systems;

        [SerializeField] private GameData _gameData;

        void Start () 
        {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new CharacterInitSystem())
                .Add(new DirectionSetSystem())
                .Add(new MovementSystem())
                .Add(new ColorChangeSystem())
                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                .Inject(_world)
                .Inject(_gameData)
                .Init ();
        }

        void Update () 
        {
            _systems?.Run ();
        }

        void OnDestroy () 
        {
            _systems?.Destroy();
            _systems = null;
            _world?.Destroy();
            _world = null;
        }
    }
}