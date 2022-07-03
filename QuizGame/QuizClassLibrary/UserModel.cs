using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizClassLibrary;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace QuizClassLibrary
{
    public class UserModel
    {
        public int userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public System.DateTime birthday { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }


        //Function validimi i fushave te krijimi te ueserit;
        public string CheckFileds(UserModel usera)
        {
            if (string.IsNullOrEmpty(usera.firstName))
                return "Fill the name field!";
            if (string.IsNullOrEmpty(usera.lastName))
                return "Fill the surname field!";
            if (string.IsNullOrEmpty(usera.email))
                return "Fill the email field!";
            if (string.IsNullOrEmpty(usera.password))
                return "Fill the password field!";

            if (System.DateTime.Now.Year - usera.birthday.Year <= 10)
                return "You have to be at least 10y/o!";

            using (QuizEntities conn = new QuizEntities())
            {
                var user = conn.Users.Where(x => x.email == usera.email).FirstOrDefault();

                if(user != null)
                    return "This email exist! Try another one.";
            }
            
            return string.Empty;
        }
        
        public bool Create (UserModel newUser)
        {
            try
            {
                using (QuizEntities conn = new QuizEntities())
                {
                    var usera = new User()
                    {
                        userID = newUser.userID,
                        firstName = newUser.firstName,
                        lastName = newUser.lastName,
                        email = newUser.email,
                        gender = newUser.gender,
                        birthday = newUser.birthday,
                        password = ComputeSha256Hash(newUser.password),
                        isAdmin = newUser.isAdmin
                    };
                    conn.Users.Add(usera);
                    conn.SaveChanges();

                    return true;

                }

            }
            catch(Exception)
            {
                return false;

            } 
        }
    
        public bool Update(UserModel user)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var checkUser = conn.Users.Find(user.userID);

                if (checkUser == null)
                    return false;
                else
                {
                    checkUser.firstName = user.firstName;
                    checkUser.lastName = user.lastName;
                    checkUser.email = user.email;
                    checkUser.gender = user.gender;
                    checkUser.birthday = user.birthday;
                    checkUser.password = user.password;
                    checkUser.isAdmin = user.isAdmin;

                    conn.SaveChanges();
                    return true;
                }
            }
        }

        public bool Delete(int userID)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var checkUser = conn.Users.Find(userID);

                if (checkUser == null)
                    return false;
                else
                {
                    conn.Users.Remove(checkUser);
                    return true;
                }
            }
        }

        //GetUser
        public List<UserModel> GetUser(string searchText)
        {
            using (var conn = new QuizEntities())
            {
                var useri = new List<User>();

                if (string.IsNullOrEmpty(searchText))
                        useri = conn.Users.ToList();
                //    //useri = conn.Users.Where(x => x.isAdmin == true).ToList();
              //  useri = conn.Users.ToList();
                
                useri = conn.Users
                 .Where(x => (x.firstName.StartsWith(searchText))).ToList();
                ////useri = conn.Users
                ////  .Where(x => x.isAdmin == false & (x.firstName.StartsWith(searchText) | x.lastName.StartsWith(searchText))).ToList();
                var usera = useri
                    .Select(x => new UserModel()
                    {
                        userID = x.userID,
                        firstName = x.firstName,
                        lastName = x.lastName,
                        email = x.email,
                        gender = (x.gender == "M" ? "Male" : "Female"),
                        birthday = x.birthday,
                        password = x.password,
                        isAdmin = x.isAdmin,
                    })
                    .ToList();

                return usera;

            }
        }

        public User Login(string email, string password)
        {
            using (QuizEntities conn = new QuizEntities())
            {
                var useri = conn.Users.Where(x => x.email == email && x.password == password).FirstOrDefault();

                return useri;
            }
        }

        //Function Hash
        
        public string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
    }
}
