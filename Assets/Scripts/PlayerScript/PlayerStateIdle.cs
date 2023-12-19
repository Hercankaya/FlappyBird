using UnityEngine;

public class PlayerStateIdle : PlayerStateBase
{
    public PlayerStateIdle(PlayerController playerController) : base(playerController){ }
    

    public override void EnterState(PlayerController playerController)
    {
        playerController.Rigidbody.gravityScale = 0 ;
    }
    public override void UpdateState(PlayerController playerController)
    {
       
    }
    public override void ExitState(PlayerController playerController)
    {
        playerController.Rigidbody.gravityScale = 1;
    }
 

}
