using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueEventInfo {
	public ResourceType targetResource;
	public float damagePerSec;
	public string rogueEventWarningMsg;


	public RogueEventInfo (ResourceType r, float dmg, string warningMsg) {
		this.targetResource = r;
		this.damagePerSec = dmg;
		this.rogueEventWarningMsg = warningMsg;
	}
}
