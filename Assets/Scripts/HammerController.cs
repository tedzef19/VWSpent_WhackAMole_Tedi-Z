using UnityEngine;


public class HammerController : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    public LayerMask wormLayer;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Worm") && GameManager.Instance.currentState == GameManager.GameState.Running)
        {
            WormController worm = other.GetComponent<WormController>();
            if (worm != null)
            {
                worm.Hit();
                Debug.Log("Hit Worm!");
            }
        }
    }
}