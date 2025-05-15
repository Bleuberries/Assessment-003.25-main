using UnityEngine;

public class NPCController : MonoBehaviour
{
    public enum NPCState { Waiting, Dancing }
    public NPCState currentState = NPCState.Waiting; 

    public string currentDance; 

    public Animator animator; 
    
    private string[] danceMoves = { "DanceA", "DanceB",  "DanceC" };
    
    public void ChangeState()
    {
        if (currentState == NPCState.Waiting)
        {
            currentState = NPCState.Dancing;
            ChooseDance();
        }
        else
        {
            currentState = NPCState.Waiting;
        }
    }

    void ChooseDance()
    {
        currentDance = danceMoves[Random.Range(0, danceMoves.Length)];
        animator.Play(currentDance);
        Debug.Log("NPC is dancing: " + currentDance);
    }
}
