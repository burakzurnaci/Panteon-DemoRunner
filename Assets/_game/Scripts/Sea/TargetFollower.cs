using System;
using UnityEngine;

namespace _game.Scripts.Sea
{
    public class TargetFollower : MonoBehaviour
    {
        // Start is called before the first frame update
        [Flags]
        public enum FollowAxis
        {
            None = 0,
            X = 1,
            Y = 2,
            Z = 4,
            All = 7
        }
        
        public Transform target;
        public FollowAxis axis;

        public bool UseFixedUpdate;

        private void Update()
        {
            if(UseFixedUpdate) return;

            Follow();
        }

        private void FixedUpdate()
        {
            if(! UseFixedUpdate) return;
            
            Follow();
        }

        private void Follow()
        {
            var targetPosition = target.position;
            var newPosition = transform.position;
            if ((axis & FollowAxis.X) == FollowAxis.X) newPosition.x = targetPosition.x;
            if ((axis & FollowAxis.Y) == FollowAxis.Y) newPosition.y = targetPosition.y;
            if ((axis & FollowAxis.Z) == FollowAxis.Z) newPosition.z = targetPosition.z+65;
            transform.position = newPosition;
        }
    }
}
