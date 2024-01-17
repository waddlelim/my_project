using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float lerpSpeed = 0.125f;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 desiredPos = new Vector3(player.position.x, transform.position.y, transform.position.z) + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, lerpSpeed);
        transform.position = smoothedPos;
    }
}
