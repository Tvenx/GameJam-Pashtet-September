using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // ��� �����, �� ������� ����� �������
    public string sceneName;

    // ����� ��� ����� �����
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    // �����, ���������� ��� ������������ � ���������
    private void OnTriggerEnter(Collider other)
    {
        // ���������, ��� ������������ ��������� � �������
        if (other.CompareTag("Player"))
        {
            ChangeScene();
        }
    }
}
