Feature: Create Dashboard
		 As an User 
		 I want be able to create Dashboard

Background: 
	Given an User successful login

Scenario Outline: An User sent request to create a dashboard with valid name and valid description - dashboard was created 
	When an User create a dashboard with data
	| Key         | Value                    |
	| name        | 785785_Create            |
	| description | !@#$%^&*()_AASSFFFfdfdf  |
	Then a dashboard was created

Scenario Outline: An User sent request to create a dashboard with valid name and empty description - dashboard was created 
	When an User create a dashboard with data
	| Key         | Value                       |
	| name        | 45648FSUJdddasdHJHJK_Create |
	| description |                             |
	Then a dashboard was created

Scenario Outline: An User sent request to create a dashboard with valid name including symbols and valid description - dashboard was created 
	When an User create a dashboard with data
	| Key         | Value                    |
	| name        | F@#$%^&*()_Create        |
	| description | !@#$%^&*()_AASSFFFfdfdf  |
	Then a dashboard was created

Scenario Outline: An User sent request to create a dashboard with valid long name and empty description - dashboard was created 
	When an User create a dashboard with data
	| Key         | Value                    |
	| name        | Create_Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nisl justo, tincidunt id pulvinar hendrerit, vehicula in mi libero. |
	| description |																																			 |
	Then a dashboard was created

Scenario Outline: An User sent request to create a dashboard with invalid short name and description - dashboard was created 
	When an User create a dashboard with data
	| Key         | Value                    |
	| name        | AA                       |
	| description | !@#$%^&*()_AASSFFFfdfdf  |
	Then a dashboard wasn`t created