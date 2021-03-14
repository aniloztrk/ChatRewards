using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using UnityEngine;

namespace ChatRewards
{
    public class Command : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "chatreward";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new List<string> { "cr", "kelimeoyunu"};

        public List<string> Permissions => new List<string> { "mixy.chatreward" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var c = Main.Instance.Configuration.Instance;
            var player = caller as UnturnedPlayer;
            if (player.HasPermission("mixy.chatreward"))
            {
                if (Main.Instance.OyunBasladi)
                {
                    ChatManager.serverSendMessage(c.Translitions[0].TheGameHasAlreadyStarted.Replace('{', '<').Replace('}', '>'), Color.white, null, null, EChatMode.SAY, c.MessageImage, true);
                }
                else
                {
                    Main.Instance.OyunBasladi = true;
                    Main.Instance.StartCoroutine(Main.Instance.Count());
                }
            }
            else
            {
                UnturnedChat.Say(player, "You don`t have a permission.", Color.red);
            }
        }
    }
}
