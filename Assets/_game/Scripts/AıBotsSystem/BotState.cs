using System.Collections.Generic;
using System.Linq;
using _game.Scripts.Manager;
using UnityEngine;

namespace _game.Scripts.AıBotsSystem
{
	public class BotState : MonoBehaviour
	{
		public Bot bot;
		private Rigidbody _rb;
		private List<PathHolder> _paths;
		private Animator _anim;
		
		[SerializeField] private float speed;
		[SerializeField] private float rotationSpeed;
		[SerializeField] private float gravity;
		[HideInInspector] public int botPathState = 0;
		private static readonly int IsRun = Animator.StringToHash("Run");
		private static readonly int IsIdle = Animator.StringToHash("Idle");
		// Start is called before the first frame update
		void Start()
		{
			speed = Random.Range(4, 6);
			rotationSpeed = Random.Range(100, 180);
			_rb = GetComponent<Rigidbody>();
			bot = GetComponent<Bot>();
			_anim = GetComponentInChildren<Animator>();
			_paths = transform.parent.GetComponentsInChildren<PathHolder>().ToList();
			
		}
		private void OnEnable()
		{
			GameManager.OnLevelStarted += SetRun;
			GameManager.OnLevelEnd += SetIdle;
		}
		private void OnDisable()
		{
			GameManager.OnLevelStarted -= SetRun;
			GameManager.OnLevelEnd -= SetIdle;
		}
		// Update is called once per frame
		private void FixedUpdate()
		{
			if (GameManager.Instance.states == GameManager.GameStates.Started)
			{
				if (!isGrounded()) _rb.AddForce(-transform.up * gravity, ForceMode.Impulse);
				if (botPathState > 13) botPathState = 13;

				var path = GetClosestPath(_paths[botPathState]);
				var targetPoint = RandomPointInBounds(path.GetComponent<Collider>().bounds);

				var target = new Vector3(targetPoint.x - _rb.transform.position.x,
					0,
					targetPoint.z - _rb.transform.position.z);
				var targetAngle = Quaternion.LookRotation(target);
				
				_rb.MoveRotation(Quaternion.RotateTowards(_rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime));
				_rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
			}

		}
		private Vector3 RandomPointInBounds(Bounds bounds)
		{
			return new Vector3(
				Random.Range(bounds.min.x, bounds.max.x),
				Random.Range(bounds.min.y, bounds.max.y),
				Random.Range(bounds.min.z, bounds.max.z)
			);
		}

		public void Rotating()
		{
			speed = 11;
		}
		void SetRun()
		{
			_anim.SetTrigger(IsRun);
		}
		void SetIdle()
		{
			_anim.SetTrigger(IsIdle);
		}
		public void AnimationToRun()
		{
			if (GameManager.Instance.states == GameManager.GameStates.Started)
			{
				_anim.SetTrigger(IsRun);
			}
			
		}
		Path GetClosestPath(PathHolder holder)
		{
			float bestDistance = Mathf.Infinity;
			Path bestPath = null;

			foreach (var path in holder.paths)
			{
				float distance = Vector3.Distance(transform.position, path.transform.position);

				if (distance < bestDistance)
				{
					bestDistance = distance;
					bestPath = path;
				}
			}

			return bestPath;
		}

		bool isGrounded()
		{
			var hit = Physics.Raycast(GetComponent<Collider>().bounds.center, Vector3.down, GetComponent<Collider>().bounds.extents.y + 0.5f, LayerMask.GetMask("Ground"));

			return hit;
		}
	}
}
