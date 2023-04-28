using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    protected float _health;

    protected Animator _animator;
    protected Transform _player;
    protected NavMeshAgent _agent;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerTag>().transform;
    }

    private void FixedUpdate() {
        _agent.destination = _player.position;
        _animator.SetBool("IsWalk", _agent.remainingDistance>1.5f);
    }

    public virtual void GetDamage(float damage)
    {
        if (_health <= 0) {Debug.LogWarning("Health below zero"); return;}

        _health = _health-damage > 0 ? _health-damage : 0;   

        if (_health <= 0) Destroy(gameObject); 
    }
}
