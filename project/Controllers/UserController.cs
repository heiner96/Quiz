using Npgsql;
using project.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using project.utils;
using System;

namespace project.Controllers
{
    [RequireHttps]
    public class UserController : Controller
    {
        //GET: User
        public ActionResult Index()
        {
            //    List<User> userList = select( email,  password);
            return View();
    }

        [HttpPost]
        public JsonResult registrar(string Nombre)
        {
            if (insert(Nombre))
            {
                return Json(Constants.SUCESS);
            }
            return Json(Constants.FAILURE);
        }

        [HttpPost]
        //public JsonResult createUser(string email, string password) {
        //    if (insert(email, password)) {
        //        return Json(Constants.SUCESS);
        //    }
        //    return Json(Constants.FAILURE);
        //}

        private bool insert(string nombre)
        {
            NpgsqlConnection conn = Utils.pgConnection();
            NpgsqlCommand command;
            try
            {
                conn.Open();
                command = new NpgsqlCommand(
                    "insert into lenguaje (lenguaje) values (@lenguaje);",
                    conn);
                command.Parameters.Add(new NpgsqlParameter("@lenguaje", nombre));
                return command.ExecuteNonQuery() > 0;
            }
            catch (NpgsqlException e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        //private User select(User user)
        //{
        //    NpgsqlConnection conn = Utils.pgConnection();
        //    NpgsqlCommand command;
        //    try
        //    {
        //        conn.Open();
        //        command = new NpgsqlCommand("select * from web_user where email = :email and user_password = :password ;", conn);
        //        command.Parameters.Add(new NpgsqlParameter(":password", user.password));
        //        command.Parameters.Add(new NpgsqlParameter(":email", user.email));               
        //        NpgsqlDataReader reader = command.ExecuteReader();
        //        if (reader.Read())
        //        {
        //           return LoadUser(reader, user);                    
        //        }
        //    }
        //    catch (NpgsqlException e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return null;
        //}
        private User LoadUser(NpgsqlDataReader reader, User user)
        {
            try
            {
                user.id = reader.GetInt32(0);
                user.nombreProyecto = reader.GetString(1);
                user.comentario = reader.GetString(2);
            }
            catch (Exception)
            {
                return null;
            }
            return user;
        }

        //private List<User> buildUserList(NpgsqlCommand command)
        //{
        //    NpgsqlDataReader dataReader;
        //    try
        //    {
        //        dataReader = command.ExecuteReader();
        //    }
        //    catch (NpgsqlException e)
        //    {
        //        throw e;
        //    }
        //    List<User> userList = new List<User>();
        //    User user;
        //    while (dataReader.Read())
        //    {
        //        user = new User(dataReader[0].ToString(), dataReader[1].ToString());
        //        userList.Add(user);
        //    }
        //    return userList;
        //}
    }
}