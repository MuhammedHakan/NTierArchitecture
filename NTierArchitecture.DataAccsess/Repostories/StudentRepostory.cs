using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.DataAccsess.Repostories;

public class StudentRepostory(AppDbContext context) : GenericRepostory<Student>(context);
