using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.DataAccsess.Repostories;

namespace NTierArchitecture.Presentation.Forms
{
    internal class TeacherRepository : TeacherRepostory
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {
        }
    }
}