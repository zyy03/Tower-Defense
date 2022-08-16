using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    private bool gameOver = false;
    
    // Update is called once per frame
    void Update()
    {
        if(gameOver) return;

        if(PlayerStats.Lives <= 0){
            EndGame();
        }
        
    }

    void EndGame(){
        gameOver = true;
        Debug.Log("GAME OVER!");
    }
}
