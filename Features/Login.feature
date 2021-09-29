Feature: Login function of plural sight
![Login function of plural sight](Login functionality with invalid credentials12501 PM.png)

@chrome
@smoke 
Scenario: Login functionality with invalid credentials 
Given User launches pluralsight application via "https://app.pluralsight.com/id"
When User enters login credentials 
          | username | Password |
          |Kalidass  | 1234f5678 |
Then User will be navigated to the error page
