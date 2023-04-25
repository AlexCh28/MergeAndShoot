using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Touch _firstTouch;
    private Touch _secondTouch;

    public Touch FirstTouch => _firstTouch;
    public Touch SecondTouch => _secondTouch;
    public bool Touched => Input.touchCount>0;

    private void Update() {
        if (Input.touchCount == 0) return;
        _firstTouch = Input.GetTouch(0);

        if (Input.touchCount < 2) return;
        _secondTouch = Input.GetTouch(1);
    }
}
