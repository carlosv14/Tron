Feature: GameLogic
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Correct File Format
	Given I have a file named 'commands.txt'
	And The content of the file is 'Player1,Red;Player2,Blue|Player1:U,Player2:D'
	When I parse the file
	Then the result should be
	| Players       | Commands  |
	| Player1 Red   | Player1:U |
	| Player2 Blue  | Player2:D |

Scenario: Collide with itself
	Given The commands are given in the file are
	| Player	  | Command   |
	| Player1 Red | Player1:R |
	| Player1 Red | Player1:D |
	| Player1 Red | Player1:L |
	| Player1 Red | Player1:U |
	When I execute the game
	Then the loser should be 'Player1'

Scenario: Collide with oponent
	Given The commands are given in the file are
	| Player	  | Command   |
	| Player1 Red | Player1:R |
	| Player1 Red | Player1:R |
	| Player1 Red | Player1:R |
	| Player1 Red | Player1:R |
	| Player1 Red | Player1:R |
	| Player1 Red | Player1:R |
	| Player1 Red | Player1:R |
	| Player1 Red | Player1:R |
	| Player1 Red | Player1:R |
	| Player1 Red | Player1:D |
	| Player1 Red | Player1:D |
	| Player1 Red | Player1:D |
	| Player1 Red | Player1:D |
	| Player1 Red | Player1:D |
	| Player1 Red | Player1:D |
	| Player1 Red | Player1:D |
	| Player1 Red | Player1:D |
	| Player1 Red | Player1:D |
	When I execute the game
	Then the loser should be 'Player1'
	
Scenario: Tie
	Given The commands are given in the file are
	| Player	  | Command   |
	| Player1 Red | Player1:R |
	| Player2 Blue| Player2:U |
	When I execute the game
	Then the loser should be ''
