using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Имя сцены, на которую нужно перейти
    public string sceneName;

    // Метод для смены сцены
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    // Метод, вызываемый при столкновении с триггером
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что столкновение произошло с игроком
        if (other.CompareTag("Player"))
        {
            ChangeScene();
        }
    }
}
