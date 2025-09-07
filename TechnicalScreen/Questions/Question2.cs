namespace Questions;

public class Question2
{
    public const string PALINDROME = "Palindrome";
    public const string NOT_PALINDROME = "Not Palindrome";

    public Question2()
    {
    }

    public string DeterminePalindrome(string input)
    {
        //validate input first because we don't want to return an answer for invalid inputs
        if (input == null) {
            throw new ArgumentNullException($"{nameof(input)} cannot be null.");
        }
        
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException($"{nameof(input)} cannot be empty.");
        }

        return IsPalindrome(input)
            ? PALINDROME
            : NOT_PALINDROME;
    }

    private bool IsPalindrome(string input)
    {
        //check if is palindrome.  
        //  I am including spaces in the check but we could just as easily ignore spaces, 
        //      or we could include a flag that lets the user choose.            
        //  I chose to ignore case.  this could be set with a flag later
        //These were just assumptions I made. Normally this would be a case where I would ask the product owner for clarification
        string inputReversed = new string(input.ToCharArray().Reverse().ToArray());

        return string.Equals(inputReversed, input, StringComparison.InvariantCultureIgnoreCase);
    }
}