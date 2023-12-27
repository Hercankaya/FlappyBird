using UnityEngine;

public class PlayerStateFlying : PlayerStateBase
{
    public PlayerStateFlying(PlayerController playerController) : base(playerController) { }

    public override void EnterState(PlayerController playerController)
    {
        playerController.Rigidbody.velocity = new Vector2(playerController.Rigidbody.velocity.x,playerController.JumpPower);
        
    }
    public override void UpdateState(PlayerController playerController)
    {
       
    }
    public override void ExitState(PlayerController playerController)
    {
       
    }


}
