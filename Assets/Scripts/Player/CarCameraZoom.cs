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
    public float largeZoomedZOffset = -7f;
    public float largeScaleThreshold = 0.1f;

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

        // Highest threshold first
        if (currentScale > largeScaleThreshold)
        {
            shoulderOffset.z = largeZoomedZOffset;
            shoulderOffset.y = 2.5f;
        }
        else if (currentScale > scaleThreshold)
        {
            shoulderOffset.z = zoomedZOffset;
            shoulderOffset.y = 1.5f;
        }
        else
        {
            shoulderOffset.z = normalZOffset;
            shoulderOffset.y = 0f;
        }

        thirdPersonFollow.ShoulderOffset = shoulderOffset;
    }
}