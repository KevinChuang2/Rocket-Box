using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour {

	[SerializeField]
	private int playerIndex = 0;
	public int PlayerIndex {
		get { return playerIndex; }
		set {
			if(value < 0 || value > 1) {
				Debug.LogError("Can only have 2 players. Index " + value + " is invalid.");
			}
			else {
				playerIndex = value;
				RecalculateName();
			}
		}
	}

	[SerializeField]
	private bool useController = false;
	public bool UseController {
		get { return useController; }
		set {
			useController = value;
			RecalculateName();
		}
	}

	private string controlPrefix = "";

	#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
	private string osPostfix = "-OSX";
	#else
	private string osPostfix = "";
	#endif

	void Start() {
		RecalculateName();
	}

	public float GetAxis(string axis) {
		return Input.GetAxis(controlPrefix + axis);
	}

	public float GetAxisRaw(string axis) {
		return Input.GetAxis(controlPrefix + axis);
	}

	public float GetAxisLook(string lookAxis) {
		return Input.GetAxis(controlPrefix + lookAxis + osPostfix);
	}

	public float GetAxisLookRaw(string lookAxis) {
		return Input.GetAxisRaw(controlPrefix + lookAxis + osPostfix);
	}

	public bool GetButton(string button) {
		return Input.GetButton(controlPrefix + button + osPostfix);
	}

	public bool GetButtonDown(string button) {
		return Input.GetButtonDown(controlPrefix + button + osPostfix);
	}

	public bool GetButtonUp(string button) {
		return Input.GetButtonUp(controlPrefix + button + osPostfix);
	}

	void RecalculateName() {
		int controlIndex = playerIndex + 1;
		if(useController) {
			controlPrefix = "Controller" + controlIndex;
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
			osPostfix = "-OSX";
#else
            osPostfix = "";
			#endif
		}
		else {
			controlPrefix = "Keyboard";
			osPostfix = "";
		}
	}
}
