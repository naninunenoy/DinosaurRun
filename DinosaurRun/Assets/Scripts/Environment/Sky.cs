using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts.Environment {
    public class Sky : BaseEnvironment {
        [SerializeField] EnemySpawner pterosaurSpawner;

        ObjectSpawner[] cloudSpawner;
        void Awake() {
            cloudSpawner = GetComponents<ObjectSpawner>();
        }

        void Start() {

        }

        void Update() {

        }
    }
}