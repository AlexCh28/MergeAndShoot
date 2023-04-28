using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _intervalBetweeenAttacks;

    private float _timer;

    private Enemy _enemy;
    private Enemy[] _enemies;

    private void Start() {
        FindNearestEnemy();
    }

    private void Update() {
        _timer += Time.deltaTime;
        if (_timer < _intervalBetweeenAttacks) return;

        if (_enemy != null){
            _timer = 0;
            AttackNearest(_damage);
        }
        else FindNearestEnemy();
    }

    private void FindNearestEnemy(){
         _enemies = FindObjectsOfType<Enemy>();
        
        if (_enemies.Length<=0) return;

        _enemy  = _enemies.OrderBy( e => (e.transform.position-transform.position).sqrMagnitude ).First();
    }

    private void AttackNearest(float damage){
        _enemy.GetDamage(damage);
    }
}
