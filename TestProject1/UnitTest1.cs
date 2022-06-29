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
        /// ��������, ��� ��������� �������� ������� ������� ���������� ����� � �������
        /// </summary>
        [Test]
        public void TestInputStringIsCorrect()
        {
           CheckingCharacters checkingCharacters = new CheckingCharacters();

            Assert.That(checkingCharacters.CheckValue("2+2"), Does.Contain("2+2"));
        }

        /// <summary>
        /// �������� ����. ���� ������������ ������ ������, �������� ���
        /// � ������� ����������� ��������, �� ��������� ��������������� ���������
        /// </summary>
        [Test]
        public void TestInputStringNotCorrect()
        {
           CheckingCharacters checkingCharacters = new CheckingCharacters();

            Assert.That(checkingCharacters.CheckValue("h"), Does.Contain("������������ �������� ������"));
        }

        /// <summary>
        /// ��������, ����� � ������ ������ ������ ��������.
        /// � ���������, �� ������ ������ �� ����� ��������,
        /// ��� ����� ��������� ���������, ���� � ������ ������� ������������� �����.
        /// </summary>
        [Test]
        public void TestInputStringMinusOrAnotherFirst()
        {
           CheckingCharacters checkingCharacters = new CheckingCharacters();

            Assert.That(checkingCharacters.CheckValue("+5"), Does.Contain("��������. ���� '+' �� ����� ���� � ������"));
        }

        /// <summary>
        /// �������� ������������ �����������. ���� �� ��� ���
        /// �� � ����� ������ ��, ��� �������� ������
        /// </summary>
        public void TestConvertToNotation()
        {
            ExpressionConverter expressionConverter = new ExpressionConverter();

            Assert.That(expressionConverter.Expression("5+6/(5*7)+10"), Does.Contain("5 6 5 7 * / 10 + +"));
        }

        /// <summary>
        /// �������� ������ ��������� ������.
        /// </summary>
        [Test]
        public void NotationTestSuccess()
        {
            Calculate calculate = new Calculate();
            Assert.AreEqual(15.171428571428571d, calculate.Counting("5 6 5 7 * / 10 + +"));
        }

        /// <summary>
        /// �������� ������ ��������� ������ � ����� ������� ����������.
        /// </summary>
        [Test]
        public void NotationTestSuccessHarder()
        {
            Calculate calculate = new Calculate();

            Assert.AreEqual(100005.17142857143d, calculate.Counting("5 6 5 7 * / 10 5 ^ + +"));
        }
    }
}