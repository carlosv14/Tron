Feature: CorrectFile
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Correct File Format
	Given I have a file named 'commands.txt'
	And The content of the file is 'Player1,Red;Player2,Blue|Player1:U,Player2:D'
	When I parse the file
	Then the result should be
	| Players     | Commands  |
	| Player1 Red | Player1:U |
	| Player2 Blue| Player2:D |
