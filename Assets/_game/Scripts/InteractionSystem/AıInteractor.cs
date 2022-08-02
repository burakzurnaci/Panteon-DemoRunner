using _game.Scripts.Manager;
using UnityEngine;


namespace _game.Scripts.InteractionSystem
{
    public class AıInteractor : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(GameManager.Instance.states != GameManager.GameStates.Started) return;
            var isInteractable = other.TryGetComponent<IAıInteractor>(out var interactable);
            if (isInteractable) interactable.OnInteracted(this);
        }
    }
}
