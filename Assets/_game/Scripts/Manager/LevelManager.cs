using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace _game.Scripts.Manager
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;
        [SerializeField] private Transform spawnpoint;
        [SerializeField] private GameObject environment;
        [SerializeField] private GameObject aI;
        [SerializeField] private GameObject paintWall;
        [SerializeField] private GameObject player;
        [SerializeField] private List<GameObject> Racers;
        private int _rank;
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

        public Transform GetSpawnpoint()
        {
            return spawnpoint;
        }
        
        public void DrawSection()
        {
            environment.SetActive(false);
            aI.SetActive(false);
            paintWall.SetActive(true);
            player.SetActive(false);
        }

        private void Update()
        {
            if (GameManager.Instance.states == GameManager.GameStates.Wın)
            {
                UIManager.Instance._win.SetActive(true);
            }
            if (GameManager.Instance.states == GameManager.GameStates.Lose)
            {
                UIManager.Instance._lose.SetActive(true);
            }
            Rank();
        }

        private void Rank()
        {
            _rank = 1;
            for (int i = 1; i < Racers.Count; i++)
            {
                if (Racers[0].transform.position.z < Racers[i].transform.position.z)
                {
                    _rank++;

                }
            }
            UIManager.Instance._rank.SetText(_rank.ToString());
        }

        public void ResetGame()
        {
            GameManager.Instance.states = GameManager.GameStates.NotStarted;
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
        }
    }
    
    
}