using UnityEngine;

public class PlayerStateDead : PlayerStateBase
{
    public PlayerStateDead(PlayerController playerController) : base(playerController) {  }

    public override void EnterState(PlayerController playerController)
    {
        playerController.transform.rotation = Quaternion.Euler(0, 0, -90);
    }
    public override void UpdateState(PlayerController playerController)
    {
        
    }
    public override void ExitState(PlayerController playerController)
    {
       
    }
   

}
