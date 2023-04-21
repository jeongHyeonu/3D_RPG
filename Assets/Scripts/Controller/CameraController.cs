using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Transform cameraTrarnsform;
    public Vector3 offset;

    private void Awake()
    {
        cameraTrarnsform = GetComponent<Transform>();
    }

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = playerTransform.position - cameraTrarnsform.position;
    }

    private void LateUpdate()
    {
        cameraTrarnsform.position = Vector3.Lerp(cameraTrarnsform.position, playerTransform.position - offset, Time.deltaTime);
    }
}
