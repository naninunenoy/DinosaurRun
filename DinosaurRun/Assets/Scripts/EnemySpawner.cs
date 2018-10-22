﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    protected GameObject enemyPrefab;
    [SerializeField] [Range(0, 1)]
    protected float spawnProb = 1.0F;
}
