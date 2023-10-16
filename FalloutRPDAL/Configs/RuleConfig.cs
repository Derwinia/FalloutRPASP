using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FalloutRPDAL.Entities;

namespace FalloutRPDAL.Configs
{
    internal class RuleConfig : IEntityTypeConfiguration<Rule>
    {
        public void Configure(EntityTypeBuilder<Rule> builder)
        {

        }
    }
}
