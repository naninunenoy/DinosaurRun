using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts.Player {
    public interface IPlayer {
        void Jump(float speed);
        void Damage(float damage);
    }
}