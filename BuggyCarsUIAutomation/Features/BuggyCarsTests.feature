@BuggyCarsTests
Feature: BuggyCarsTests

Scenario: Verify Login to buggy cars rating as already existing customer works
	Given I login as existing user in buggy cars rating
	When I click on login button
	Then I will see login page

Scenario: Verify Login to buggy cars rating as already invalid customer fails
	Given I login as invalid user in buggy cars rating
	When I click on login button
	Then I will see login failed message "Invalid username/password"

Scenario: Verify Register a new user displays success message
	Given I click on register button on login page
	And I fill details on registration page
	When I click on register link
	Then I get a success message "Registration is successful"

Scenario: Verify popular model displays correctly on home page
	Given I click on popular make image on home page
	When I navigate back to home page
	Then I will see popular model displayed correctly

Scenario Outline: Verify registration form validation error
	Given I click on register button on login page
	And I fill details on registration page for password "<ErrorType>"
	When I click on register link
	Then I get a password error message "<ErrorMessage>"
	Examples: 
	| ErrorType       | ErrorMessage                                                                                            |
	| PasswordLength  | InvalidPasswordException: Password did not conform with policy: Password not long enough                |
	| UpperCaseLetter | InvalidPasswordException: Password did not conform with policy: Password must have uppercase characters |