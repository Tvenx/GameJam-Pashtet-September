using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timer;
    [SerializeField] private float _maxTime;
    [SerializeField] private string _nextScene;

    //[SerializeField] private AudioSource _signal;

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
        _timer.text = _time.ToString();
        _Time -= Time.deltaTime;

        _Time = ((int)(_time * 100)) / 100f;

        if (_Time == 0)
        {
            SceneManager.LoadScene(_nextScene);
        }
    }
}
