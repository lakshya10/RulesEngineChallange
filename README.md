# RulesEngineChallange
How to run the program?

Give the two arguments for running the code. First argument should be raw_data.json path and second one should be rules.txt file path.

Conceptual Approach:
Defined rule format for each value type.Rules are fetched and stored into the memory from the text file. Data is read from input stream and rules for that signal are applied iteratively. If the data point does not satisy the rule then surce name will be printed to console.

Runtime Performance:
This depends on the number of rules defined for each source.

Possible Improvements:
If the rule size increase, it is not feasible to store them into memory. So they can be stored in database with source name indexed.
So this will result in faster read of the rules. Rest API's can be introduced to indroduce new rules and updating existing one's.


Sample rules:

SOURCE1 value should be greater_than 20

SOURCE1 value should be less_than 100

SOURCE2 value should be equal_to LOW

SOURCE3 value should be in future

SOURCE4 value should be in past

Sample json data:
[
{
    "signal": "SOURCE2",
    "value_type": "String",
    "value": "HIGH"
  },
  {
    "signal": "SOURCE3",
    "value_type": "Datetime",
    "value": "2020-06-13 22:40:10"
  },
  {
    "signal": "SOURCE2",
    "value_type": "String",
    "value": "LOW"
  },
  {
    "signal": "SOURCE1",
    "value_type": "Integer",
    "value": "30"
  },
  {
    "signal": "SOURCE1",
    "value_type": "Integer",
    "value": "15"
  },{
    "signal": "SOURCE4",
    "value_type": "Datetime",
    "value": "2019-10-13 22:40:10"
  }
  ]
  
  
  
  
