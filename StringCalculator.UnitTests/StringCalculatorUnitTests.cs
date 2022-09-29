using FluentAssertions;

namespace StringCalculator.UnitTests
{
    public class StringCalculatorUnitTests
    {
        [Fact]
        public void Add_WhenEmptyString_ShouldReturnZero()
        {
            var sut = new Domain.StringCalculator();
            var result = sut.Add("");

            result.Should().Be(0);
        }

        [Fact]
        public void Add_WhenStringIsNull_ShouldReturnZero()
        {
            var sut = new Domain.StringCalculator();
            var result = sut.Add(null);

            result.Should().Be(0);
        }

        [Fact]
        public void Add_WhenMoreThenTwoNumbers_ShouldThrowArgumentException()
        {
            var sut = new Domain.StringCalculator();

            Action add = () => sut.Add("1,2,3");

            add.Should().Throw<ArgumentException>().WithMessage("*numbers*");
        }

        [Fact]
        public void Add_WhenConsecutiveCommas_ShouldThrowArgumentException()
        {
            var sut = new Domain.StringCalculator();

            Action add = () => sut.Add("1,,1");

            add.Should().Throw<ArgumentException>().WithMessage("*numbers*");
        }

        [Fact]
        public void Add_WhenContainsNonNumber_ShouldThrowArgumentException()
        {
            var sut = new Domain.StringCalculator();

            Action add = () => sut.Add("1,a");

            add.Should().Throw<ArgumentException>().WithMessage("*numbers*");
        }

        [Fact]
        public void Add_WhenValidInput_ReturnsSum()
        {
            var sut = new Domain.StringCalculator();
            var result = sut.Add("1,3");

            result.Should().Be(4);
        }
    }
}