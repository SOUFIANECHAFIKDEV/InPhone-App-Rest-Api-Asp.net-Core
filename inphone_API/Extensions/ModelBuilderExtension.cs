using inphone_API.Enums;
using inphone_API.Model;
using Microsoft.EntityFrameworkCore;

namespace inphone_API.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<TypeButton>().HasData(
                new TypeButton
                {
                    IdTypeButton = (int)TypeButtonEnum.Text,
                    Label = "Text",
                    Description = "(Should open the default text app of the user's phone) - and default use phone number in the setup"
                },
                new TypeButton
                {
                    IdTypeButton = (int)TypeButtonEnum.SendEmail,
                    Label = "Send email",
                    Description = "(Should open default email function from users phone)"
                },
                new TypeButton
                {
                    IdTypeButton = (int)TypeButtonEnum.Call,
                    Label = "Call",
                    Description = ""
                },
                  new TypeButton
                  {
                      IdTypeButton = (int)TypeButtonEnum.WebLink,
                      Label = "Web link",
                      Description = ""
                  }
                );
        }
    }
}
