using Hypercorrect.DTO;
using Hypercorrect.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Hypercorrect.Pages
{
	public class recommendMeModel : PageModel
	{
		private readonly ILogger<paperDetailModel> _logger;
		public List<PapersAndSimilarityDTO> new_paper_list { get; set; }
		public IConfiguration server;
		public recommendMeModel(ILogger<paperDetailModel> logger, IConfiguration server)
		{
			_logger = logger;
			this.server = server;
		}
		public void OnGet()
		{

			//TODO:Kullanýcýnýn favorilerinin listesini çek
			//cosine similarity tablosuna gidip favori metinlerin herbiri için benzerlik oranlarýna bak en yüksek olanlarý paketleyip ön yüze gönder.
			//Kullanýcýnýn üzerindeki telefon numarasýndan benzerlik oranýna eriþilecek

			//Kullanýcýnýn Favorileri
			string sql = string.Empty;
			sql = "SELECT * FROM favourites where fuser = '" + User.Identity.Name + "';";

			List<Favourite> userFavourites = new List<Favourite>();
			Database db_con = new Database();
			var db_favourites = db_con.Select(sql, this.server);
			if (db_favourites.HasRows)
			{
				while (db_favourites.Read())
				{
					Favourite favourite = new Favourite();
					favourite.Fnumber = db_favourites.GetInt32("fnumber");
					favourite.Fpaper = db_favourites.GetString("fpaper");
					favourite.Fuser = db_favourites.GetString("fuser");
					userFavourites.Add(favourite);
				}

			}

			//Kullanýcýnýn benzerlik oraný
			//TODO: AspNEt Users tablosuna baðlantý sorunu giderilecek
			sql = "SELECT \"PhoneNumber\" FROM  \"AspNetUsers\" where \"UserName\" = '" + User.Identity.Name + "';";
			string similarity = string.Empty;
			var db_user_info = db_con.Select(sql, this.server);
			if (db_user_info.HasRows)
			{
				while (db_user_info.Read())
				{
					similarity = db_user_info[0]?.ToString();
				}
			}

			double similarityScale = Convert.ToDouble(similarity.Replace('.', ','));

			//cosine similaritye bakýlacak.
			List<string> user_Favorite_papers = userFavourites.Select(s => "'" + s.Fpaper + "'").ToList();
			string user_favorites = string.Join(",", user_Favorite_papers);

			sql = "SELECT * FROM cosine_similarity where similarity > " + similarity + " and compare_paper_id in (" + user_favorites + ");";

			List<CosineSimilarity> cosine_similarities = new List<CosineSimilarity>();
			var db_cosine_similarities = db_con.Select(sql, this.server);
			if (db_cosine_similarities.HasRows)
			{
				while (db_cosine_similarities.Read())
				{
					CosineSimilarity cosine_similarity = new CosineSimilarity();
					cosine_similarity.SimilarityNumber = db_cosine_similarities.GetInt32("similarity_number");
					cosine_similarity.NewPaperId = db_cosine_similarities.GetString("new_paper_id");
					cosine_similarity.ComparePaperId = db_cosine_similarities.GetString("compare_paper_id");
					cosine_similarity.Similarity = db_cosine_similarities.GetDouble("similarity");
					cosine_similarities.Add(cosine_similarity);
				}

			}

			//Bulunan new paper idlerle paper bilgilerini getir ve ön yüzde yazdýr

			List<string> new_papers = cosine_similarities.Select(s => "'" + s.NewPaperId + "'").ToList();
			string found_new_papers = string.Join(",", new_papers);

			sql = "SELECT * FROM papers7 where id in (" + found_new_papers + ");";

			new_paper_list = new List<PapersAndSimilarityDTO>();
			var db_new_paper = db_con.Select(sql, this.server);
			if (db_new_paper.HasRows)
			{
				while (db_new_paper.Read())
				{
					PapersAndSimilarityDTO new_paper = new PapersAndSimilarityDTO();
					new_paper.Id = db_new_paper.GetString("id");
					new_paper.Abstract = db_new_paper.GetString("abstract");
					if (!string.IsNullOrEmpty(db_new_paper.GetValue("published_date").ToString()))
					{
						new_paper.PublishedDate = db_new_paper.GetDateTime("published_date");
					}
					else
					{
						new_paper.PublishedDate = null;
					}

					new_paper.GithubUrl = db_new_paper.GetString("github_url");
					new_paper.PdfUrl = db_new_paper.GetString("pdf_url");
					new_paper.Title = db_new_paper.GetString("title");

					new_paper_list.Add(new_paper);
				}

			}

			foreach (var item in new_paper_list)
			{
				item.Similarity = cosine_similarities.FirstOrDefault(x => x.NewPaperId == item.Id).Similarity;
			}
		}
	}
}
