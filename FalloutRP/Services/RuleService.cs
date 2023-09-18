using FalloutRPDAL.Entities;
using FalloutRPDAL;
using FalloutRP.DTO;

namespace FalloutRP.Services
{
    public class RuleService
    {
        private readonly FalloutRPContext _falloutRPContext;
        public RuleService(FalloutRPContext falloutRPContext)
        {
            _falloutRPContext = falloutRPContext;
        }

        /// <summary>
        /// Get a simple list of all rules
        /// </summary>
        /// <returns>List of rules</returns>
        public IEnumerable<RuleSimpleDTO> GetAllRules()
        {
            List<RuleSimpleDTO> Rules = new List<RuleSimpleDTO>();
            List<Rule> RulesList = _falloutRPContext.Rules.ToList();
            foreach (Rule rule in RulesList)
            {
                Rules.Add(new RuleSimpleDTO()
                {
                    Id = rule.Id,
                    Order = rule.Order,
                    Name = rule.Name,
                    ShortDescription = rule.ShortDescription,
                });
            }
            return Rules;
        }
    }
}
