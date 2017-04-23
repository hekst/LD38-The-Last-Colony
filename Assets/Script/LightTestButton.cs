using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTestButton : MonoBehaviour {

	public Light warningLight0;
	public ParticleSystem ps;

	public void ToggleWarningLight0 () {
		warningLight0.gameObject.SetActive (!(warningLight0.gameObject.activeSelf));
	}

	public void ToggleParticleLight0 () {
		if (ps.isPlaying) {
			ps.Stop ();
		} else {
			ps.Play ();
		}
	}

}
