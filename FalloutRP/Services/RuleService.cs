using FalloutRPDAL.Entities;
using FalloutRPDAL;
using FalloutRP.DTO;
using FalloutRPDAL.Services;

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
        public IEnumerable<Rule> GetAllRules()
        {
            List<Rule> Rules = new List<Rule>();
            List<Rule> RulesList = _falloutRPContext.Rules.ToList();
            foreach (Rule rule in RulesList)
            {
                Rules.Add(new Rule()
                {
                    Id = rule.Id,
                    Order = rule.Order,
                    Name = rule.Name,
                    ShortDescription = rule.ShortDescription,
                    Description = rule.Description
                });
            }
            return Rules;
        }

        /// <summary>
        /// Update a rule
        /// </summary>
        /// <param name="ruleModifyDTO"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void UpdateRule(RuleModifyDTO ruleModifyDTO)
        {
            Rule? rule = _falloutRPContext.Rules.FirstOrDefault(u => u.Id == ruleModifyDTO.Id);

            if (rule == null)
            {
                throw new KeyNotFoundException("Cet utilisateur n'existe pas");
            }

            rule.Name= ruleModifyDTO.Name;
            rule.ShortDescription= ruleModifyDTO.ShortDescription;
            rule.Description= ruleModifyDTO.Description;

            _falloutRPContext.SaveChanges();
        }
    }
}
