Feature: Todo List

Background:
	Given the following todos:
		| Title                              | Is Completed |
		| Prepare a presentation             | Yes          |
		| Prepare a demo                     | Yes          |
		| Make your presentation interesting | No           |
		| Be handsome                        | Yes          |

Scenario: I should get incompleted todos when I make a get request
	When I make a get request to /api/TodoList
	Then It should return a list with 4 todos