using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using UnityEngine;

namespace ChatRewards
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance;
        public bool OyunBasladi;
        public int DogruKelime;       
        protected override void Load()
        {
            Instance = this;
            UnturnedPlayerEvents.OnPlayerChatted += PlayerChatted;
        }       
        protected override void Unload()
        {
            Instance = null;
            UnturnedPlayerEvents.OnPlayerChatted -= PlayerChatted;
        }
        public IEnumerator<WaitForSeconds> Count()
        {
            var c = Configuration.Instance;
            for (var kalanSure = 5; kalanSure > 0; kalanSure--)
            {
                ChatManager.serverSendMessage(c.Translitions[0].ReamingTime.Replace('{', '<').Replace('}', '>').Replace("%TIME%", kalanSure.ToString()), Color.white, null, null, EChatMode.SAY, c.MessageImage, true);
                yield return new WaitForSeconds(1f);
            }         
            System.Random rastgele = new System.Random();
            int no = rastgele.Next(0, c.Words.Count);
            DogruKelime = no;
            var kelime = c.Words[no];
            ChatManager.serverSendMessage(c.Translitions[0].WordMessage.Replace('{', '<').Replace('}', '>').Replace("%WORD%", kelime), Color.white, null, null, EChatMode.SAY, c.MessageImage, true);

            StopCoroutine(Count());
        }
        private void PlayerChatted(UnturnedPlayer player, ref Color color, string message, EChatMode chatMode, ref bool cancel)
        {
            if (OyunBasladi)
            {
                if (message == Configuration.Instance.Words[DogruKelime])
                {
                    var c = Configuration.Instance;
                    OyunBasladi = false;
                    System.Random rastgele = new System.Random();
                    int no = rastgele.Next(0, Configuration.Instance.Rewards.Count);
                    player.GiveItem(Configuration.Instance.Rewards[no], 1);
                    ChatManager.serverSendMessage(c.Translitions[0].WinnerMessage.Replace('{', '<').Replace('}', '>').Replace("%WINNERNAME%", player.DisplayName), Color.white, null, null, EChatMode.SAY, c.MessageImage, true);
                }
            }
            else return;
        }        
    }
}
