Feature: Login functionality 
![Login functionality](To validate login functionality with invalid creden.125908 PM.png)

@chrome
@smoke
Scenario Outline: To validate login functionality with invalid creden.
# Here we are passing values through examples tag

Given User launches pluralsight through "https://app.pluralsight.com/id"
When customer enters the invalid login credentials '<username>' and '<password>'
Then User should be redirected to the error page

Examples: 
 |username  |password  |
 |TestUser  |1234@567  |
        