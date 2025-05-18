using UnityEngine;

public class GameManager : MonoBehaviour
{
   public PlayerController player; 
   public NPCController[] npcs; // now an array of NPCs

   public float timeLimit = 5f; 
   private float timer; 

   void Start()
   {
        StartGame();
   }

    void Update()
    {
        if (player.currentState == PlayerController.PlayerState.WaitingInput)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                GameOver();
            }
        }
    }

    public void StartGame()
    {
       
       foreach (NPCController npc in npcs)
       {
            npc.ChangeState();
       }

       player.currentState = PlayerController.PlayerState.WaitingInput;
       ResetTimer();
    }

    public void ResetTimer()
    {
        timer = timeLimit;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER!");
        player.currentState = PlayerController.PlayerState.Idle;
    }
}
