using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class GameManager : MonoBehaviour {

#region Var Declarations
    public float respawnTime = 2f;
    public float pointModifier = 1.0f;
    public Text txtPoints;
    private int currentPoints;
    private int currentCredits;
    public Text txtCredits;
    public int playerLives;
    public int maxLives = 3;
    //PlayerProgression progression;

    //private int highScore = 0;
    public delegate void PlayerEvents(int pointsToGive);
    public static event PlayerEvents EarnedPoints;
    public static event PlayerEvents EarnedCredits;
    public static event PlayerEvents UpdateProgress;
    public delegate void PlayerHealthEvents();
    public static event PlayerHealthEvents PlayerDeath;
    public static event PlayerHealthEvents RespawnPlayer;
    public static event PlayerHealthEvents GameOver;

    public delegate void LootEvents();
    public static event  LootEvents SpawnLoot;


    #endregion
    private void OnEnable() {
        EarnedCredits += GiveCredits;
    }

    private void OnDisable() {
        EarnedCredits -= GiveCredits;
    }

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

    private void Start() {
        playerLives = maxLives;
        //progression = GetComponent<PlayerProgression>();
    }

    public void CallEarnedPoints(int pointsToGive) {
        EarnedPoints(pointsToGive);
    }

    public void CallSpawnLoot() {
        SpawnLoot();
    }

    public void CallEarnedCredits(int CreditsToGive) {
        EarnedCredits(CreditsToGive);
    }

    public void CallUpdateProgress(int creditsEarned) {
        UpdateProgress(creditsEarned);
    }

    public void GivePoints(int pointsToGive) {
        currentPoints += pointsToGive;
        txtPoints.text = currentPoints.ToString();
    }

    public void GiveCredits(int creditsToGive) {
        currentCredits += creditsToGive;
        txtCredits.text = currentCredits.ToString();
    }

    public void NewHighScore(int score) {
        //highScore = score;
        //TODO: make some sort of visuals and update the visual display
    }

    public void CallPlayerDeath() {
        PlayerDeath();
        bool lastLife = LoseLife();
        if (!lastLife) {
            StartCoroutine(WaitForRespawn());
            //TODO update life display
        }
        else {
            CallGameOver();
        }
    }

    public void CallGameOver() {
        GameOver();
    }



        IEnumerator WaitForRespawn() {
        yield return new WaitForSeconds(respawnTime);
        //Debug.Log("Calling the delegate");
        RespawnPlayer();
    }

    bool LoseLife() {
        bool isGameOver = false;
        playerLives--;
        if(playerLives <= 0) {
            isGameOver = true;
            return isGameOver;
        }
        return isGameOver;
    }
}
