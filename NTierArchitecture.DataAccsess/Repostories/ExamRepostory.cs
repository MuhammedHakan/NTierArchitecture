using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.DataAccsess.Repostories;

public class ExamRepostory(AppDbContext context) : GenericRepostory<Exam>(context);
