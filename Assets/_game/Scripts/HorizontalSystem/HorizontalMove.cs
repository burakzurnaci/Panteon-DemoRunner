using System.Drawing;
using _game.Scripts.InteractionSystem;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace _game.Scripts.HorizontalSystem
{
    public class HorizontalMove : MonoBehaviour,IInteractor,IAıInteractor
    { 
        [SerializeField] protected float spaceRotation = 9;
        private float Force = 10;
        private float radius = 10;
        private float upForce = 0;
        // Start is called before the first frame update
        void Start()
        {
            transform.DOMoveX(spaceRotation, 2.0f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }
        public void OnInteracted(Interactor interactor)
        {
            interactor.GetComponentInParent<Rigidbody>().AddExplosionForce(Force,transform.position,radius,upForce,ForceMode.Impulse);
        }

        public void OnInteracted(AıInteractor interactor)
        {
            interactor.GetComponentInParent<Rigidbody>().AddExplosionForce(Force,transform.position,radius,upForce,ForceMode.Impulse);
        }
    }
}
