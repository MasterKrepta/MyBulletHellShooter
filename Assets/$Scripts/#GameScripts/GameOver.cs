using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private void OnEnable() {
        GameManager.GameOver += DisplayGameOverScreen;
        GameManager.GameOver += PauseGamePlay;
        GameManager.GameOver += CalculateFinalScore;
        GameManager.GameOver += RestartQuitMenu;
    }

    private void OnDisable() {
        GameManager.GameOver -= DisplayGameOverScreen;
        GameManager.GameOver -= PauseGamePlay;
        GameManager.GameOver -= CalculateFinalScore;
        GameManager.GameOver -= RestartQuitMenu;
    }

    void DisplayGameOverScreen() {
        Debug.Log("You lost, you fail at all the things");
    }

    void PauseGamePlay() {
        //stop ships from spawning, (turn off their weapons and let the last wave scroll accross the screen?)
        Debug.Log("Pause the game");
    }

    void CalculateFinalScore() {
        Debug.Log("Calculate your final score");
        int pointsEarned = 0;
        //modify based on num kills, bonus objectives, etc....
        AwardCredits(pointsEarned);
    }
    void AwardCredits(int pointsEarned) {
        Debug.Log("Enjoy your new credits " + pointsEarned);
        //PointsEarned * player modifiers and bonuses
        // display to the screen
    }

    void RestartQuitMenu() {
        Debug.Log("Display a menu to restart or go back to the main menu");
    }
}
