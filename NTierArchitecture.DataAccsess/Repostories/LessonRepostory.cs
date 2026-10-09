using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.DataAccsess.Repostories;

public class LessonRepostory(AppDbContext context) : GenericRepostory<Lesson>(context);
