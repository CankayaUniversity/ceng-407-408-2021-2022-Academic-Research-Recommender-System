using CENG408.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;


namespace CENG408.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public IConfiguration server;
        User user = new User();

        public LoginModel(IConfiguration server)
        {
            this.server = server;
        }
        public void OnGet()
        {
            //this.Credential = new Credential { UserName = "admin" };
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            user = new User();
            string sql = null;
            if (!String.IsNullOrEmpty(Credential.UserName))
            {
                //SignUp
                sql = "SELECT " + '"' + "userName" + '"' + ',' + '"' + "mailAddress" + '"' + ',' + '"' + "userID" + '"' + " FROM " + '"' + "User" + '"' + " Where " + '"' + "mailAddress" + '"' + '=' + "'" + Credential.Email.ToString() + "'" + " and " + '"' + "userName" + '"' + '=' + "'" + Credential.UserName.ToString() + "'" + ';';

                if (String.IsNullOrEmpty(sql))
                {
                    return Page();
                }
                Database db = new Database(sql, this.server);
                if (db.data.HasRows)
                {
                    //There is already same user in DB, used Email and UserName
                    return Page();
                }
                else
                {
                    sql = "INSERT INTO " + '"' + "User" + '"' + '(' + '"' + "userName" + '"' + ',' + '"' + "mailAddress" + '"' + ',' + '"' + "password" + '"' + ") VALUES (" + "'" + Credential.UserName.ToString() + "'," + "'" + Credential.Email.ToString() + "'," + "'" + Credential.Password.ToString() + "');";
                    if (String.IsNullOrEmpty(sql))
                    {
                        return Page();
                    }
                    db = new Database(sql, this.server);
                    return Page();

                }

                    

            }
            else
            {
                //Login
                sql = "SELECT " + '"' + "userName" + '"' + ',' + '"' + "mailAddress" + '"' + ',' + '"' + "userID" + '"' + " FROM " + '"' + "User" + '"' + " Where " + '"' + "mailAddress" + '"' + '=' + "'" + Credential.Email.ToString() + "'" + " and " + '"' + "password" + '"' + '=' + "'" + Credential.Password.ToString() + "'" + ';';


                if (String.IsNullOrEmpty(sql))
                {
                    return Page();
                }
                Database db = new Database(sql, this.server);
                if (db.data.HasRows)
                {
                    while (db.data.Read())
                    {
                        user.userName = db.data.GetString(0);
                        user.mailAddress = db.data.GetString(1);
                        user.userID = Convert.ToInt32(db.data[2]);
                    }
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.userName),
                    new Claim(ClaimTypes.Email, user.mailAddress)
                };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                    return RedirectToPage("/Index");
                }
            }


            return Page();
        }
    }

    public class Credential
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Text)]
        public string UserName { get; set; }
    }
}
