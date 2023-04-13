using ABET_assessment_api.DataContext;
using ABET_assessment_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ABET_assessment_api.Services.UserServices
{
    public class UserServices 
    {
        ////private readonly Context _context;

        ////public UserServices(Context context)
        ////{
        ////    this._context = context;
        ////}

        ////public async Task<SuccessResponse> AddUser(User user)
        ////{
        ////    //    // Validate user object using DataAnnotations
        ////    //    var context = new ValidationContext(user);
        ////    //    Validator.ValidateObject(user, context, validateAllProperties: true);

        ////    //    // Hash the password before storing
        ////    //    user.HashPassword();

        ////    //    // Add user to the database
        ////    //    _context.Users.Add(user);
        ////    //    _context.SaveChanges();

        ////    //// Return the created user object
        ////    //return new SuccessResponse
        ////    //{
        ////    //    IsSuccess= true,
        ////    //    ResponseMessage = "Added user successfully"
        ////    //};
        ////    return null;
   
        ////}

        ////public Task<SuccessResponse> DeleteUser(int id)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public Task<SuccessResponse> EditUser(int id, [FromForm] User request)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public async Task<ActionResult<User>> GetUser(int id)
        ////{
        ////    var user = _context.Users.Find(id);

        ////    if (user == null)
        ////    {
        ////        // Return a 404 response if user is not found
        ////        return null;
        ////    }

        ////    // Hide the password hash from the response
        ////    user.PasswordHash = null;

        ////    // Return the user object
        ////    return user;
        ////}
    }
}
