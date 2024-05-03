Feature: Log In to Todoly

Scenario: Succesfully Login as User via GUI
	Given the user navigates to the login page
	When the user inputs correct credentials to log in
	Then the user should be succesfully logged in