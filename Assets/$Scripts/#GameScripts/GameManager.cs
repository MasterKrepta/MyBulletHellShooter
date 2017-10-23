using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public float pointModifier = 1.0f;
    public Text txtPoints;
    private int currentPoints;
    private int highScore = 0;
    public delegate void PlayerEvents();
    public static event PlayerEvents EarnedPoints;
    
    

#region Singleton
    static private GameManager _singleton = null;
    static private GameManager singleton {
        get {
            if (_singleton == null) {
                InstantiateSingleton();
            }
            return _singleton;
        }
    }
    static private void InstantiateSingleton() {
        new GameObject("#GameManager", typeof(GameManager));
    }
    #endregion
    private void Start() {
        EarnedPoints =  GivePoints;
    }
    public void GivePoints() {
        //currentPoints += pointsToGive;
        //Debug.Log(pointsToGive + " added. Current points are: " + currentPoints);
    }

    public void NewHighScore(int score) {
        highScore = score;
        //TODO: make some sort of visuals and update the visual display
    }

    private void OnGUI() {
        if(GUI.Button(new Rect(Screen.width / 2-50,5,100,30), "Click")) {
          //  pointsEarned(50);
        }
    }
}
