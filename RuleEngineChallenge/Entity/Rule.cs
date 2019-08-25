using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngineChallenge.Entity
{
    public class Rule
    {
        public string Source { get; set; }
        public string ComparisonOperator { get; set; }
        public string TargetValue { get; set; }
    }
}