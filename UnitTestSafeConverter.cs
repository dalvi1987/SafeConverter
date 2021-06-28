using Xunit;
using SafeConverter;

namespace TestSafeConverter
{
    public class UnitTestSafeConverter
    {
        SafeIntConverter safeConverter;
        public UnitTestSafeConverter()
        {
            safeConverter = new SafeIntConverter();
        }

        [Fact]
        public void TestSafeConverterInvalidInput()
        {
            string numberStrInput = "2112Test";
            int numberOutput = safeConverter.ToSafeInt(numberStrInput);
            Assert.True(numberOutput == 0);
        }

        [Fact]
        public void TestSafeConverterValidInput()
        {
            string numberStrInput = "100";
            int numberOutput = safeConverter.ToSafeInt(numberStrInput);
            Assert.True(numberOutput == 100);
        }

        [Fact]
        public void TestSafeConverterMaxInput()
        {
            string numberStrInput = "2147483647";
            int numberOutput = safeConverter.ToSafeInt(numberStrInput);
            Assert.True(numberOutput == 2147483647);
        }

        [Fact]
        public void TestSafeConverterMaxInputPlus1()
        {
            string numberStrInput = "2147483648";
            int numberOutput = safeConverter.ToSafeInt(numberStrInput);
            Assert.True(numberOutput == 0);
        }

        [Fact]
        public void TestSafeConverterMinInputPlus1()
        {
            string numberStrInput = "-2147483648";
            int numberOutput = safeConverter.ToSafeInt(numberStrInput);
            Assert.True(numberOutput == -2147483648);
        }

        [Fact]
        public void TestSafeConverterMinInputMinus1()
        {
            string numberStrInput = "-2147483649";
            int numberOutput = safeConverter.ToSafeInt(numberStrInput);
            Assert.True(numberOutput == 0);
        }
    }
}
