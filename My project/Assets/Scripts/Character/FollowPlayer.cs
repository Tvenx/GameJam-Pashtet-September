using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 position = target.position;
        position.z = target.transform.position.z - 7;
        position.y = target.transform.position.y + 4;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}