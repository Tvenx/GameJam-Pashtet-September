using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 moveDistance = new Vector3(0, 0, 10f); // Расстояние перемещения
    public float moveDuration = 2f; // Длительность перемещения
    public float interval = 5f; // Интервал между перемещениями
    public float stopDuration = 1f; // Длительность остановки в крайних точках

    private bool isMoving = false;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        InvokeRepeating("StartMovement", interval, interval + 2 * stopDuration + 2 * moveDuration);
    }

    void StartMovement()
    {
        if (!isMoving)
        {
            StartCoroutine(MovePlatform());
        }
    }

    IEnumerator MovePlatform()
    {
        isMoving = true;
        Vector3 endPosition = startPosition + moveDistance;

        // Перемещение к конечной точке
        yield return MoveToPosition(endPosition);

        // Остановка в конечной точке
        yield return new WaitForSeconds(stopDuration);

        // Перемещение обратно к начальной точке
        yield return MoveToPosition(startPosition);

        // Остановка в начальной точке
        yield return new WaitForSeconds(stopDuration);

        isMoving = false;
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = transform.position;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
