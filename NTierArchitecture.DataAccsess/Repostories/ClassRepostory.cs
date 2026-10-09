using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.DataAccsess.Repostories;

public class ClassRepostory(AppDbContext context) : GenericRepostory<Class>(context);