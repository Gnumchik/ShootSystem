using Leopotam.EcsLite;
using Palmmedia.ReportGenerator.Core.Parser.Filtering;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Client {
    sealed class SpawnSystem : IEcsInitSystem , IEcsRunSystem{

        private EcsFilter _filter;
        private EcsPool<EcsSpawner> _entetiPool;
        public void Init (IEcsSystems systems) {

            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<EcsSpawner>().End();
            _entetiPool = world.GetPool<EcsSpawner>();

        }

        public void Run(IEcsSystems systems)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                foreach (var item in _filter)
                {
                    ref EcsSpawner moveEcsComponent = ref _entetiPool.Get(item);
                    ref var prefab = ref moveEcsComponent.Object;
                    ref var transform = ref moveEcsComponent.transform;

                    GameObject.Instantiate(prefab).transform.position = transform.position;

                }
            }
        }
    }
}