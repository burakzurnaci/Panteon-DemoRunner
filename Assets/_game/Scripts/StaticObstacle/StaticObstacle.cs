using _game.Scripts.InteractionSystem;
using _game.Scripts.Manager;
using _game.Scripts.Player;
using UnityEngine;

namespace _game.Scripts.StaticObstacle
{
    public class StaticObstacle : MonoBehaviour,IInteractor,IAıInteractor
    {
        public void OnInteracted(Interactor interactor)
        {
            interactor.GetComponentInParent<PlayerController>().transform.localRotation = Quaternion.Euler(0,0,0);
            interactor.GetComponentInParent<PlayerController>().transform.position = LevelManager.Instance.GetSpawnpoint().position;
        }

        public void OnInteracted(AıInteractor interactor)
        {
            interactor.GetComponentInParent<Bot>().transform.localRotation = Quaternion.Euler(0,0,0);
            interactor.GetComponentInParent<Bot>().transform.position = LevelManager.Instance.GetSpawnpoint().position;
        }
    }
}
