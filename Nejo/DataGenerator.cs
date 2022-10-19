namespace Nejo
{
    public class DataGenerator
    {
        public System.Collections.Generic.List<CustomClass.SuggestedData> GenerateData(decimal _quantity)
        {
            try
            {
                System.Collections.Generic.List<CustomClass.SuggestedData> _createdData = new System.Collections.Generic.List<CustomClass.SuggestedData>();
                for (int i = 0; i < _quantity; i++)
                {
                    ///noted that: in 100+ rows generated some values gere duplicated, then modified for ensuring that:
                    ///max. 15 characters
                    ///prob. of grab duplicated rows is huge reduced.
                    string _userName = string.Format("{0}{1}{2}{3}",
                            new System.Random().Next(1, 9000).ToString(),
                            new PasswordGenerator.Password(true, true, true, false, 4).Next(),
                            new PasswordGenerator.Password(true, true, true, false, 4).Next(),
                            new PasswordGenerator.Password(true, true, true, false, 4).Next());

                    string _screenName = string.Format("{0}{1}{2}{3}",
                            new System.Random().Next(1, 9000).ToString(),
                            new PasswordGenerator.Password(true, true, true, false, 4).Next(),
                            new PasswordGenerator.Password(true, true, true, false, 4).Next(),
                            new PasswordGenerator.Password(true, true, true, false, 4).Next());


                    _createdData.Add(new Bogus.Faker<CustomClass.SuggestedData>()
                        .CustomInstantiator(f => new CustomClass.SuggestedData())
                        .RuleFor(u => u.Birthday, f => f.Date.Between(new System.DateTime(1980, 01, 02), new System.DateTime(2000, 01, 02)))
                        .RuleFor(u => u.UserName, f => _userName)
                        .RuleFor(u => u.Password, new PasswordGenerator.Password(true, true, true, true, 8).Next())
                        .RuleFor(u => u.ScreenName, _screenName));
                }

                return _createdData;
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }
    }
}