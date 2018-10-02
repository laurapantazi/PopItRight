using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {
	
	// καλειται πριν την Start
	void Awake () {
		//η μέθοδος αυτή δεν καταστρέφει το συγκεκριμένο αντικείμενο καθως φορτώνουμε νέο scene
		//στην συγκεκριμενη περίπτωση ο κώδικας αυτός καλείται από ένα empty game object που περιέχει τον background ήχο
		DontDestroyOnLoad (gameObject);
	}
}
