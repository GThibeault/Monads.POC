# Monads.POC
Simple POC showing the use of monads to improve handling of common scenarios in .NET Core web programming, such as error handling, logging, tracking, metric gathering and so on.

The different monads are presented as minimal POCs to showcase certain functionality; in real use some could be merged, such as the ProcessMonad and LoggerMonad, or the ValueMonad and ErrorMonad as seen in Haskell's Maybe monad. 
Some could even be baked into base functionality common to all monads.