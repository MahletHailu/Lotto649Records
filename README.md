# Lotto649Records

# Description

A web app that allows users input 6 unique numbers from 1 upto 49 and checks those 
numbers against all of the BCLC’s 6/49 lotto numbers since 1981, and reports back to the user an 
estimate of dates they won, how much they won and total amount of money they spent.

This applicatio has three main parts.

1. Database
2. Service
3. Client

I used Asp.Net Core with-React project template where both the service and the client are included in one solution. I chose to do this because it is a very simple app and it'd be okay to deploy both client and service together for this challenge. But in real world applications the best practice is to have separate client and service that are hosted and managed independent of eachother which makes future customaizations very easy.

# 1. Database

For this project I created a MS SQL database and hosted it in Azure. All historical records of past draws in csv format is migrated to a table 'HistoricalDraws'. For the ease of mmapping this table to domain models (objects), I used Entty frame work. I realized that Entity fraimwork is an over kill for such a small database and I wish I used Dapper or other light weight tools instead.

 # 2. Service

The service is an Asp.net core rest WebAPI. It has a post endpoint that accepts 6 numbers and outputs result in a JSON format.

To test the endPoint that hosted in Azure:

url: https://lotto649records20220212144238.azurewebsites.net/api/Lotto649Records/ProcessNumbers

Method: Post

sample body :

{

    "number1": "1",
    
    "number2": "2",
    
    "number3": "3",
    
    "number4": "4",
    
    "number5": "5",
    
    "number6": "6"
    
}


Result for the example input above

{

    "matchedDraws": [
    
        {
        
            "drawNumber": 883,
            
            "drawDate": "1992-07-08T00:00:00",
            
            "matchCount": 4,
            
            "won": 85.0
            
        },
        
        {
        
            "drawNumber": 3323,
            
            "drawDate": "2015-11-25T00:00:00",
            
            "matchCount": 4,
            
            "won": 85.0
            
        }
        
    ],
    
    "totalWon": 170.0,
    
    "totalCost": 5981.0
    
}



# Matched Draws 

contains a list of historical draws that are worth of $85 or more. To be a valid matched draw, atleast 4 of the input numbers out of the 6 must match.

# Total Won: 

This is the sum of all money won.

# Total Cost: 

The total cost of how much they spent in total on the 3,620 draws. Cost depends on draw number/date.

# Net won/loss:

The difference of total won and total cost.

# Note:

I ignored any data from the csv file where draw number > 3,620 as the instruction explicitely mentioned to include draws with draw number 1 - 3620 only.

# Client

The client app is developed in React Js. I also used Material UI controls.

# Testing 
  
 There is a separate project under 'Domains' folder to test Models and services in the 'Domain' project. I may have missed to cover all code but we should always to aim atleast 80% coverage. We can use tools like 'FineCodeCoveage' to show test code coverage for our projects. 

# Error Handling
 
    Validations and errors have been handled on the service. What I would like to add is to map all errors to appropriate http request statuses. Http statuses can easily inform the user if the error is from an invalid input or just an internal server errror. 
    
    I didn't have to add error handling on the client but I made sure user entries are valid. 
 
 # Documentation
  
     Documentation comments have been added to API endpoint methods, models and their properties manually. What I would lik to add is create a API specification documentaion in      detail using tools like Swagger. 
     
 # Tools used
   
      Visual Studio Code, Visual Studio 2019, MS SQL Management tool, Asure DevOps, Azure AppService
