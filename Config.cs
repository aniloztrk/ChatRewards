using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ChatRewards
{
    public class Config : IRocketPluginConfiguration
    {
        public string MessageImage;
        [XmlArrayItem("Word")]
        public List<string> Words = new List<string>();

        [XmlArrayItem("Reward")]
        public List<ushort> Rewards = new List<ushort>();

        public List<Translition> Translitions = new List<Translition>();
        public void LoadDefaults()
        {
            MessageImage = "";
            Words = new List<string>
            {
                "ucak35",
                "pipi",
                "mixyadam",
                "fastfingers",
                "zazaza",
                "32132345123",
                "3131",
                "wertrstfs"
            };
            Rewards = new List<ushort>
            {
                116,
                15,
                15,
                15,
                15,
                15,
                15,
                15,
                15,
                15
            };
            Translitions = new List<Translition>
            {
                new Translition()
                {
                    ReamingTime = "{color=#ffa500}Oyun Başlıyor !{/color} {color=#00f5ff}%TIME%{/color}",
                    WinnerMessage = "{color=#ffa500}Kazanan !{/color} {color=#00f5ff}%WINNERNAME%{/color}",
                    WordMessage = "Yazman gereken kelime : {color=#9a32cd}%WORD%{/color}",
                    TheGameHasAlreadyStarted = "{color=red}Oyun zaten başlamış.{/color}"
                }
            };
        }
    }
    public class Translition
    {
        public string ReamingTime, WinnerMessage, WordMessage, TheGameHasAlreadyStarted;
    }
}
