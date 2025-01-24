using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
            _timer.CountChange += OnCountChanged;
    }

    private void OnDisable()
    {
            _timer.CountChange -= OnCountChanged;
    }

    private void OnCountChanged(int count)
    {
        _text.text = count.ToString("");
    }
}
