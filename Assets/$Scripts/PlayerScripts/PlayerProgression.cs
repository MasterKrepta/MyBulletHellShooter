using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour {
    #region Variables
    private int availableCredits = 0; // FOR testing use player prefs later
    private List<GameObject> availableShips = new List<GameObject>();

    public List<GameObject> AvailableShips = new List<GameObject>();

    #endregion

    private void Start() {
        GameManager.UpdateProgress += UpdateCredits;
    }

    public void UpdateCredits(int creditsEarned) {
        
        availableCredits += creditsEarned;
    }
}
