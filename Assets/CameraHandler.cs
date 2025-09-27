using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform targetTransform;
    public Transform cameraTransform;
    public Transform cameraPivotTransform;
    private Transform myTransform;
    private Vector3 cameraTransformPosition;
    private LayerMask ignoreLayers;

    public static CameraHandler singleton;
    public float lookSpeed = 0.1f;
    public float followSpeed = 0.01f;
    public float pivotSpeed = 0.03f;

    private float defaultPosition;
    private float lookAngle;
    private float pivotAngle;
    public float minimumPivot = -35;
    public float maximumPivot = 35;

    private void Awake()
    {
        singleton = this;
        myTransform = transform;
        defaultPosition = cameraTransform.localPosition.z;

        ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10);

    }

    public void FollowTarget(float delta)
    {
        Vector3 targetPosition = Vector3.Lerp(myTransform.position, targetTransform.position, delta / followSpeed);
        myTransform.position = targetPosition;
    }

    public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
    {
        lookAngle += (mouseXInput * lookSpeed) / delta;
        pivotAngle -= (mouseYInput * pivotSpeed) / delta;
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        myTransform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;

        targetRotation = Quaternion.Euler(rotation);
        cameraPivotTransform.localRotation = targetRotation;

        // if (Physics.Raycast(targetTransform.position, cameraTransform.position - targetTransform.position, out RaycastHit hit, Mathf.Abs(defaultPosition), ignoreLayers))
        // {
        //     float distance = Vector3.Distance(targetTransform.position, hit.point);
        //     cameraTransformPosition.z = -(distance - 0.2f);
        // }
        // else
        // {
        //     cameraTransformPosition.z = defaultPosition;
        // }

        // cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, cameraTransformPosition, delta / 0.01f);
    }
}
