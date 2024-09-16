using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace explosion
{
    internal class Plugin : Plugin<Config>
    {
        public override string Name => "PluginHomemBomba";
        public override string Author => "Adan";
        public override Version Version { get; } = new Version(1, 0, 0);

        public static Plugin Singleton;
        internal EventHandlers _eventHandler { get; set; }

        public override void OnEnabled()
        {
            Plugin.Singleton = this;
            _eventHandler = new EventHandlers();
            Player.Dying += _eventHandler.onDeath;
            base.OnEnabled();
            Log.Info("A função onEnable foi chamada!");
        }

        public override void OnDisabled()
        {
            Player.Dying -= _eventHandler.onDeath;
            base.OnDisabled();
            Plugin.Singleton = null;
            Log.Info("A função onDisable foi chamada!");
        }
    }
}
