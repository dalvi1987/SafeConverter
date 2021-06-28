using Xunit;
using SafeConverter;

namespace TestSafeConverter
{
    public class UnitTestExtSafeConverter
    {


        [Fact]
        public void TestSafeExtConverterInvalidInput()
        {
            string numberStrInput = "2112Test";
            int defaultValue = 25; 
            int numberOutput = numberStrInput.ToSafeInt(defaultValue);
            Assert.True(numberOutput == defaultValue);
        }

        [Fact]
        public void TestSafeExtConverterValidInput()
        {
            string numberStrInput = "100";
            int defaultValue = 50;
            int numberOutput = numberStrInput.ToSafeInt(defaultValue);
            Assert.True(numberOutput == 100);
        }

        [Fact]
        public void TestSafeExtConverterMaxInput()
        {
            string numberStrInput = "2147483647";
            int defaultValue = 50;
            int numberOutput = numberStrInput.ToSafeInt(defaultValue);
            Assert.True(numberOutput == 2147483647);
        }

        [Fact]
        public void TestSafeExtConverterMaxInputPlus1()
        {
            string numberStrInput = "2147483648";
            int defaultValue = 75;
            int numberOutput = numberStrInput.ToSafeInt(defaultValue);
            Assert.True(numberOutput == defaultValue);
        }

        [Fact]
        public void TestSafeExtConverterMinInputPlus1()
        {
            string numberStrInput = "-2147483648";
            int defaultValue = 100;
            int numberOutput = numberStrInput.ToSafeInt(defaultValue);
            Assert.True(numberOutput == -2147483648);
        }

        [Fact]
        public void TestSafeExtConverterMinInputMinus1()
        {
            string numberStrInput = "-2147483649";
            int defaultValue = 100;
            int numberOutput = numberStrInput.ToSafeInt(defaultValue);
            Assert.True(numberOutput == defaultValue);
        }
    }
}
