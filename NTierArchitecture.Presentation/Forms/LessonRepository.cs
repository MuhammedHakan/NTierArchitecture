using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.DataAccsess.Repostories;

namespace NTierArchitecture.Presentation.Forms
{
    internal class LessonRepository : LessonRepostory
    {
        public LessonRepository(AppDbContext context) : base(context)
        {
        }
    }
}