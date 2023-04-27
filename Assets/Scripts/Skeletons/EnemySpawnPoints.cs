using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoints : MonoBehaviour
{
    private EnemySpawnTag[] _points;
    
    private void Awake() {
        _points = FindObjectsOfType<EnemySpawnTag>();
    }
}
