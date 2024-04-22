Feature: Update Dashboard
		As an User
		I want be able to update dashboard


Scenario Outline: An User sent request to update a dashboard with data - check if dashboard was updated
	Given an User successful login
	When an User update a dashboard with <name> and <description>
	Then check a result of updating with <expectedResult>

	Examples: 
	| name         | description         | expectedResult |
	| !HKF:LD<     | UpdatedDescription  | true           |
	| !p;.d,.d     |                     | true           |
	| !Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nisl justo, tincidunt id pulvinar hendrerit, vehicula in mi libero. | UpdatedDescription    | true               |
	| !H           |		             | false          |
	| existingName | UpdatedDescription  | false          |

