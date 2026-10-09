using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.DataAccsess.Repostories;

public class TeacherRepostory(AppDbContext context) : GenericRepostory<Teacher>(context);
