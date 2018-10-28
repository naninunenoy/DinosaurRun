using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts {
    public interface ICycle {
        bool TrySpawn(Transform spawnAt, GameObject prefab);
        bool TryDestroy(Transform destroyAt);
    }
}
