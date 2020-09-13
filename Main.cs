using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F.Kill4Xp
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance;
        protected override void Load()
        {
            Instance = this;
            Logger.Log("F.Kill4Xp loaded");
            Logger.Log($"Reward for HsKIll: {Main.Instance.Configuration.Instance.HsXp4Kill}");
            Logger.Log($"Reward for KIll: {Main.Instance.Configuration.Instance.Xp4Kill}");
            UnturnedPlayerEvents.OnPlayerDeath += OnPlayerDeath;
        }


        private void OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, Steamworks.CSteamID murderer)
        {
            var mplayer = UnturnedPlayer.FromCSteamID(murderer);

            if (cause.ToString() == "GUN")
            {
                if (limb == ELimb.SKULL)
                {
                    mplayer.Experience = mplayer.Experience + Main.Instance.Configuration.Instance.HsXp4Kill;
                    UnturnedChat.Say(mplayer, String.Format(Translate("RewardForXp"), player.DisplayName, Main.Instance.Configuration.Instance.HsXp4Kill));
                }
                else
                {
                    mplayer.Experience = mplayer.Experience + Main.Instance.Configuration.Instance.Xp4Kill;
                    UnturnedChat.Say(mplayer, String.Format(Translate("RewardForXp"), player.DisplayName, Main.Instance.Configuration.Instance.Xp4Kill));
                }

            }
            else if (cause.ToString() == "MELEE")
            {
                if (limb == ELimb.SKULL)
                {
                    mplayer.Experience = mplayer.Experience + Main.Instance.Configuration.Instance.HsXp4Kill;
                    UnturnedChat.Say(mplayer, String.Format(Translate("RewardForXp"), player.DisplayName, Main.Instance.Configuration.Instance.HsXp4Kill));
                }
                else
                {
                    mplayer.Experience = mplayer.Experience + Main.Instance.Configuration.Instance.Xp4Kill;
                    UnturnedChat.Say(mplayer, String.Format(Translate("RewardForXp"), player.DisplayName, Main.Instance.Configuration.Instance.Xp4Kill));
                }
            }
        }


        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "RewardForXp", "Reward for killing {0} is {1}" },
        };

        protected override void Unload()
        {
            Logger.Log("F.Kill4Xp Unloaded");
            UnturnedPlayerEvents.OnPlayerDeath -= OnPlayerDeath;
        }
    }
}
