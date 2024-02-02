# LispThingIdk
 My first experience with functional Programming. I am trying to make a functional Programming Language in the spirit of Lisp. My goal is not to make a full clone of Lisp but rather to make my own thing, but making use of the bracket-heavy Lisp syntax, and a comparible list based evaluation system. I got the idea when I realised that I can make a <string, Func> Dictionary in C#, which would allow me to map a function name to predefined functionality, but be very easy to extend and would not need a giant switch-case like MaximumBrainfuck. 
 While writing this I just finished a huge update to the basic system of parsing the user input by actually making use of lists instead of recursively editing a string. Now the system should be flexible enough for me to add stuff like custom functions and recursion in the future.

# About Functions
Functions currently have to be written Lisk style, aka. with the function name first. This will be made optional in future versions, but at the moment it is mandatory. 
Functions work a bit like they do in APL, being grouped as monadic and diadic, meaning either one or two input arguments. In APL the arguments are called Alpha and Omega, which they are within the Evaluater class in the code, but in the README they will be refered to as 'a' and 'b' respectively 

# Monadic functions

## (Int) -> Int
- (? a) Print a as Line to the Console (? derived from BASIC)
- (^ a) a squared

## (Bool) -> Bool
- (? a) Print a as Line to the Console (? derived from BASIC)
- (! a) not a

## (String) -> String
- (? a) Print a as Line to the Console (? derived from BASIC)
- (get a) Gets the value of the variable with the name a


# Diadic functions

## (Int, Int) -> Int
- (+ a b) a plus b
- (- a b) a muinus b
- (* a b) a times b
- (/ a b) a divided by b
- (% a b) a modulo b    
- (^ a b) a to the power of b 

## (Int, Int) -> Bool
- (< a b) a less than b
- (> a b) a greater than b
- (= a b) a equals than b
- (!= a b) a unequals than b

## (Bool, Bool) -> Bool
- (& a b) a and b
- (| a b) a or b
- (§ a b) a xor b

## (String, String) -> String
- (+ a b) a concatenated with b

## (String, Int) -> Int
- (var a b) define variable a with value b
- (set a b) set the value of variable a to b

## (Bool, String) -> String
- (if a b) returns expression b if a equals true, else returns empty string

# Work In Progress
## (String, String) -> String
- (def a b) define constant a with value b 
- (fn a b) define a function a with the logic b

## (String) -> String
- (get a) Gets the value of the constnt a 

# Ideas for the future
- In/Decrement variables with ++/-- (Mon & Dia)
- Generate Arrays and drop from start with $ and € (Mon)
- More String stuff (-, /, *, =) (Dia)
- Import functions from other files (use "Path") (Mon)
- no loop, but make functions able to be recursive