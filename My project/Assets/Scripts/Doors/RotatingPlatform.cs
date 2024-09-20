using System.Collections;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float rotationAngle = 90f; // Угол вращения
    public float rotationDuration = 1f; // Длительность вращения
    public float interval = 5f; // Интервал между вращениями

    private bool isRotating = false;

    void Start()
    {
        InvokeRepeating("StartRotation", interval, interval);
    }

    void StartRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotatePlatform());
        }
    }

    IEnumerator RotatePlatform()
    {
        isRotating = true;

        float elapsedTime = 0f;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, rotationAngle, 0);

        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        isRotating = false;
    }
}
