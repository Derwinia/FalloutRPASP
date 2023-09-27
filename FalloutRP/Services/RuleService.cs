using FalloutRPDAL.Entities;
using FalloutRPDAL;
using FalloutRP.DTO;
using FalloutRPDAL.Services;
using System.Diagnostics;

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
        /// Create a rule
        /// </summary>
        /// <param name="ruleCreateDTO"></param>

        public void CreateRules(RuleCreateDTO ruleCreateDTO)
        {
            Rule newRule = new Rule { 
                Order = GetAllRules().Count()+1,
                Name= ruleCreateDTO.Name,
                ShortDescription= ruleCreateDTO.ShortDescription,
                Description= ruleCreateDTO.Description,
            };
            _falloutRPContext.Rules.Add(newRule);
            _falloutRPContext.SaveChanges();
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

        /// <summary>
        /// Delete a rule
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void DeleteRule(string id)
        {
            Debug.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"+id);
            int idInt = int.Parse(id);
            Rule? rule = _falloutRPContext.Rules.FirstOrDefault(u => u.Id == idInt);
            if (rule == null)
            {
                throw new KeyNotFoundException("Cette règle n'existe pas");
            }

            _falloutRPContext.Rules.Remove(rule);

            _falloutRPContext.SaveChanges();
        }
    }
}
