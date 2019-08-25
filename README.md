# RulesEngineChallange
How to run the program?

Give the two arguments for running the code. First argument should be raw_data.json path and second one should be rules.txt file path.

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
  
  
  
  
