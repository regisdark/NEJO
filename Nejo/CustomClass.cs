namespace Nejo
{
    public class CustomClass
    {
        public class SuggestedData
        {
            public SuggestedData()
            {
            }

            public SuggestedData(System.DateTime birthday, string userName, string password, string email, string screenName)
            {
                Birthday = birthday;
                UserName = userName;
                Password = password;
                Email = email;
                ScreenName = screenName;
            }

            public System.DateTime Birthday { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string ScreenName { get; set; }

        }
    }
}
