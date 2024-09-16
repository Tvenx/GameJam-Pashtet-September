using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timer;
    [SerializeField] private float _maxTime;
    [SerializeField] private string _nextScene;

    private float _time;
    [SerializeField]
    private float _Time
    {
        get { return _time; }
        set { _time = Mathf.Clamp(value, 0, _maxTime); }
    }

    private void Start()
    {
        _time = _maxTime;
    }

    private void Update()
    {
        // Отображаем время без запятой
        _timer.text = Mathf.Floor(_time).ToString();
        _Time -= Time.deltaTime;

        if (_Time == 0)
        {
            SceneManager.LoadScene(_nextScene);
        }
    }
}
