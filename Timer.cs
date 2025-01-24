using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    public event Action<int> CountChange;

    private float _count = 0f;
    private bool _isRunning;
    private Coroutine _corutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseButtonDown();
        }
    }

    private void HandleMouseButtonDown()
    {
        if (_isRunning == false)
        {
            _isRunning = true;
            _corutine = StartCoroutine(ProcessTimer());
        }
        else
        {
            if (_corutine != null)
            {
                StopCoroutine(_corutine);
                _isRunning = false;
            }
        }
    }

    private IEnumerator ProcessTimer()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (true)
        {
            Debug.Log("Корутина воркает");
            _count++;
            CountChange?.Invoke((int)_count);
            yield return waitForSeconds;
        }
    }
}
