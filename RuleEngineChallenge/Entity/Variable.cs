using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngineChallenge.Entity
{
    public class Variable
    {
        public Variable(string Signal,string Value,string ValueType)
        {
            this.Signal = Signal;
            this.Value = Value;
            this.ValueType = ValueType; 
        }
        public string Signal { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
    }
}