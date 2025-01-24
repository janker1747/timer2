using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private float _count = 0f;
    private bool _isRunning;
    private Coroutine _coroutine;

    public event Action<int> CountChange;

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
            _coroutine = StartCoroutine(ProcessTimer());
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _isRunning = false;
            }
        }
    }

    private IEnumerator ProcessTimer()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (true)
        {
            _count++;
            CountChange?.Invoke((int)_count);
            yield return waitForSeconds;
        }
    }
}