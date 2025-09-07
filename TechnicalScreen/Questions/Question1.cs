namespace Questions;

public class Question1
{
    public Question1()
    {
    }

    public string Interleave(string input1, string input2)
    {
        //validate input first because we don't want to return an answer for invalid inputs
        if (input1 == null) {
            throw new ArgumentNullException($"{nameof(input1)} cannot be null.");
        }

        if (input2 == null) {
            throw new ArgumentNullException($"{nameof(input2)} cannot be null.");
        }

        //get the length of the largest input
        int maxLength = Math.Max(input1.Length, input2.Length);

        string results = string.Empty;
        
        for (int i = 0; i < maxLength; i++)
        {
            results += GetCharAtIndex(input1, i);
            results += GetCharAtIndex(input2, i);
        }

        return results;
    }

    private string GetCharAtIndex(string input, int index)
    {
        if (input == null || index >= input.Length)
        {
            return string.Empty;
        }

        return input[index].ToString();
    }
}
