using UnityEngine;

public class Projectile : MonoBehaviour
{
	private const float OFFSET_CHECK_POSITION = 0.3f;
	private const float OFFSET_Y_POSITION = 0.5f;
	private Unit target;
	private float speed;
	protected float damage;

	public void Init(Unit target, float speed, float damage)
	{
		this.target = target;
		this.speed = speed;
		this.damage = damage;
	}

	private void Update()
	{
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}
		Move();
		if (CheckPosition())
		{
			Attack();
		}
	}

	private void Attack()
	{
		target.TakeDamage(damage);
		Destroy(gameObject);
	}

	private void Move()
	{
		Vector3 position = TargetPosition();
		Vector3 direction = position - transform.position;
		Vector3 moveStep = direction.normalized * speed * Time.deltaTime;
		Vector3 add = moveStep;
		if (direction.magnitude < moveStep.magnitude)
		{
			add = direction;
		}
		transform.position += add;
	}

	private bool CheckPosition()
	{
		Vector3 position = TargetPosition();
		bool onPosition = Vector3.Distance(position, transform.position) < OFFSET_CHECK_POSITION;
		return onPosition;
	}

	private Vector3 TargetPosition()
	{
		return target.transform.position + new Vector3(0, OFFSET_Y_POSITION, 0);
	}
}
