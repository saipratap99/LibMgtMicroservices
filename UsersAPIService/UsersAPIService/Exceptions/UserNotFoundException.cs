﻿namespace UsersAPIService.Exceptions
{
    public class UserNotFoundException: Exception
    {
        public UserNotFoundException(string msg): base(msg)
        {

        }

    }
}
