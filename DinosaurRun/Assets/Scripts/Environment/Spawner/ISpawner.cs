using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts.Environment {
    public interface ISpawner {
        GameObject Spawn(Vector3 spawnAt);
    }
}
