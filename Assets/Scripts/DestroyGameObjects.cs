using UnityEngine;
using System.Collections;

public class DestroyGameObjects : MonoBehaviour {

	//we attach this script to the gameObjects (Destroyer,DestroyerLeft,DestroyerRight)
	//when another gameobject (balloon gameObjects) collide with this gameobject, this method is being called
	//with parameter ,collision2D of the other gameobject
	//Collision2D contains information by a collision in 2D physics
	void OnCollisionEnter2D(Collision2D other)
	{
		//if the parameter other is not null
		//we call the method Destroy ,in order to destroy/delete the other gameobject
		if(other!=null)
		{
			Destroy (other.gameObject);
		}
	}
}
