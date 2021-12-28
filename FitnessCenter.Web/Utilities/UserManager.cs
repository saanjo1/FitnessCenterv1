﻿using FitnessCenter.Data.Entities;

namespace FitnessCenter.Web.Utilities.Constants
{
    public class UserManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User Get()
        {
            return _httpContextAccessor.HttpContext?.Session.GetObject<User>(Constants.LoggedUserKey);
        }

        public void SignIn(User user)
        {
            user.PasswordHash = null;
            user.PasswordSalt = null;

            _httpContextAccessor.HttpContext?.Session.SetObject(Constants.LoggedUserKey, user);
        }

        public void SignOut()
        {
            _httpContextAccessor.HttpContext?.Session.Clear();
        }

        public bool IsInRoles(params Role[] roles)
        {
            var user = Get();
            if (user == null)
                return false;

            return roles.Contains(user.Role);
        }

        public bool IsSignedIn()
        {
            return _httpContextAccessor.HttpContext?.Session.HasKey(Constants.LoggedUserKey) ?? false;
        }
    }
}