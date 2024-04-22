Feature: Search Dashboard
		 As an User
		 I want be able to filtered dashboards by name


Scenario Outline: An User filter dashboards with specified filter - check if dashboard was filtered
	Given an User successful login
	When an User filtering a dashboard with <filter>
	Then check a result of filtering with <expectedResult>

	Examples: 
	| filter       | expectedResult |
	| 785          | true           |
	| #$%          | true           |
	| SUJddda      | true           |
	| Non-esistent | true           |
	| 1            | false          |
