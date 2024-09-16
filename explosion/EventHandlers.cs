using Exiled.Events.EventArgs.Player;
using UnityEngine;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using System;


namespace explosion
{
    internal class EventHandlers
    {
        public void onDeath(DyingEventArgs ev)
        {
            Vector3 playerPosition = ev.Player.Position;

            // ev.Player.Explode(); Explosão muito potente
            // Map.Explode(playerPosition, Exiled.API.Enums.ProjectileType.FragGrenade, ev.Player);  Explosão muito potente
            if (ev.Attacker != null) { 
                ev.Attacker.Broadcast(5, $"{ev.Player.Nickname} explodiu ao morrer!", Broadcast.BroadcastFlags.Normal);
            }

            ExplosiveGrenade instaboom = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
            instaboom.FuseTime = 0.1f;
            instaboom.SpawnActive(playerPosition);
            
            Log.Info("A função OnDeath foi chamada!");
            
        }   
    }
}
