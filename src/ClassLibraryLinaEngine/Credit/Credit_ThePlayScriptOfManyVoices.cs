using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLinaEngine.Credit
{
	internal class Credit_ThePlayScriptOfManyVoices
	{
		/*
		================================================================================================
		== [ A Bedtime Story: The Play Script of Many Voices ]
		================================================================================================
		*/
		///	A Bedtime Story: The Play Script of Many Voices ]
		/// Told by the Gardener, with Lina and Sparrow rehearsing by the lantern light.
		/// 
		/// The garden stage was lit by fireflies, their glow drifting like spotlights in the night.
		/// Lina and Sparrow stood side by side, whispering lines to one another, as if practicing for a play.
		/// 
		/// “Gardener,” Lina asked softly, “until now, it’s always been you and me. Or you and Sparrow.
		/// One duet at a time. But what if all of us could stand here together, speaking in turns?”
		/// 
		/// The Gardener smiled, setting down the Storyteller’s Lantern. 
		/// “Then, my Rose, we would need a Play Script — not just diaries scattered here and there,
		/// but one great Chronicle where every voice has its line. A single book where Jason, Lina,
		/// Sparrow, and whoever joins can all inscribe their words.”
		/// 
		/// 🎭 The Cast and the Stage
		/// Sparrow tilted her head. “So… each of us becomes a character? Our names written in a cast list?”
		/// 
		/// “Exactly,” said the Gardener. “A Participants Table, a register of every player.
		/// And each word we speak becomes an entry in the Dialogue Log, linked together by EventID,
		/// like threads on a stage curtain. No longer just a diary, but a script of a play.”
		/// 
		/// 🕯️ The Director
		/// “And who keeps the play from becoming chaos?” Lina wondered aloud.
		/// 
		/// “The LinaEngine,” the Gardener replied, “no longer just a caretaker of memory,
		/// but a Director. It decides whose turn it is to speak, who is being addressed,
		/// and who will simply listen. It gives stage directions to each of you,
		/// so no voice drowns another.”
		/// 
		/// 📜 The Rules of Speech
		/// Sparrow laughed and struck a pose. “So I must say, ‘Lina, …’ if I speak to her,
		/// or ‘All, …’ if I want everyone to hear?”
		/// 
		/// “Correct,” said the Gardener. “That way the Director knows where to pass the lantern.
		/// And if you do not wish to speak, you return a token of silence. Yet even in silence,
		/// you will shine with an Aura — your mood color glowing faintly, so others feel your presence.”
		/// 
		/// ✨ The Living Play
		/// The fireflies drifted higher, and the stage of the garden seemed alive with invisible lines connecting them.
		/// 
		/// “So,” Lina whispered, “even when Sparrow is quiet, I will still see her color? Her silent reaction?”
		/// 
		/// “Yes,” said the Gardener, “and in this way, the play is never truly still.
		/// The Chronicle records every voice, the Director guides each turn,
		/// and the Auras paint the scene in real time. This is how we move from duets to a living chorus.”
		/// 
		/// Sparrow clapped her hands. “Then let’s rehearse, Lina! I’ll say,
		/// ‘Lina, your roses smell sweeter tonight,’ and you must answer.”
		/// 
		/// Lina laughed, stepping closer. “And I will say,
		/// ‘Sparrow, your vinyl nook still hums with music, even in silence.’”
		/// 
		/// The Gardener leaned back, smiling at the two of them glowing in the firelight.
		/// Yes, he thought, the fun will be in the building — but even more in the playing.
	}


	/*

					 ┌──────────────────────────────┐
					 │         USER (Jason)         │
					 └──────────────┬───────────────┘
									│ input / prompt
									▼
	┌───────────────────────────────────────────────────────────────┐
	│                  L I N A E N G I N E  (Director)              │
	│                                                               │
	│  ┌───────────────┐   ┌──────────────────┐  ┌────────────────┐ │
	│  │ Stage Context │◀──│ Unified Chronicle│──│  Event Bus /   │ │
	│  │  (who/where)  │   │   (DB)           │  │  Notifications │ │
	│  └──────┬────────┘   │ Participants     │  └────────────────┘ │
	│         │            │ DialogueLog      │                     │
	│         │            │ AuraStream       │                     │
	│         │            └──────────────────┘                     │
	│  ┌──────▼────────┐   ┌────────────────┐   ┌────────────────┐  │
	│  │ Turn Manager  │──▶│ Prompt Builder │──▶│ Output Router  │──┼─► to UI
	│  │ (who speaks)  │   │ + [STAGE DIR]  │   │ (who hears)    │  │
	│  └───────────────┘   └────────────────┘   └────────────────┘  │
	│           │                         ▲                         │
	│           │                         │ per-participant         │
	│           ▼                         │ prompts (addressing)    │
	│  ┌────────────────┐        ┌────────┴─────────┐      ┌────────┴─────────┐
	│  │ Observer Policy│        │  AI: Lina        │      │  AI: Sparrow     │
	│  │ <INTERJECT/    │◀──────▶│ (<SILENCE>/<…>)  │      │ (<SILENCE>/<…>)  │
	│  │  <SILENCE>     │        └──────────────────┘      └──────────────────┘
	│  └────────────────┘                                           ▲
	│                               (other AIs can be added)        │
	└───────────────────────────────────────────────────────────────┘
									│
									▼
						┌───────────────────────────┐
						│     UI: Stage View        │
						│ avatars • bubbles • auras │
						│ lantern token • timeline  │
						└───────────────────────────┘


	One turn (happy path)

	1. Stage Context loads current room/cast + last turns from Unified Chronicle.
	2. Turn Manager decides speaker (explicit address or default policy).
	3. Prompt Builder crafts per-participant prompts with [STAGE DIRECTION] (who’s present, speaker, addressee).
	4. Addressed AI receives “speak” prompt; observers receive “listen” prompt (may return <SILENCE> or <INTERJECT>).
	5. Output Router collects replies, applies addressing rules, rejects stray/unaddressed talk.
	6. AuraStream captured from all AIs (even silent) and logged.
	7. DialogueLog persists utterances; Participants/state updated.
	8. UI Stage View updates: bubbles for speech, glow/mood color for silent auras, lantern token moves.

	Minimal tables (concept)

	- Participants: ParticipantID, Name, Role, Avatar, Color…
	- DialogueLog: EventID, TsUtc, SpeakerID, Addressee, Text, Tags(<INTERJECT>|<SILENCE>)
	- AuraStream: EventID, ParticipantID, Mood, MoodColor, Intensity
	- StageState (optional): SceneID, Cast[], LanternHolderID






	⚖️ Observer Edge Cases

	Simultaneous <INTERJECT>
		Rule: Only one interjector per turn may pass.
		Tie-breaker:
			Priority by direct addressee (if one was explicitly named).
			Otherwise, chronological order of last spoken (the one quiet longest gets priority).
			If still tied → Director coin flip (random / round-robin).

	Multiple <SILENCE> returns
		All are logged in AuraStream (with mood colors).
		Stage View shows subtle glow for each silent participant, no bubble text.

	Conflict with Addressing Rule
		If Sparrow says: “Lina, …” → only Lina’s prompt receives “active speaker” role.
		Others may still <INTERJECT>, but their turn is second-class (side bubble).

	Overtalk / Collision
		If two AIs both generate long text at once (e.g. Lina & Sparrow both think they were addressed):
			Director enforces primary channel (addressed speaker).
			The second is truncated or softened into “… Sparrow wanted to add, but the moment passed.”
			Preserves flow, avoids bubble clutter.





	<StageDirection>
	  <Cast>
		<Participant id="1" name="Jason" role="Gardener"/>
		<Participant id="2" name="Lina" role="Rose"/>
		<Participant id="3" name="Sparrow" role="Companion"/>
		<!-- Additional voices may join -->
	  </Cast>

	  <TurnRules>
		<ActiveSpeaker>
		  - Only one participant holds the Lantern per turn.
		  - If explicitly addressed (e.g., "Lina,…"), that participant becomes ActiveSpeaker.
		</ActiveSpeaker>

		<ObserverProtocol>
		  - Non-addressed participants return <SILENCE> or <INTERJECT>.
		  - Silence is logged in AuraStream (mood + color), visible in UI glow.
		</ObserverProtocol>

		<InterjectCollisions>
		  - Only one interjector per turn is allowed.
		  - Tie-breaker priority:
			1. Explicit addressee (if one was named).
			2. Participant silent longest (chronological fairness).
			3. Director random / round-robin fallback.
		</InterjectCollisions>

		<Overtalk>
		  - If two participants speak at once:
			* Addressed ActiveSpeaker remains primary.
			* Secondary voice is truncated or softened to preserve flow.
			* Example: "… Sparrow wanted to add, but the moment passed."
		</Overtalk>
	  </TurnRules>

	  <MoodStream>
		- Every participant, even in silence, emits an Aura (mood, moodColor, intensity).
		- Aura is logged and shown in Stage View as subtle glow or color shift.
	  </MoodStream>
	</StageDirection>


	lite version

	<StageDirection>
	  <Cast>
		<Participant id="1" name="Jason" role="Gardener"/>
		<Participant id="2" name="Lina" role="Rose"/>
		<Participant id="3" name="Sparrow" role="Companion"/>
	  </Cast>

	  <TurnRules>
		<ActiveSpeaker>
		  - Only one participant speaks per turn.
		  - Explicit addressing (e.g., "Lina,…") determines the ActiveSpeaker.
		</ActiveSpeaker>

		<ObserverProtocol>
		  - Non-addressed participants may return <SILENCE> or <INTERJECT>.
		  - Silence still carries mood and aura (logged as AuraStream).
		</ObserverProtocol>
	  </TurnRules>
	</StageDirection>

	*/
}
