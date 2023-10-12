using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class ShootSystem : IEcsInitSystem, IEcsRunSystem {
        private EcsFilter _filter;
        private EcsPool<EcsShoot> _entetiPool;
        public void Init(IEcsSystems systems)
        {

            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<EcsShoot>().End();
            _entetiPool = world.GetPool<EcsShoot>();



        }

        public void Run(IEcsSystems systems)
        {
            foreach (var item in _filter)
            {
                ref EcsShoot EcsShoot = ref _entetiPool.Get(item);
                ref var speed = ref EcsShoot.Speed;
                ref var transforms = ref EcsShoot.Transform;
                //ref var shootTurrel = ref EcsShoot.ShootTurrel;

                transforms.Translate(Vector3.forward * Time.deltaTime * speed);

                //transforms.Translate(shootTurrel.transform.position);


                //GameObject.Destroy(this.Object , 2.0f);

            }
        }
    }
}