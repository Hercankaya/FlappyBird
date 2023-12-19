using UnityEngine;

public class PlayerStateDead : PlayerStateBase
{
    public PlayerStateDead(PlayerController playerController) : base(playerController) {  }

    public override void EnterState(PlayerController playerController)
    {
        Time.timeScale = 0f; 
    }
    public override void UpdateState(PlayerController playerController)
    {
        
    }
    public override void ExitState(PlayerController playerController)
    {
       
    }
   

}
