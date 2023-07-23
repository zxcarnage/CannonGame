using UnityEngine;
public class CannonRotation : MonoBehaviour
{
    [SerializeField] private float _horizontalFov;
    [SerializeField] private float _verticalLower;
    [SerializeField] private float _verticalUpper;
    [SerializeField] private float _sensitivity;

    private float _currentVerticalRotation;
    private float _currentHorizontalRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;
        TryRotate(horizontal, vertical);
    }

    private void TryRotate(float horizontal, float vertical)
    {
        _currentHorizontalRotation = Mathf.Clamp(_currentHorizontalRotation + horizontal, -_horizontalFov, _horizontalFov);
        _currentVerticalRotation = Mathf.Clamp(_currentVerticalRotation + vertical, _verticalLower, _verticalUpper);
        transform.localRotation = Quaternion.Euler(new Vector3(0,_currentHorizontalRotation,_currentVerticalRotation));
    }
}
