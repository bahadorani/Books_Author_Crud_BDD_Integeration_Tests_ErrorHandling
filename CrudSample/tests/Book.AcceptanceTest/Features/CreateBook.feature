Feature: CreateBook
	Book and author registration informations

Background:
	Given system error codes are following
		| Code | Description              |
		| 101  | Invalid Book Name        |
		| 102  | Invalid Author Name      |
		| 201  | Duplicate Book by Title  |
		| 202  | Duplicate Author by Name |
		

Scenario: Create Book and author, Read books
	When user create a new author with below data
		| Id | FullName         |
		| 1  | Robert C. Martin |
	And user Create a new Book with below data
		| Title                                                  | Description                                                                                                                            | Price | AuthorId |
		| Clean Code: A Handbook of Agile Software Craftsmanship | Noted software expert Robert C. Martin, presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship. | 35.25 | 1        |
	Then user get all list of all books, and filter name of "Clean Code: A Handbook of Agile Software Craftsmanship" there must be "1" result
	When user create a new author with below data
		| Id | FullName         |
		| 2  | Robert C. Martin |
	Then system responds with "202" error
	When user Create a new Book with below data
		| Title                                                  | Description                                                                                                                            | Price | AuthorId |
		| Clean Code: A Handbook of Agile Software Craftsmanship | Noted software expert Robert C. Martin, presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship. | 35.25 | 1        |
	Then system responds with "201" error


Scenario: Validate author with fullName
	When user create a new author with below data
		| Id | FullName |
		| 1  | C        |
	Then system responds with "102" error

Scenario: Validate book with Title
	When user create a new author with below data
		| Id | FullName         |
		| 1  | Robert C. Martin |
	And user Create a new Book with below data
		| Title | Description                                 | Price | AuthorId |
		| B     | A Handbook of Agile Software Craftsmanship. | 35.25 | 1        |
	Then system responds with "101" error
