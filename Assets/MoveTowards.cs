using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveTowards : MonoBehaviour {

	public Transform[] patrolPoints;
	public float patrolChangeDistance = 0.5f;
	private  Vector2 target ;
	private int pointIndex; 

	//private RaycastHit2D raycast;

	public float patrolTime = 10.0f;
	public float remainingPatrolTime;
	private float remainingDistance;
	//public  GameObject position1;
	//public float speed =1 ;

	public void Start (){
	
		pointIndex = 0;
		remainingPatrolTime = patrolTime;


	}


	void Update () 
	{
		//target = transform.position;
		//target.z = transform.position.z;
		//transform.position = Vector3.MoveTowards(transform.position, target, speed  * Time.deltaTime);
		Vector2 enemyVector = new Vector2 (transform.position.x, transform.position.y);
		remainingDistance = (enemyVector - target).magnitude;
		//RaycastHit2D hit = Physics2D.Raycast(enemyVector, target);
		//Debug.Log ("DISTANCIA: " + remainingDistance);
		//remainingPatrolTime -= Time.deltaTime;

		if (remainingDistance <=  patrolChangeDistance) {

			PatrolTo ((pointIndex +1) % patrolPoints.Length );

			} else {
			
				target = new Vector2 (patrolPoints [pointIndex].position.x, patrolPoints [pointIndex].position.y);
				transform.position = Vector2.MoveTowards (transform.position, target, 3 * Time.deltaTime);
				//drawLine (enemyVector, target, Color.yellow);
				//Debug.DrawLine(enemyVector, target, Color.yellow,10.0f);
				
			}

	}




	public void PatrolTo (int newPointIndex){

		pointIndex = newPointIndex;
		target = new Vector2 (patrolPoints [pointIndex].position.x, patrolPoints [pointIndex].position.y);
		transform.position = Vector2.MoveTowards (transform.position, target, 3 * Time.deltaTime);
		
	}



}
