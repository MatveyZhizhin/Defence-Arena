using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    public bool IsCameraShakeEnabled { get; private set; } = true;

    public void ToggleCameraShake(bool toggle)
    {
       IsCameraShakeEnabled = toggle;
    }
}
