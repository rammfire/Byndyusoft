using Applications;
using System.Diagnostics;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Проверяю, что правильно введённые символы сделают правильный вывод в консоль
        /// </summary>
        [Test]
        public void TestInputStringIsCorrect()
        {
           CheckingCharacters checkingCharacters = new CheckingCharacters();

            Assert.That(checkingCharacters.CheckValue("2+2"), Does.Contain("2+2"));
        }

        /// <summary>
        /// Проверяю ввод. Если пользователь вводит символ, которого нет
        /// в массиве разрешённых символов, то выводится соответствующее сообщение
        /// </summary>
        [Test]
        public void TestInputStringNotCorrect()
        {
           CheckingCharacters checkingCharacters = new CheckingCharacters();

            Assert.That(checkingCharacters.CheckValue("h"), Does.Contain("Присутствует неверный символ"));
        }

        /// <summary>
        /// Проверяю, чтобы в начале небыло знаков операций.
        /// К сожалению, на данный момент не решил проблему,
        /// как можно правильно посчитать, если в начале указано отрицательное число.
        /// </summary>
        [Test]
        public void TestInputStringMinusOrAnotherFirst()
        {
           CheckingCharacters checkingCharacters = new CheckingCharacters();

            Assert.That(checkingCharacters.CheckValue("+5"), Does.Contain("Извинете. Знак '+' не может быть в начале"));
        }

        /// <summary>
        /// Проверяю правильность конвертации. Если всё тип топ
        /// то в вывод попадёт то, как выглядит запись
        /// </summary>
        public void TestConvertToNotation()
        {
            ExpressionConverter expressionConverter = new ExpressionConverter();

            Assert.That(expressionConverter.Expression("5+6/(5*7)+10"), Does.Contain("5 6 5 7 * / 10 + +"));
        }

        /// <summary>
        /// Проверяю работу ключевого метода.
        /// </summary>
        [Test]
        public void NotationTestSuccess()
        {
            Calculate calculate = new Calculate();
            Assert.AreEqual(15.171428571428571d, calculate.Counting("5 6 5 7 * / 10 + +"));
        }

        /// <summary>
        /// Проверяю работу ключевого метода с более сложныи выражением.
        /// </summary>
        [Test]
        public void NotationTestSuccessHarder()
        {
            Calculate calculate = new Calculate();

            Assert.AreEqual(100005.17142857143d, calculate.Counting("5 6 5 7 * / 10 5 ^ + +"));
        }
    }
}