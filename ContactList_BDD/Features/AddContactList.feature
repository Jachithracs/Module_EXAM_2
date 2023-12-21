Feature: AddContactList

This feature is used to test when user login with valid email and valid password and 
then add new contact in the list.

Background: User is in the Herokuapp Login Page

@End-To-End-Login-And-AddNewContact-ViewContactDetail
Scenario: User login and add a new contact and view the details of contact entered.

	When User Enter a correct email in the input box '<LoginEmail>'
	When User Enter a correct password in the input box '<Password>'
	Then User redirect to the My Contacts Page
	When User Clicks on the Add a New Contact Button
	Then User redirect to the Add Contact page
	When User enter the first name '<FirstName>'
	When User enter the last name '<LastName>'
	When User enter the date of birth '<DateOfBirth>'
	When User enter the email '<RegisterEmail>'
	When User enter the phone '<Phone>'
	When User enter the Address1 '<Address1>'
	When User enter the Address2 '<Address2>'
	When User enter the city '<City>'
	When User enter the state '<State>'
	When User enter the postal code '<PostalCode>'
	When User enter the country '<Country>'
	When User click on the submit button
	When User click on the first contact detail
	Then User will redirect to Contact details page

Examples: 
	| LoginEmail                  | Password     | FirstName | LastName | DateOfBirth | RegisterEmail           | Phone      | Address1 | Address2     | City      | State  | PostalCode | Country |
	| dineshraj123@gmail.com | Dinesh@12345 | Jerin     | K        | 1998-10-03  | jerin@gmail.com | 9876543210 | SN House | Dikkan Villa | Ernakulam | Kerala | 695543     | India   |

