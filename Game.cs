//COMMENTS AFTER STEP 7

//STEP 10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Lab2
{
    public class Game
    {
        public string team1 { get; set; }
        public string team2 { get; set; }
        public int team1Score { get; set; }
        public int team2Score { get; set; }

        public Game()
        {

        }

        public Game(string team1, string team2, int team1Score, int team2Score)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.team1Score = team1Score;
            this.team2Score = team2Score;
        }

        public override string ToString()
        {
            String message = team1 + " (" + team1Score + ") " + "- " + team2 + " (" + team2Score + ") ";
            return message;
        }


    }

    public class GameFactory
    {
        public List<Game> listOfGames;

        public string FilePath { get; set; }
        

        public void CreateGameList()
        {
            listOfGames = new List<Game>();

            Game game = new Game("Hornets", "Bulldogs", 10, 20);
            listOfGames.Add(game);

            game = new Game("Sharks", "Bulldogs", 10, 20);
            listOfGames.Add(game);

            game = new Game("Hornets", "Sharks", 10, 20);
            listOfGames.Add(game);

            game = new Game("Panthers", "Sharks", 10, 20);
            listOfGames.Add(game);

            game = new Game("Hornets", "Panthers", 10, 20);
            listOfGames.Add(game);

            game = new Game("Lions", "Dogs", 10, 20);
            listOfGames.Add(game);



        }

        public bool SerializeGameList()
        {
            StreamWriter sw = new StreamWriter(FilePath);
            XmlSerializer serial = new XmlSerializer(listOfGames.GetType());
            serial.Serialize(sw, listOfGames);
            sw.Close();

            return true;
            
        }

        public List<Game> DeserializeGameList()
        {
            listOfGames = new List<Game>();

            StreamReader sr = new StreamReader(FilePath);
            XmlSerializer serial = new XmlSerializer(listOfGames.GetType());
            
            listOfGames = (List<Game>)serial.Deserialize(sr);
            sr.Close();

            return listOfGames;
        }
    }
}
