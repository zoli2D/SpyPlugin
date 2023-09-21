namespace SpyPlugin
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.CustomRoles.API.Features;
    using Exiled.Events.EventArgs.Player;
    using Exiled.Events.EventArgs.Server;
    using PlayerRoles;
    using Exiled.API.Features.Roles;
    using Exiled.CustomRoles.Events;


    /// <summary>
    /// Handles general events for this _056Plugin.
    /// </summary>
    public class EventHandlers
    {
        private readonly SpyPlugin _plugin;

        internal EventHandlers(SpyPlugin plugin) => this._plugin = plugin;

        public int x = 0;
        public void OnJoin(JoinedEventArgs ev)
        {
            x = x + 1;
        }
        public void OnLeft(LeftEventArgs ev)
        {
            x = x - 1;
        }


        private bool HasSpyRoleSpawned = false;

        private int SpawnChance = 0;

        public void OnSpawned(SpawnedEventArgs ev)
        {
            if (Server.PlayerCount >= 12)
            {
                if (HasSpyRoleSpawned == false)
                {
                    SpawnChance = UnityEngine.Random.Range(1, 101);
                    if (SpawnChance <= 10 && HasSpyRoleSpawned == false)
                    {
                        if (ev.Player.Role.Type == RoleTypeId.NtfSergeant)
                        {
                            HasSpyRoleSpawned = true;
                            CustomRole.Get(typeof(SpyRole)).AddRole(ev.Player);
                        }
                    }

                }
            }
        } 


        internal void OnEndingRound(EndingRoundEventArgs ev)
        {
            HasSpyRoleSpawned = false;
        }
    }
}