using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Hypercorrect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Hypercorrect.Pages
{
    public class FavouritesModel : PageModel
    {
		public IConfiguration server;
		public List<Papers7> PaperList { get; set; }
		public string Message { get; set; }
		public FavouritesModel(IConfiguration server)
		{
			this.server = server;
		}

		public void OnGet()
		{
			List<Favourite> favouritesList = new List<Favourite>();
			GetFavouritesList(favouritesList, User.Identity.Name);
			List<Papers7> paperList = new List<Papers7>();
			GetPaperList(paperList, favouritesList);
			PaperList = paperList;
		}

		public void OnPostDeletetoFavorites(string id)
		{
			string sql = null;
			sql = "SELECT * FROM  papers7 where id = '" + id + "' Limit 1;";

			if (!string.IsNullOrEmpty(sql))
			{
				Database db_con = new Database();
				var db = db_con.Select(sql, this.server);
				if (db.HasRows)
				{

					string sql1 = null;
					sql1 = "SELECT * FROM  favourites where fpaper = '" + id + "' and fuser = '" + User.Identity.Name + "'  Limit 1;";

					if (!string.IsNullOrEmpty(sql1))
					{
						Database db_con1 = new Database();
						var db1 = db_con1.Select(sql1, this.server);
						if (db1.HasRows)
						{

							string sql2 = null;
							sql2 = "Delete FROM  favourites where fpaper = '" + id + "' and fuser = '" + User.Identity.Name + "';";

							if (!string.IsNullOrEmpty(sql2))
							{
								Database db_con2 = new Database();
								var db2 = db_con2.Select(sql2, this.server);
								Message = "Favourite was deleted successfully.";
							}

						}
						else
						{
							Message = "UnAuthorized action taken.";
						}
					}
				}
				else
				{
					Message = "UnAuthorized action taken.";
				}
			}
			OnGet();
		}

		public void GetFavouritesList(List<Favourite> favouritesList, string? email = null)
		{
			string sql = null;
			//sql = "SELECT TOP 3 * FROM papers7";
			//Seçilen Paper Bilgileri
			sql = "SELECT * FROM  favourites where fuser = '" + email + "';";
			if (!string.IsNullOrEmpty(sql))
			{
				Database db_con = new Database();
				var db = db_con.Select(sql, this.server);
				if (db.HasRows)
				{
					while (db.Read())
					{
						Favourite myFavourite = new Favourite();
						myFavourite.Fnumber = db.GetInt32("fnumber");
						myFavourite.Fpaper = db.GetString("fpaper");
						myFavourite.Fuser = db.GetString("fuser");
						favouritesList.Add(myFavourite);
					}
				}
			}
		}

		public void GetPaperList(List<Papers7> paperList, List<Favourite> favouritesList)
		{
			foreach (var item in favouritesList)
			{
				string sql = null;
				sql = "SELECT * FROM  papers7 where id = '" + item.Fpaper + "';";

				if (!string.IsNullOrEmpty(sql))
				{
					Database db_con = new Database();
					var db = db_con.Select(sql, this.server);
					if (db.HasRows)
					{
						while (db.Read())
						{
							Papers7 myPapers = new Papers7();
							myPapers.Id = db.GetString("id");
							myPapers.Abstract = db.GetString("abstract");

							if (!string.IsNullOrEmpty(db.GetValue("published_date").ToString()))
							{
								myPapers.PublishedDate = db.GetDateTime("published_date");
							}
							else
							{
								myPapers.PublishedDate = null;
							}
							myPapers.GithubUrl = db.GetString("github_url");
							myPapers.PdfUrl = db.GetString("pdf_url");
							myPapers.Title = db.GetString("title");
							paperList.Add(myPapers);
						}
					}
				}
			}
		}
	}
}
