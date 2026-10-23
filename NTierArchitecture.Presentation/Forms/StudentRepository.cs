using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.DataAccsess.Repostories;

namespace NTierArchitecture.Presentation.Forms
{
    internal class StudentRepository : StudentRepostory
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
    }
}