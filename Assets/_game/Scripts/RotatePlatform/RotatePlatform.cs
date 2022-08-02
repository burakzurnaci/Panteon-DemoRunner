using UnityEngine;

namespace _game.Scripts.RotatePlatform
{
   public class RotatePlatform : MonoBehaviour
   {
      private Rigidbody _rb;

      [SerializeField] private float rotationSpeed;

      private const int DragConst = 100;

      private void Start()
      {
         _rb = GetComponent<Rigidbody>();
         _rb.AddTorque(transform.forward * rotationSpeed * 1000 * DragConst);
      }
   
      void FixedUpdate()
      {
         _rb.AddTorque(transform.forward * rotationSpeed * DragConst);
      }

    
      
      
   }
}
