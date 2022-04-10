using Microsoft.EntityFrameworkCore;
using Wasifu.BaseFrameWork;
using Wasifu.Data;
using Wasifu.Dtos;
using Wasifu.Models;
using static Wasifu.Utilities.Utilities;


namespace Wasifu.Repositories
{
    public class UserDataRepository : BaseRepository
    {
        public UserDataRepository(WasifuContext context) : base(context)
        {

        }

        public AjaxResponse SaveUserData(UserData userData)
        {
            var response = new AjaxResponse(_success: false);

            if (userData == null) return response;
            response.data = userData;
            try
            {
                if (isContextOkay)
                {
                    UserData currentuser = new UserData();
                    if (userData.ID > 0)
                    {
                        currentuser = _context.UserData.Where(x => x.ID == userData.ID).FirstOrDefault() ?? new UserData();

                    }
                    else
                    {

                        currentuser.Created = DateTime.Now;
                    }
                    if (currentuser.Email != userData.Email && ContactsInUse(userData))
                    {
                        response.Message = "User exits with contact Details";
                        return response;
                    }
                    currentuser.FirstName = userData.FirstName;
                    currentuser.JobTitle = userData.JobTitle;
                    currentuser.LastName = userData.LastName;
                    currentuser.Email = userData.Email;
                    currentuser.PhoneNumber = userData.PhoneNumber;
                    currentuser.gender = userData.gender;
                    currentuser.CityId = userData.CityId;
                    currentuser.CountryId = userData.CountryId;
                    currentuser.isActive = userData.isActive;
                    currentuser.IsDeleted = userData.IsDeleted;
                    currentuser.DeletedDate = userData.DeletedDate;

                    if (currentuser.ID > 0)
                    {
                        _context.Entry(currentuser).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.UserData.Add(currentuser);
                    }
                    _context.SaveChanges();
                    response.data = currentuser;
                    response.success = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Message = DbContextError;

                }

            }
            catch (Exception ex)
            {

                response.exeption = ex.Message;
            }
            return response;
        }

        public LoginDetails? GetUserByUserName(string username)
        {
            LoginDetails? loginDetails = null;
            try
            {
                if (isContextOkay)
                {
                    loginDetails = _context.LoginDetails.Where(x => x.Email == username).FirstOrDefault();
                }
            }
            catch (Exception)
            {

            }

            return loginDetails;
        } 
        public UserData? GetUserDataById(long Userid)
        {
            UserData? userData = null;
            try
            {
                if (isContextOkay)
                {
                    userData = _context.UserData.Where(x => x.ID == Userid).FirstOrDefault();
                }
            }
            catch (Exception)
            {

            }

            return userData;
        }

        public bool DeleteUserData(UserData userData)
        {
            try
            {

                if (isContextOkay)
                {
                    var currentUser = _context.UserData.Find(userData.ID);
                    if (currentUser != null)
                    {
                        _context.UserData.Remove(currentUser);
                        _context.SaveChanges();
                        return true;
                    }

                }
            }
            catch (Exception)
            {

            }

            return false;
        }

        private bool ContactsInUse(UserData userData)
        {
            if (isContextOkay && userData != null)
            {
                var querry = _context.UserData.Where(x => x.Email == userData.Email);
                if (userData.PhoneNumber > 0)
                {
                    querry = _context.UserData.Where(x => x.Email == userData.Email || x.PhoneNumber == userData.PhoneNumber);
                }
                return querry.Any();
            }
            return true;
        }
        public AjaxResponse SaveLoginDetails(LoginDetails userData)
        {
            var response = new AjaxResponse(_success: false);

            if (userData == null) return response;
            response.data = userData;
            try
            {
                if (isContextOkay)
                {
                    if (userData.UserDataID > 0)
                    {
                        LoginDetails currentuser = new LoginDetails();
                        if (userData.ID > 0)
                        {
                            currentuser = _context.LoginDetails.Where(x => x.ID == userData.ID).FirstOrDefault() ?? new LoginDetails();

                        }
                        else
                        {

                            currentuser.Created = DateTime.Now;
                        }
                        if (currentuser.Email != userData.Email && ContactsInUse(userData))
                        {
                            response.Message = "User exits with same Email";
                            return response;
                        }
                        currentuser.UserName = userData.UserName;
                        currentuser.Email = userData.Email;
                        currentuser.password = CalculateMD5Hash(userData.password);
                        currentuser.UserDataID = userData.UserDataID;
                        currentuser.isActive = userData.isActive;
                        currentuser.IsDeleted = userData.IsDeleted;
                        currentuser.DeletedDate = userData.DeletedDate;

                        if (currentuser.ID > 0)
                        {
                            _context.Entry(currentuser).State = EntityState.Modified;
                        }
                        else
                        {
                            _context.LoginDetails.Add(currentuser);
                        }
                        _context.SaveChanges();
                        response.data = currentuser;
                        response.success = true;
                        response.Message = "Success";
                    }
                }
                else
                {
                    response.Message = DbContextError;

                }

            }
            catch (Exception ex)
            {

                response.exeption = ex.Message;
            }
            return response;
        }

        private bool ContactsInUse(LoginDetails userData)
        {
            if (isContextOkay && userData != null)
            {
                var querry = _context.LoginDetails.Where(x => x.Email == userData.Email);

                return querry.Any();
            }
            return true;
        }

    }
}
