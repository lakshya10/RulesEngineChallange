using Newtonsoft.Json;
using RuleEngineChallenge.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngineChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0]; 
            string rulefilePath = args[1];
            Dictionary<string, List<Rule>> rules = ReadRules(rulefilePath);
            ReadJsonDataFile(filePath, rules);
            Console.ReadLine();

        }

        private static void ReadJsonDataFile(string filePath, Dictionary<string, List<Rule>> rules)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        // Load each object from the stream and do something with it
                        Newtonsoft.Json.Linq.JObject obj = Newtonsoft.Json.Linq.JObject.Load(reader);
                        Variable v = new Variable(Convert.ToString(obj.GetValue("signal")),
                            Convert.ToString(obj.GetValue("value")),
                            Convert.ToString(obj.GetValue("value_type")));
                        if (!rules.ContainsKey(v.Signal))
                        {
                            continue;
                        }
                        List<Rule> signalRules = rules[v.Signal];

                        foreach (Rule r in signalRules)
                        {
                            if (v.ValueType == "Integer")
                            {
                                ProcessIntegerValueType(r,v);
                            }
                            else if (v.ValueType == "String")
                            {
                                ProcessStringValueType(r,v);
                            }
                            else if (v.ValueType == "Datetime")
                            {
                                ProcessDateTimeValueType(r,v);                               
                            }
                        }

                    }
                }
            }
        }

        private static void ProcessIntegerValueType(Rule r, Variable v)
        {
            if (r.ComparisonOperator == "greater_than")
            {
                if (Convert.ToInt32(r.TargetValue) > Convert.ToInt32(v.Value))
                {
                    Console.WriteLine(v.Signal);
                }
            }
            else if (r.ComparisonOperator == "less_than")
            {
                if (Convert.ToInt32(r.TargetValue) < Convert.ToInt32(v.Value))
                {
                    Console.WriteLine(v.Signal);
                }
            }
        }

        private static void ProcessStringValueType(Rule r, Variable v)
        {
            if (r.ComparisonOperator == "equal_to")
            {
                if (r.TargetValue != v.Value)
                {
                    Console.WriteLine(v.Signal);
                }
            }
            else if (r.ComparisonOperator == "not_equal_to")
            {
                if (r.TargetValue == v.Value)
                {
                    Console.WriteLine(v.Signal);
                }
            }
        }

        private static void ProcessDateTimeValueType(Rule r,Variable v)
        {
            if (r.ComparisonOperator == "in" && r.TargetValue == "future")
            {
                if (Convert.ToDateTime(v.Value) < DateTime.Now)
                {
                    Console.WriteLine(v.Signal);
                }
            }
            else if (r.ComparisonOperator == "in" && r.TargetValue == "past")
            {
                if (Convert.ToDateTime(v.Value) > DateTime.Now)
                {
                    Console.WriteLine(v.Signal);
                }
            }
        }

        private static Dictionary<string, List<Rule>> ReadRules(string filePath)
        {
            var ruleList = new List<string>(File.ReadAllLines(filePath));
            Dictionary<string, List<Rule>> dict = new Dictionary<string, List<Rule>>();
            List<Rule> list = new List<Rule>();

            foreach (var j in ruleList)
            {
                Rule ruleObj = new Rule();
                string[] str = j.Split(' ');

                ruleObj.Source = str.First();
                if (str.Contains("be"))
                {
                    ruleObj.ComparisonOperator = str[Array.IndexOf(str, "be") + 1];
                    ruleObj.TargetValue = str.Last();
                }
                else
                {
                    Console.WriteLine("Invalid Rule");
                    return null;
                }
                if (!dict.ContainsKey(ruleObj.Source))
                {
                    list = new List<Rule>();
                    dict.Add(ruleObj.Source, list);
                }
                else
                {
                    list = dict[ruleObj.Source];
                }
                list.Add(ruleObj);
            }
            return dict;
        }
    }
}
