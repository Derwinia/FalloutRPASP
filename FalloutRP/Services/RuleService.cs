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

        public IEnumerable<Rule> GetAllRules()
        {
            List<Rule> Rules = new List<Rule>();
            List<Rule> RulesList = _falloutRPContext.Rules.OrderBy(t=>t.Order).ToList();
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

        public void UpdateRuleOrder(RuleOrderDTO ruleOrderDTO)
        {
            Rule[] rulesToChange;
            if (ruleOrderDTO.PreviousOrder < ruleOrderDTO.CurrentOrder)
            {
                rulesToChange = _falloutRPContext.Rules.Where(r => r.Order >= ruleOrderDTO.PreviousOrder && r.Order <= ruleOrderDTO.CurrentOrder).ToArray();
                if (rulesToChange == null)
                {
                    throw new KeyNotFoundException("Ces rêgles n'existent pas");
                }
                foreach (Rule ruleToChange in rulesToChange)
                {
                    if (ruleToChange.Order == ruleOrderDTO.PreviousOrder) ruleToChange.Order = ruleOrderDTO.CurrentOrder;
                    else ruleToChange.Order--;
                    _falloutRPContext.Update(ruleToChange);
                }
            }
            else
            {
                rulesToChange = _falloutRPContext.Rules.Where(r => r.Order <= ruleOrderDTO.PreviousOrder && r.Order >= ruleOrderDTO.CurrentOrder).ToArray();
                if (rulesToChange == null)
                {
                    throw new KeyNotFoundException("Ces rêgles n'existent pas");
                }
                foreach (Rule ruleToChange in rulesToChange)
                {
                    if (ruleToChange.Order == ruleOrderDTO.PreviousOrder) ruleToChange.Order = ruleOrderDTO.CurrentOrder;
                    else ruleToChange.Order++;
                    _falloutRPContext.Update(ruleToChange);
                }
            }
            _falloutRPContext.SaveChanges();
        }

        public void DeleteRule(string id)
        {
            Rule? rule = null;
            if(int.TryParse(id, out int idInt))
            {
                rule = _falloutRPContext.Rules.FirstOrDefault(r => r.Id == idInt);
            }
            if (rule == null)
            {
                throw new KeyNotFoundException("Cette règle n'existe pas");
            }

            Rule[] rulesToChange = _falloutRPContext.Rules.Where(r => r.Order > rule.Order).ToArray();
            foreach (Rule ruleToChange in rulesToChange)
            {
                ruleToChange.Order--;
                _falloutRPContext.Update(ruleToChange);
            }

            _falloutRPContext.Rules.Remove(rule);

            _falloutRPContext.SaveChanges();
        }
    }
}
