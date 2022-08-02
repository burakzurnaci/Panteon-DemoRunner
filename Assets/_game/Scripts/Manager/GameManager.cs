using UnityEngine;
using UnityEngine.Serialization;

namespace _game.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance;

        public delegate void LevelEvent();
        public static LevelEvent OnLevelStarted;
        public static LevelEvent OnLevelEnd;
        public static LevelEvent OnLevelDraw;
        public static LevelEvent OnLevelWin;
        public GameStates states;
        
        public enum GameStates
        {
            NotStarted,
            Started,
            Draw,
            Lose,
            Wın,
        }
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        public void StartLevel()
        {
            states = GameStates.Started;
            OnLevelStarted?.Invoke();
        }
        public void LevelLose()
        {
            states = GameStates.Lose;
            OnLevelEnd?.Invoke();
        }
        
        public void LevelDraw()
        {
            states = GameStates.Draw;
            OnLevelDraw?.Invoke();
        }

        public void LevelWin()
        {
            states = GameStates.Wın;
            OnLevelWin?.Invoke();
        }

    }
}
