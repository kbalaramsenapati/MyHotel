using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Room
{
	public Transform sleepAnchor;
	[SerializeField] private GameObject LightOff;
	protected override void NpcInteracated(NPC npc)
	{
		if (npc.CurrentState == NPC.States.BEING_CUSTOMER)
		{
			this.npc = npc;
			SleepNpc(npc);
		}
	}
	protected override void NpcStoppedInteracting(NPC npc)
	{
		this.npc = null;
	}
	private void SleepNpc(NPC npc)
	{
		//sleepyParticles.Play();
		LightOff.SetActive(true);
		npc.FallAsleep(sleepAnchor);
		const float SLEEP_TIME = 15f;
		//Invoke(nameof(WakeNpc), SLEEP_TIME);
	}
}
