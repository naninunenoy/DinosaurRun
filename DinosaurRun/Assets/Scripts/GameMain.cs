using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] Dinosaur dinosaur;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            dinosaur.IsRunning = !dinosaur.IsRunning;
        }
    }
}
