using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {
    public Transform playerRespawnPoint;
    
    public GameObject player;

    private void OnEnable() {
        if(player == null) {
            player = FindObjectOfType<PlayerMovement>().gameObject;
        }
        GameManager.RespawnPlayer += RespawnPlayer;
    }

    private void OnDisable() {
        GameManager.RespawnPlayer -= RespawnPlayer;
    }

    void RespawnPlayer() {
        //Debug.Log("Respawn");
        player.transform.position = playerRespawnPoint.position;
        player.SetActive(true);
       
    }
 

}
