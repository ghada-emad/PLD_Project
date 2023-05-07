# PLD_Project

# the grammar file 
![Screenshot 2023-05-07 070707](https://user-images.githubusercontent.com/90005748/236657343-dd0c9b4a-ec4b-4e12-9a33-53c6ed930781.png)

## Grammar Explanation

<program> ::= Start <stat_list> End: This rule defines the <program> symbol as starting with the keyword "Start", followed by a <stat_list>, and ending with the keyword "End". It represents the structure of a program.

<stat_list> ::= <concept> | <concept> <stat_list>: The <stat_list> rule represents a list of statements or concepts. It can be a single <concept> statement or a <concept> followed by another <stat_list>. This allows for multiple statements in a program.

<concept> ::= <assign> | <if_stat> | <for_stat> | <switch_stmt>: The <concept> rule represents a concept or statement in the program. It can be an assignment statement <assign>, an if statement <if_stat>, a for loop statement <for_stat>, or a switch statement <switch_stmt>.

<assign> ::= <id> '=' <expr> ';': The <assign> rule represents an assignment statement. It consists of an <id> representing the identifier being assigned, followed by an equals sign, an <expr> representing the expression being assigned, and a semicolon to terminate the statement.

<id> ::= Id: The <id> rule represents an identifier. It is defined as "Id", indicating that it can be any valid identifier.

<expr> ::= <term> | <term> '+' <expr> | <term> '-' <expr>: The <expr> rule represents an expression. It can be a single <term>, or it can be a combination of a <term> followed by either addition or subtraction operators and another <expr>. This allows for the construction of complex arithmetic expressions.

<term> ::= <factor> | <factor> '*' <term> | <factor> '/' <term> | <factor> '%' <term>: The <term> rule represents a term in an arithmetic expression. It can be a single <factor>, or it can be a combination of a <factor> followed by multiplication, division, or modulus operators and another <term>. This allows for the hierarchy of multiplication, division, and modulus operations.

<factor> ::= <value> '++' | '--' <id> | <value>: The <factor> rule represents a factor in an arithmetic expression. It can be a <value> followed by a "++" increment operator, a "--" decrement operator followed by an <id>, or simply a <value> without any increment or decrement.

<value> ::= '(' <expr> ')' | <id> | <digit>: The <value> rule represents a value in an arithmetic expression. It can be an expression <expr> enclosed in parentheses, an <id> representing an identifier, or a <digit> representing a numeric digit.

<digit> ::= Digit: The <digit> rule represents a digit. It is defined as "Digit", indicating that it can be any valid digit.

<if_stat> ::= if '(' <cond> ')' Start <stat_list> End | if '(' <cond> ')' Start <stat_list> End else Start <stat_list> End: The <if_stat> rule represents an if statement. It starts with the keyword "if", followed by an opening parenthesis, a <cond> representing the condition, a closing parenthesis, the keyword "Start", a <stat_list> representing the statements within the if block, and finally, the keyword "End". It can also have an optional "else" block with another <stat_list> between

  
  <switch_stmt> ::= switch '(' <expr> ')' '{' <case_list> '}': The <switch_stmt> rule represents a switch statement. It starts with the keyword "switch", followed by an opening parenthesis, an <expr> representing the expression to be evaluated, a closing parenthesis, an opening brace, a <case_list> representing the list of cases, and finally, a closing brace. It provides a way to perform different actions based on the value of the expression.

<case_list> ::= <case> | <case> <case_list>: The <case_list> rule represents a list of case statements within the switch block. It can be a single <case> statement or a <case> followed by another <case_list>. This allows for multiple case statements in the switch block.

<case> ::= case <expr> ':' <stat_list> <break_stmt>: The <case> rule represents a case statement within the switch block. It starts with the keyword "case", followed by an <expr> representing the value to be compared with the switch expression, a colon, a <stat_list> representing the statements to be executed if the case matches, and finally, a <break_stmt> indicating the break statement to exit the switch block after the case is executed.

<break_stmt> ::= break ';': The <break_stmt> rule represents a break statement within a case block of the switch statement. It consists of the keyword "break" followed by a semicolon. The break statement is used to exit the switch block and continue execution from the next statement after the switch block.

 
  
# Running The Grammar
  ![Screenshot 2023-05-07 072651](https://user-images.githubusercontent.com/90005748/236657906-d0440598-5fcf-41c4-8523-5f75eaa35602.png)
![Screenshot 2023-05-07 073018](https://user-images.githubusercontent.com/90005748/236657911-4c1014ed-6f73-4dc3-bb06-5779ce8e9693.png)


