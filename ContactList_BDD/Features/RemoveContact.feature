Feature: RemoveContact

This feature is used to test when user login with valid email and valid password and 
then remove the contact from the list.

@End-To-End-Login-And-RemoveContact
Scenario: User login and view the details of contact entered and delete one contact from the list.
	Given User is in the Herokuapp Login Page
	When User Enter a correct email in the input box '<LoginEmail>'
	When User Enter a correct password in the input box '<Password>'
	Then User redirect to the My Contacts Page
	When User click on the first contact detail
	Then User will redirect to Contact details page
	When User click on the Delete Contact Button
	Then User will got a PopUp message to delete the contact
	Then User will back to the page

Examples:
	| LoginEmail             | Password     |
	| dineshraj123@gmail.com | Dinesh@12345 |
