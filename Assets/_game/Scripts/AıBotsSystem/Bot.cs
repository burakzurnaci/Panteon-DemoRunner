using System.Collections;
using System.Collections.Generic;
using _game.Scripts.AıBotsSystem;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [HideInInspector] public BotState state;

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<BotState>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
