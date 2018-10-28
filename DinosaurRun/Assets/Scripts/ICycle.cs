using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts {
    public interface ICycle {
        bool TrySpawn(Transform spawnAt, GameObject prefab, float spawnProb);
        bool TryDestroy(Transform destroyAt);
    }
}
