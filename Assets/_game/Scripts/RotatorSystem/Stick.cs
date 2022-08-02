using _game.Scripts.InteractionSystem;
using UnityEngine;

namespace _game.Scripts.RotatorSystem
{
    public class Stick : MonoBehaviour,IInteractor,IAıInteractor
    {
        [HideInInspector] public float Force =200;
        [HideInInspector] public float radius=20;
        [HideInInspector] public float upForce = -1;
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
