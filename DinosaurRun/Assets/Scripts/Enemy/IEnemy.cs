using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DinosaurRun.Scripts.Enemy {
    public interface IEnemy {
        void MoveTo(Vector2 to, float speed);
        void HitPlayer(Player.IPlayer player);
    }
}
