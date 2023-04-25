using Bogus;
using Common.Core.Encryptions;
using Core.Domain;

namespace Infrastructure.Persistence.Sedding
{

    public class CommanSeed
    {
        public static List<Comment> GetComments()
        {
            return new Faker<Comment>("en")

                 .RuleFor(x => x.CreateDate, x => x.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                 .RuleFor(x => x.Content, x => x.Lorem.Text())
                 .RuleFor(x => x.Title, x => x.Lorem.Slug(10))
                 .Generate(100);

        }
        public static User GetUser()
        {
            return new User
            {
                Email = "test@gmail.com",
                Password = PasswordEncryption.Encryption("12345")

            };

        }
    }
}
