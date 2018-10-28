using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts.Environment {
    public abstract class BaseEnvironment : MonoBehaviour, IEnvironment, IPausable {
        static readonly Vector3 scrollTo = Vector3.left;

        [SerializeField]
        protected float scrollSpeed;
        [SerializeField]
        protected Transform objectSpawnAt;
        [SerializeField]
        protected Transform destroySpawnAt;

        protected bool isPaused = false;

        public virtual void Pause() {
            isPaused = true;
        }
        public virtual void UnPause() {
            isPaused = false;
        }
        public virtual void Scroll() {
            transform.position += scrollTo * scrollSpeed * Time.deltaTime;
        }
    }
}
