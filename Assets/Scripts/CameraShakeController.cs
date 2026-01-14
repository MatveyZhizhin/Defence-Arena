using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    [SerializeField] private Animator _cameraAnimator;

    private bool _isCameraShakeEnabled = false;

    public void ToggleCameraShake(bool toggle)
    {
       _isCameraShakeEnabled = toggle;
    }

    public void ShakeCamera()
    {
        if (_isCameraShakeEnabled)
        {
            _cameraAnimator.SetTrigger("Shake");
        }
    }
}
