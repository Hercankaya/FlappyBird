using System;
using UnityEngine;

public abstract class PlayerStateBase // soyut sýnýf oluþturduk.
{
    protected PlayerController _playerController; // Player controller sýnýfýndan _playerController isimli bir nesne oluþturduk.

    public PlayerStateBase( PlayerController playerController)  // PlayerStateBase sýnýfýndan türeyen sýnýflar PlayerController nesnesine eriþebilir.
    {                                                           //constructor bir  metod  tanýmlanmýþtýr.(yapýcý).
        _playerController = playerController;
    }

   public abstract void EnterState( PlayerController playerController ); // giriþ
   public abstract void UpdateState( PlayerController playerController );// güncelleme
   public abstract void ExitState( PlayerController playerController );// çýkýþ
   

}
