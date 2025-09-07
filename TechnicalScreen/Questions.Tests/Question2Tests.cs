namespace Questions.Tests;

public class Question2Tests
{
    [Theory]
    [InlineData("madam", Question2.PALINDROME)]
    [InlineData("step on no pets", Question2.PALINDROME)]
    [InlineData("book", Question2.NOT_PALINDROME)]
    [InlineData("1221", Question2.PALINDROME)]
    [InlineData("Step on no pets", Question2.PALINDROME)] //testing case insensitivity
    [InlineData("stepon no pets", Question2.NOT_PALINDROME)] //testing that spaces are included in the check
    public void ValidInputs_ShouldReturnExpected(string input, string expected)
    {
        //arrange
        Question2 question = new Question2();

        //act
        string result = question.DeterminePalindrome(input);

        //assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void NullInput_ThrowsArgumentNullException()
    {
        //arrange
        Question2 question = new Question2();

        //act & assert
        Assert.Throws<ArgumentNullException>(() => question.DeterminePalindrome(null!)); // null! is to suppress nullable warning
    }

    [Fact]
    public void EmptyInput_ThrowsArgumentException()
    {
        //arrange
        Question2 question = new Question2();

        //act & assert
        Assert.Throws<ArgumentException>(() => question.DeterminePalindrome(""));
    }
}
