using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;

    private void Awake() {
        _input = GetComponent<PlayerInput>();
    }

    private void Update() {
        if (!_input.Touched) return;

        print(_input.FirstTouch.position);
        Ray ray = Camera.main.ScreenPointToRay(_input.FirstTouch.position);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)){
            print(hitInfo.point);
            transform.position = hitInfo.point;
        }    
    }
}
