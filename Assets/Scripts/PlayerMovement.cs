using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    private NavMeshAgent _agent;

    private void Awake() {
        _input = GetComponent<PlayerInput>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (!_input.Touched) return;

        Ray ray = Camera.main.ScreenPointToRay(_input.FirstTouch.position);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)){
            _agent.destination = hitInfo.point;
        }    
    }
}
