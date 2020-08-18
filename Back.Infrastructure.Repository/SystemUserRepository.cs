using Back.Infrastructure.Data;
using Back.Infrastructure.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Back.Infrastructure.Repository
{
    public class SystemUserRepository : ISystemUserRepository
    {
        TestDBContext context;
        public SystemUserRepository()
        {
            var context = new TestDBContext();
        }

        public IEnumerable<SystemUser> GetAll()
        {
            var context = new TestDBContext();
            var sql = "SelectAllUser";
            var systemUsers = context.SystemUser.FromSqlRaw(sql).ToList();
            return systemUsers;
        }
        public SystemUser GetByUser(SystemUser user)
        {
            using (var context = new TestDBContext())
            {
                var sql = "SelectUser @Email, @UserName, @Password, @Gender";
                var Email = new SqlParameter("@Email", user.Email);
                var UserName = new SqlParameter("@UserName", user.UserName);
                var Password = new SqlParameter("@Password", user.Password);
                var Gender = new SqlParameter("@Gender", user.GenderId);
                var spParams = new object[] { Email, UserName, Password, Gender };
                var userResult = context.SystemUser.FromSqlRaw(sql, spParams).ToList();
                return userResult.FirstOrDefault();
            }
        }
        public SystemUser GetById(int id)
        {
            using (var context = new TestDBContext())
            {
                var idParam = new SqlParameter("@Id", id);
                var user = context.SystemUser
                    .FromSqlRaw("EXEC SelectUserById @Id", idParam)
                    .ToList();
                    return user.FirstOrDefault();           
            }
        }
        public bool Insert(SystemUser user)
        {
            bool blnReturn = false;
            using (var context = new TestDBContext())
            { 
            var sql = "InsertUser @Email, @UserName, @Password, @Status, @Gender, @CreationDate";
                var Email = new SqlParameter("@Email", user.Email);
                var UserName = new SqlParameter("@UserName", user.UserName);
                var Password = new SqlParameter("@Password", user.Password);
                var Status = new SqlParameter("@Status", user.Status);
                var Gender = new SqlParameter("@Gender", user.GenderId);
                var CreationDate = new SqlParameter("@CreationDate", user.CreationDate);
                var spParams = new object[] { Email, UserName, Password, Status, Gender, CreationDate };
                context.Database.ExecuteSqlRaw(sql, spParams);
                blnReturn = true;
            }
            return blnReturn;
        }
        public bool Update(SystemUser user)
        {
            bool blnReturn = false;
            using (var context = new TestDBContext())
            {
                var sql = "UpdateUser @Id, @Email, @UserName, @Password, @Status, @Gender";
                var Id = new SqlParameter("@Id", user.Id);
                var Email = new SqlParameter("@Email", user.Email);
                var UserName = new SqlParameter("@UserName", user.UserName);
                var Password = new SqlParameter("@Password", user.Password);
                var Status = new SqlParameter("@Status", user.Status);
                var Gender = new SqlParameter("@Gender", user.GenderId);
                var spParams = new object[] { Id, Email, UserName, Password, Status, Gender };
                context.Database.ExecuteSqlRaw(sql, spParams);
                blnReturn = true;
            }
            return blnReturn;
        }
        public bool DeleteById(int id)
        {
            bool blnReturn = false;
            using (var context = new TestDBContext())
            {
                var sql = "DeleteUser @Id";
                var Id = new SqlParameter("@Id", id);
                var spParams = new object[] { Id };
                context.Database.ExecuteSqlRaw(sql, spParams);
                blnReturn = true;
            }
            return blnReturn;
        }
    }
}
