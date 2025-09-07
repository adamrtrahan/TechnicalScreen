namespace Questions.Tests;

public class Question1Tests
{
    [Theory]
    [InlineData("abc", "123", "a1b2c3")]
    [InlineData("TEST", "12", "T1E2ST")]
    [InlineData("TEST", "12345", "T1E2S3T45")]
    [InlineData("TEST", "", "TEST")]
    [InlineData("", "TEST", "TEST")]
    [InlineData("", "", "")]
    public void ValidInputs_ShouldReturnExpected(string input1, string input2, string expected)
    {
        //arrange
        Question1 question = new Question1();

        //act
        string result = question.Interleave(input1, input2);

        //assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void NullInput1_ThrowsArgumentNullException()
    {
        //arrange
        Question1 question = new Question1();

        //act & assert
        Assert.Throws<ArgumentNullException>(() => question.Interleave(null!, "123")); // null! is to suppress nullable warning
    }

    [Fact]
    public void NullInput2_ThrowsArgumentNullException()
    {
        //arrange
        Question1 question = new Question1();

        //act & assert
        Assert.Throws<ArgumentNullException>(() => question.Interleave("abc", null!)); // null! is to suppress nullable warning
    }
}
