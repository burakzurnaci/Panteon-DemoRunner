using _game.Scripts.InteractionSystem;
using UnityEngine;

namespace _game.Scripts.AıBotsSystem
{
    public class Path : MonoBehaviour,IAıInteractor
    {
        public void OnInteracted(AıInteractor interactor)
        {
            interactor.GetComponentInParent<BotState>().botPathState++;
        }
    }
}
