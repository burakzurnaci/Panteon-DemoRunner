using System;
using TMPro;
using UnityEngine;
namespace _game.Scripts.Manager
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        public TextMeshProUGUI _rank;
        public GameObject _play;
        public GameObject _win;
        public GameObject _lose;
        private void Awake()
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
        private void OnEnable()
        {
            GameManager.OnLevelStarted += GameStart;

        }

        private void GameStart()
        {
            _play.SetActive(false);
        }
    }
}