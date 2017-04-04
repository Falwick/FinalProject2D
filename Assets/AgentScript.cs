using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AgentScript : MonoBehaviour 

{

	private NavMeshAgent agent;

	void Start (){

		agent = GetComponent<NavMeshAgent>();
	}

	void Update  () {
	
		if (Input.GetMouseButton (0)) {
		
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {

				if (hit.collider.tag == "Ground") {

					agent.SetDestination (hit.point);
				}
			}
		}

	}
		/*public Transform[] patrolPoints;	
		protected int pointIndex;
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
