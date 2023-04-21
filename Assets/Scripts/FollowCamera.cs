using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerTransform;
    public Transform cameraTrarnsform;
    public Vector3 offset;

    private void Start()
    {
        offset = playerTransform.position - cameraTrarnsform.position;
    }

    private void LateUpdate()
    {
        cameraTrarnsform.position = Vector3.Lerp(cameraTrarnsform.position, playerTransform.position-offset, Time.deltaTime);
    }
}
