using _game.Scripts.Manager;
using DG.Tweening;
using UnityEngine;

namespace _game.Scripts.Player
{
   public class PlayerController : MonoBehaviour
   {
      private Rigidbody _rigidbody;
      private InputManager _swerveInp;
      [SerializeField] private float verticalSpeed = 7, horizontalSpeed = 2f;
      private void Awake()
      {
         _rigidbody = GetComponent<Rigidbody>();
         _swerveInp = GetComponent<InputManager>();
      }

      private void FixedUpdate()
      {
         if (GameManager.Instance.states == GameManager.GameStates.Started)
         {
          //  _rigidbody.MovePosition(transform.position + (Vector3.forward*speed*Time.fixedDeltaTime));
            PlayerMovement();
         }
         if (GameManager.Instance.states == GameManager.GameStates.Draw)
         {
            //PAİNT WALL KISMI
         }
      }

      void PlayerMovement()
      {

         var horizontalMove = horizontalSpeed * _swerveInp.MoveFactorX * Time.deltaTime;

         horizontalMove = Mathf.Clamp(horizontalMove, -10f, 10f);
         transform.Translate(horizontalMove,0,verticalSpeed*Time.deltaTime);
         var pos = transform.position;
         pos.x = Mathf.Clamp(pos.x, -15f, 15f);
         transform.position = pos;
      }
   }
}
