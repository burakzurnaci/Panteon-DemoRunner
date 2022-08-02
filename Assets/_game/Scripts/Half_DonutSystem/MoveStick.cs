using _game.Scripts.InteractionSystem;
using DG.Tweening;
using UnityEngine;

namespace _game.Scripts.Half_DonutSystem
{
    public class MoveStick : MonoBehaviour,IInteractor
    {
        private float Force = 20;
        private float radius = 10;
        private float upForce = 0;
        [SerializeField] public float Rotation;
        // Start is called before the first frame update
        void Start()
        {
            transform.DOLocalMoveX(Rotation, 3f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetDelay(3)
                .SetEase(Ease.InOutSine);
        }
         //bekleme koyulcak 1 saniye
        public void OnInteracted(Interactor interactor)
        {
            interactor.GetComponentInParent<Rigidbody>().AddExplosionForce(Force,transform.position,radius,upForce,ForceMode.Impulse);
        }
    }
}
