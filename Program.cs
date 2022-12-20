using System;
using System.Collections.Generic;

namespace LR2
{
	
	public class GameAccount
	{
		static int rating = 0;  //рейтинг на який гравці грають 
		static int result;
		static int index = 1;
		static List<string> history = new List<string>();
		static Random rnd = new Random();

		static readonly GameAccount Kolia = new GameAccount("KOLIA", 20, "classic");
		static readonly GameAccount Olia = new GameAccount("OLIA", 50,"classic");
		static readonly GameAccount Vania = new GameAccount("VANIA", 10,"classic");
		public string Username { get; }
		public int CurrentRating { get; set; }
		public string Account { get; set; }


		public GameAccount(string name, int rating,string account)
		{
			this.Username = name;
			this.CurrentRating = rating;
			this.Account = account;
		}

		public static void SaveHistory(List<string> history,int index, string winner, string loser, int winnerRating, int loserRating)
		{
			history.Add("GAME:" + index+ "\t" + winner +  " VS " + loser + " \t WINNER:" + winner + "[" + winnerRating + "] \t LOSER:" + loser + "[" + loserRating + "]\n");
		}

		public static void GetHistory(List<string> history)
		{
			for (int i = 0; i < history.Count; i++)
			{
				Console.Write(history[i]);
			}
		}
		
		public string PlayerInformation() //інформація про гравця 
		{
			return "Player [name=" + this.Username + ", Rating=" + this.CurrentRating.ToString() + ", Account=" + this.Account+ "]";
		}
		
		public static int WinGame(int ratingPlayer,  int rating) //перемога
		{
			return ratingPlayer + rating;
		}
		
		public static int LoseGame(int ratingPlayer,  int rating) //програш 
		{
			if (Kolia.Account == "vip" || Olia.Account == "vip" || Vania.Account == "vip")
			{
				ratingPlayer -= 0;
			}
			else
			{
				ratingPlayer -= rating;
				if (ratingPlayer < 0)
				{
					ratingPlayer = 0;
				}
			}
			
			return ratingPlayer;
		}
		public static void InformationAboutPlayers() //гра
		{
			//іформація про гравців 
			Console.WriteLine("\n\t\tInformation about players:");
			Console.WriteLine(Kolia.PlayerInformation());
			Console.WriteLine("----------------------------------------------------------");
			Console.WriteLine(Olia.PlayerInformation());
			Console.WriteLine("----------------------------------------------------------");
			Console.WriteLine(Vania.PlayerInformation());
			Console.WriteLine("----------------------------------------------------------\n");
		}
		
		public static string VipAccount() //преміум аккаунт так/ні?
		{
			Console.WriteLine("there is a New Year's promotion. Do you want to give one of the players a VIP account?" +
			                  "If the player has VIP account, he does not lose his rating if he loses");
			Console.WriteLine("1 - yes | 2 - no");
			var yesNo = Console.ReadLine();
			if (yesNo == "1")
			{
				Console.WriteLine("To whom to give VIP?\n 1-Kolia\n 2-Olia\n 3-Vania");
				var playerChoice = Console.ReadLine();
				if (playerChoice == "1")
				{
					return Kolia.Account = "vip";
				}else if (playerChoice == "2")
				{
					return Olia.Account = "vip";
				}else if (playerChoice == "3")
				{
					return Vania.Account = "vip";
				}
			}

			return "status changed";
		}
		
		public static void Game1() //гра
		{
			Console.WriteLine("Would you like to view the player rating?");
			Console.WriteLine("1 - yes | 2 - no");
			var yesNo = Console.ReadLine();
			if (yesNo == "1")
			{
				InformationAboutPlayers();
			}

			VipAccount();
			InformationAboutPlayers();
			Console.WriteLine("Choose the players who will play:");
			Console.WriteLine("1 - kolia + olia\n2 - kolia + vania\n3 - olia + vania");
			var playerChoice = Console.ReadLine();
			if (playerChoice == "1") 
			{
				//гра 1 
				result =  rnd. Next(1, 3);
				switch (result)
				{
					case 1: Kolia.CurrentRating = WinGame(Kolia.CurrentRating, rating);
						Olia.CurrentRating = LoseGame(Olia.CurrentRating, rating);
						SaveHistory(history, index,"kolia", "olia",Kolia.CurrentRating, Olia.CurrentRating);
						break;
				
					case 2 :Olia.CurrentRating = WinGame(Olia.CurrentRating, rating);
						Kolia.CurrentRating = LoseGame(Kolia.CurrentRating, rating);
						SaveHistory(history, index,"olia", "kolia",Olia.CurrentRating, Kolia.CurrentRating);
						break;
				}

				index++;
				GetHistory(history);
				Choose_game();
				Kolia.Account = "classic";
				Olia.Account = "classic";
				Vania.Account = "classic";
				Game1();
				
			}else if (playerChoice == "2")
			{
				//гра 2 
				result =  rnd. Next(1, 3);
				switch (result)
				{
					case 1: Kolia.CurrentRating = WinGame(Kolia.CurrentRating, rating);
						Vania.CurrentRating = LoseGame(Vania.CurrentRating, rating);
						SaveHistory(history, index,"kolia", "vania",Kolia.CurrentRating, Vania.CurrentRating);
						break;
				
					case 2 :Vania.CurrentRating = WinGame(Vania.CurrentRating, rating);
						Kolia.CurrentRating = LoseGame(Kolia.CurrentRating, rating);
						SaveHistory(history, index,"vania", "kolia",Vania.CurrentRating, Kolia.CurrentRating);
						break;
				}

				index++;
				GetHistory(history);
				Choose_game();
				Kolia.Account = "classic";
				Olia.Account = "classic";
				Vania.Account = "classic";
				Game1();
				
			}else if (playerChoice == "3")
			{
				//гра 3 
				result =  rnd. Next(1, 3);
				switch (result)
				{
					case 1: Vania.CurrentRating = WinGame(Vania.CurrentRating, rating);
						Olia.CurrentRating = LoseGame(Olia.CurrentRating, rating);
						SaveHistory(history, index,"vania", "olia",Vania.CurrentRating, Olia.CurrentRating);
						break;
				
					case 2 :Olia.CurrentRating = WinGame(Olia.CurrentRating, rating);
						Vania.CurrentRating = LoseGame(Vania.CurrentRating, rating);
						SaveHistory(history, index,"olia", "vania",Olia.CurrentRating, Vania.CurrentRating);
						break;
				}
				index++;
				GetHistory(history);
				Choose_game();
				Kolia.Account = "classic";
				Olia.Account = "classic";
				Vania.Account = "classic";
				Game1();
				
			}
			
		}

		private static void Choose_game() //вибір гри
		{
			Console.WriteLine("Choose a game:");
			Console.WriteLine("1 - classic game with a rating of 10\n2 - double rated game\n3 - unrated game");
			string typeOfGame;
			typeOfGame = Console.ReadLine();
			if (typeOfGame == "1")
			{
				
				Console.WriteLine("You have chosen a classic game with a rating of 10");
				rating = 10;
			}
			else if (typeOfGame == "2")
			{
				Console.WriteLine("You have selected a double rated game");
				rating = 20;
			}
			else if (typeOfGame == "3")
			{
				Console.WriteLine("You have selected a training game without rating");
				rating = 0;
			}
			
		}
		
		 
		public static void Main(String[] args)
		{
			Choose_game();
			Game1();
		}
	}	
	
}