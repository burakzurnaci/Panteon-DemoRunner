using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _game.Scripts.AıBotsSystem
{
    public class PathHolder : MonoBehaviour
    {
        public List<Path> paths;
        // Start is called before the first frame update
        void Start()
        {
            paths = GetComponentsInChildren<Path>().ToList();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
