using CENG408.Models;
using Hypercorrect.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Hypercorrect.Pages
{
    public class paperDetailModel : PageModel
    {
		private readonly hypercorrectContext _db;
		private readonly ILogger<paperDetailModel> _logger;
		//private readonly LoginModel _loginModel;
		public IConfiguration server;
		string paperIdGlobal = "";
		public paperDetail PaperDetail { get; set; }
		public string Message { get; set; }

		public paperDetailModel(hypercorrectContext db,ILogger<paperDetailModel> logger, IConfiguration server)
		{
			_db = db;
			_logger = logger;
			this.server = server;

			//User  asd=(User)ViewData["user"];
			//_loginModel = loginModel;
			//ViewData["login"] = loginModel;
		}
		public void OnGet(string paperId = "", int selectedPageNumber = 1)
		{

			paperDetail paperDetail = new paperDetail();
			paperIdGlobal = paperId;
			paperDetail = GetPaperDetail(paperId, selectedPageNumber);
			PaperDetail = paperDetail;
		}

		public void OnPostAddtoFavorites(string id)
		{
			/*
             await using var cmd = new NpgsqlCommand("INSERT INTO table (col1) VALUES ($1), ($2)", conn)
{
    Parameters =
    {
        new() { Value = "some_value" },
        new() { Value = "some_other_value" }
    }
};

await cmd.ExecuteNonQueryAsync();
             
             */
			string sql1 = null;
			sql1 = "SELECT * FROM  favourites where fpaper = '" + id + "' and fuser = '" + User.Identity.Name + "'  Limit 1;";

			if (!string.IsNullOrEmpty(sql1))
			{
				Database db_con1 = new Database();
				var db1 = db_con1.Select(sql1, this.server);
				if (!db1.HasRows)
				{
					string sql = null;
					sql = $"INSERT INTO favourites (fuser, fpaper) VALUES (:username, :paper)";
					Dictionary<string, string> values = new Dictionary<string, string>();
					values.Add("username", User.Identity.Name);
					values.Add("paper", id);
					Database db_con = new Database();
					int isSuccess = db_con.Insert(sql, this.server, values);

					//Console.WriteLine("Here!!!!!!!");
					//Console.WriteLine(User.Identity.Name);
					//Console.WriteLine(Model.PaperDetail?.SelectedPaper.Title);
					Console.WriteLine(id);
					Message = "Favourite added.";
				}
				else
				{
					Message = "Favourite item has already added before.";
				}
				OnGet(id, 1);
			}
		}




		public paperDetail GetPaperDetail(string paperId, int selectedPageNumber)
		{
			string sql = null;
			//sql = "SELECT TOP 3 * FROM papers7";
			//Seçilen Paper Bilgileri
			sql = "SELECT * FROM  papers7 where id = '" + paperId + "' LIMIT 1;";
			Paper myPaper = new Paper();
			if (!string.IsNullOrEmpty(sql))
			{
				Database db_con = new Database();
				var db = db_con.Select(sql, this.server);
				if (db.HasRows)
				{
					while (db.Read())
					{
						myPaper.Abstract = db.GetString("abstract");

						if (!string.IsNullOrEmpty(db.GetValue("published_date").ToString()))
						{
							myPaper.PublishedDate = db.GetDateTime("published_date");
						}
						else
						{
							myPaper.PublishedDate = null;
						}
						myPaper.GithubUrl = db.GetString("github_url");
						myPaper.Id = db.GetString("id");
						myPaper.PdfUrl = db.GetString("pdf_url");
						myPaper.Title = db.GetString("title");
					}
				}
			}

			//Seçilen Paper bilgisine göre Listelenen Tasklarýn Hepsi
			sql = null;
			sql = "SELECT * FROM  papers_tasks where id = '" + paperId + "';";
			List<PapersTask> taskNameListByPaperId = new List<PapersTask>();
			if (!string.IsNullOrEmpty(sql))
			{
				Database db_con = new Database();
				var db = db_con.Select(sql, this.server);
				if (db.HasRows)
				{
					while (db.Read())
					{
						PapersTask myTask = new PapersTask();
						myTask.Id = db.GetString("id");
						myTask.Task = db.GetString("task");
						myTask.IdNumber = db.GetInt32("id_number");
						taskNameListByPaperId.Add(myTask);
					}

				}
			}

			//Listelenen Tasklarýn ilkine uyan Paperlerýn Id'leri
			sql = null;
			sql = "SELECT * FROM papers_tasks where task = '" + taskNameListByPaperId[0].Task + "';";
			List<PapersTask> taskIdListByTaskName = new List<PapersTask>();
			if (!string.IsNullOrEmpty(sql))
			{
				Database db_con = new Database();
				var db = db_con.Select(sql, this.server);
				if (db.HasRows)
				{
					while (db.Read())
					{
						PapersTask myTask = new PapersTask();
						myTask.Id = db.GetString("id");
						myTask.Task = db.GetString("task");
						taskIdListByTaskName.Add(myTask);
					}

				}
			}
			decimal pageNumberDecimal = taskIdListByTaskName.Count / 3;
			int pageNumber = Convert.ToInt32(Math.Ceiling(pageNumberDecimal));
			int showingPageNumber = 0;
			List<PapersTask> taskIdList = new List<PapersTask>();

			var listOfDescTask = taskIdListByTaskName.OrderByDescending(x => x.Id).Skip(selectedPageNumber * 3 - 3).Take(3); //Linq tekniði
																															 //taskIdList.Add(listOfDescTask);

			foreach (var item in listOfDescTask)
			{
				taskIdList.Add(item);
			}

			List<Papers7> relationalPaperDetails = new List<Papers7>();
			foreach (var item in taskIdList)
			{
				sql = null;
				sql = "SELECT * FROM  papers7 where id = '" + item.Id + "' and published_date IS NOT NULL;";

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
							relationalPaperDetails.Add(myPapers);
						}
					}
				}
			}

			//myPaper -> Seçilen Paper Detaylarý
			//taskNameListByPaperId -> Seçilen Paper için Listelenecek Tasklar
			//relationalPaperDetails -> Ýliþkili tasklarýn Detaylarý
			paperDetail paperDetail = new paperDetail();
			paperDetail.SelectedPaper = myPaper;
			paperDetail.TaskList = taskNameListByPaperId;
			paperDetail.RelatedPaperList = relationalPaperDetails;
			PaperDetail = paperDetail;
			return paperDetail;
		}		
	}
}
