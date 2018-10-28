using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts.Environment {
    public class ObjectSpawner : MonoBehaviour, ISpawner {
        [SerializeField] GameObject prefab;

        public GameObject Spawn(Vector3 spawnAt) {
            return Instantiate(prefab, spawnAt, Quaternion.identity, transform);
        }
    }
}
