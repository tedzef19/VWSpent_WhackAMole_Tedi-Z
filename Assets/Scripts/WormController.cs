using UnityEngine;
using UnityEngine.Events;

public class WormController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float maxHeight = 0.5f;

    private Vector3 startPosition;
    private bool isMovingUp = true;
    private bool isActive = false;

    public UnityEvent onHit;

    private void Start()
    {
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        if (!isActive || GameManager.Instance.currentState != GameManager.GameState.Running) 
            return;

        if (isMovingUp)
        {
            transform.localPosition += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.localPosition.y >= startPosition.y + maxHeight)
                isMovingUp = false;
        }
        else
        {
            transform.localPosition -= Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.localPosition.y <= startPosition.y)
                isMovingUp = true;
        }
    }

    public void ActivateWorm(bool active)
    {
        isActive = active;
        transform.localPosition = startPosition;
    }

    public void Hit()
    {
        if (!isActive) return;

        GameManager.Instance.AddScore(10);
        onHit?.Invoke();

        ActivateWorm(false);
        Invoke("Reactivate", Random.Range(0.5f, 1.5f));
    }

    private void Reactivate()
    {
        if (GameManager.Instance.currentState == GameManager.GameState.Running)
            ActivateWorm(true);
    }
}