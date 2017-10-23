using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class GameManager : MonoBehaviour {
    
    public float pointModifier = 1.0f;
    public Text txtPoints;
    private int currentPoints;
    private int highScore = 0;
    public delegate void PlayerEvents(int pointsToGive);
    public static event PlayerEvents EarnedPoints;



    #region Singleton
    private static GameManager instance = null;
    public static GameManager Instance {
        get { return instance; }
    }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        EarnedPoints += GivePoints;
        txtPoints.text = currentPoints.ToString();
    }
        #endregion
        private void OnEnable() {

        //Debug.Log(Instance.gameObject.name);
 
    }
    public void delPointsEarned(int pointsToGive) {
        EarnedPoints(pointsToGive);
    }

    public void GivePoints(int pointsToGive) {
        currentPoints += pointsToGive;
        txtPoints.text = currentPoints.ToString();
    }

    public void NewHighScore(int score) {
        highScore = score;
        //TODO: make some sort of visuals and update the visual display
    }

    
}
