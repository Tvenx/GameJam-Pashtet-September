using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform target;
    [SerializeField] private int _xPosition;
    [SerializeField] private int _yPosition;
    [SerializeField] private int _zPosition;

    private void Update()
    {
        Vector3 position = target.position;
        position.z = target.transform.position.z + _zPosition;
        position.y = target.transform.position.y + _yPosition;
        position.x = target.transform.position.x + _xPosition;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
