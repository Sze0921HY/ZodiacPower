using Unity.Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineCamera virtualCamera;

    private CinemachineThirdPersonFollow thirdPersonFollow;

    [Header("Scale Settings")]
    public float scaleThreshold = 0.04f;

    [Header("Camera Settings")]
    public float normalZOffset = -3f;
    public float zoomedZOffset = -5f;
    public float zoomedYOffset = 2f;

    void Start()
    {
        // Fix: Use the non-generic GetCinemachineComponent and pass the correct stage
        thirdPersonFollow = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body) as CinemachineThirdPersonFollow;
    }

    void Update()
    {
        if (thirdPersonFollow == null)
            return;

        float currentScale = transform.localScale.x;

        Vector3 shoulderOffset = thirdPersonFollow.ShoulderOffset;

        if (currentScale > scaleThreshold)
        {
            shoulderOffset.z = zoomedZOffset;
            shoulderOffset.y = 1.5f; // Apply Y offset when zoomed in
        }
        else
        {
            shoulderOffset.z = normalZOffset;
            shoulderOffset.y = 0f; // Reset Y offset when not zoomed in
        }

        thirdPersonFollow.ShoulderOffset = shoulderOffset;
    }
}