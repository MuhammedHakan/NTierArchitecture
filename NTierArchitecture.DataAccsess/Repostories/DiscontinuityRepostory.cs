using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.DataAccsess.Repostories;

public class DiscontinuityRepostory(AppDbContext context) : GenericRepostory<Discontinuity>(context);
