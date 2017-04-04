using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshPatroller : MonoBehaviour
{
	public Transform[] patrolPoints;
	public Rigidbody2D rb;

	public void Awake (){
		rb = GetComponent<Rigidbody2D> ();	
	}


	void FixedUpdate() {
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
	}
	/*protected int pointIndex;

	protected NavMeshAgent agent;

	public void Awake ()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	public void Start ()
	{
		pointIndex = 0;
	}

	public void Update ()
	{
		if ( agent.remainingDistance <= 0.0f )
		{
			PatrolTo( (pointIndex + 1) % patrolPoints.Length );
		}
		else
		{
			agent.destination = patrolPoints[pointIndex].position;
		}
	}

	public void PatrolTo( int newPointIndex )
	{
		pointIndex = newPointIndex;
		agent.destination = patrolPoints[pointIndex].position;
	}*/
}