using _game.Scripts.AıBotsSystem;
using _game.Scripts.InteractionSystem;
using UnityEngine;

namespace _game.Scripts.RotatePlatform
{
    public class RotateAi : MonoBehaviour,IAıInteractor
    {
        // Start is called before the first frame update



        public void OnInteracted(AıInteractor interactor)
        {
            interactor.GetComponentInParent<BotState>().transform.rotation =Quaternion.Euler( 0, transform.rotation.y, 0);
            interactor.GetComponentInParent<BotState>().Rotating();
        }
    }
}
