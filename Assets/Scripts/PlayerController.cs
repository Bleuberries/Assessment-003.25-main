using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState { Idle, WaitingInput, Dancing }
    public PlayerState currentState = PlayerState.Idle; 


    public Animator animator;
    public NPCController npc;
    public GameManager gameManager;

    void Update()
    {
        if (currentState == PlayerState.WaitingInput)
        {
            if (Input.GetKeyDown(KeyCode.A))
            TryDance ("DanceA");
            if (Input.GetKeyDown(KeyCode.B))
            TryDance("DanceB"); 
            if (Input.GetKeyDown(KeyCode.C))
            TryDance("DanceC");
        }
    }

    void TryDance(string danceMove)
    {
        if (npc.currentDance == danceMove)
        {
            animator.Play(danceMove);
            currentState = PlayerState.Dancing;
            gameManager.ResetTimer();
        }
        else
        {
            gameManager.GameOver();
        }
    
    }
}
