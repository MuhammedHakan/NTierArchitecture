using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.DataAccsess.Repostories;

namespace NTierArchitecture.Presentation.Forms
{
    internal class ExamRepository : ExamRepostory
    {
        public ExamRepository(AppDbContext context) : base(context)
        {
        }
    }
}