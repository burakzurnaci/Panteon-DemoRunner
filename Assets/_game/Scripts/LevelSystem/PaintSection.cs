using _game.Scripts.AıBotsSystem;
using _game.Scripts.InteractionSystem;
using _game.Scripts.Manager;
using UnityEngine;

namespace _game.Scripts.LevelSystem
{
    public class PaintSection : MonoBehaviour,IInteractor,IAıInteractor
    {
        [SerializeField] private int aiNumber = 0;
        public void OnInteracted(Interactor interactor)
        {
            GameManager.Instance.LevelDraw();
        }
        
        public void OnInteracted(AıInteractor interactor)
        {
            aiNumber++;
            interactor.transform.parent.GetComponentInParent<BotState>().bot.isActive = false;
            if (aiNumber >= 4)
            {
                interactor.transform.parent.GetComponentInParent<BotState>().bot.isActive = false;
                GameManager.Instance.LevelLose();
            }
            else
            {
                interactor.transform.parent.GetComponentInParent<BotState>().bot.isActive = false;
            }
        }
    }
}
