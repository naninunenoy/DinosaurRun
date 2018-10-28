using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts.Environment {
    public interface IEnvironment {
        void Scroll(Vector2 direction, float speed);
        void SetObjectSpawnPoint(Transform spawnAt);
        void SetObjectDestroyPoint(Transform destroyAt);
    }
}
