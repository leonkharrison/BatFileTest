using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BatFileTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Playerdata newplayer = CreateNewPlayer("Talon Chaar", 9001);
            SavePlayer(newplayer);
            LoadPlayer("Talon Chaar");

            Console.WriteLine("Debug stop");
        }

        public static Playerdata CreateNewPlayer(string name, int xp)
        {
            Playerdata player = new Playerdata();

            player.PlayerName = name; Console.WriteLine("Name: " + name);
            player.PlayerXP = xp; Console.WriteLine("XP: " + xp.ToString());

            return player;
        }

        public static void SavePlayer(Playerdata playertosave)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(@"C:\Users\lharrison\Desktop\" + playertosave.PlayerName + ".plyr");
            bf.Serialize(file, playertosave);
            file.Close();
            Console.WriteLine("File Saved");
        }

        public static void LoadPlayer(string playername)
        {
            if (File.Exists(@"C:\Users\lharrison\Desktop\" + playername + ".plyr"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(@"C:\Users\lharrison\Desktop\" + playername + ".plyr", FileMode.Open);
                Playerdata playerdata = (Playerdata)bf.Deserialize(file);
                file.Close();

                Console.WriteLine("File read");
                Console.WriteLine("Read name: " + playerdata.PlayerName);
                Console.WriteLine("Read XP: " + playerdata.PlayerXP.ToString());
            }
        }
    }

    [Serializable]
    public class Playerdata
    {
        public string PlayerName { get; set; }
        public int PlayerXP { get; set; }

        public Playerdata()
        {
            ClearAll();
        }
        private void ClearAll()
        {
            PlayerName = string.Empty;
            PlayerXP = 0;
        }
    }
}
