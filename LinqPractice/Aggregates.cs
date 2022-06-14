using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqPractice
{
    [TestClass]
    public class Aggregates
    {
        /// <summary>
        /// H ����� ��� ���������� Aggregate ������ �-1 ����� ��� � ��������
        /// - ��� ����� ���� �� ������� �� 1� ��� �� 2� �������� ���� ��������� � ��� � ����������
        /// - �� 2� ���� �� ����� ��� ��������� � �� ���������� ��� 1�� ��������� ��� ��� ��������� � �� 3� �������� 
        /// - �� �� ���� (���� � > 1) �� ����� ��� ��������� � �� ���������� ��� ��������� �-1 ��� ��� ��������� � �� �������� �+1
        /// </summary>
        [TestMethod]
        public void SimpleAggregate()
        {
            var seq = new int[] { 1, 2, 3, 4, 5 };
            var iterations = string.Empty;
            var i = 1;
            var g = seq.Aggregate((a, b) => 
            {
                var ret = a + b;
                iterations += $"iteration:{i}, a={a}, b={b}, ret={ret}{System.Environment.NewLine}";
                i++;
                return a + b;
            });
            Assert.AreEqual(15, g);
            var expectedIterations = @"
iteration:1, a=1, b=2, ret=3
iteration:2, a=3, b=3, ret=6
iteration:3, a=6, b=4, ret=10
iteration:4, a=10, b=5, ret=15";
            Assert.AreEqual(expectedIterations.Trim(), iterations.Trim());
        }

        /// <summary>
        /// H ������� Aggregate (�� ��������������) ������ � ����� ��� � ��������
        /// - �� ������ ��� ��������������� ��� ���� � ������������� ��� ���� �+1
        /// - ��� �� ����� ���� ��������������� � "������" seed ��' ���� ��� � ������������ Aggregate ������� ��� ��������
        /// (�� ����� ����� � ������)
        /// </summary>
        [TestMethod]
        public void AggregateWithTransformation()
        {
            var seq = new int[] { 1, 2, 3, 4, 5 };
            var iterations = string.Empty;
            var i = 1;
            var result = seq.Aggregate(string.Empty, (conc, item) =>
            {
                var ret = conc + item.ToString();
                iterations += $"iteration:{i}, acc={conc}, item={item}, ret={ret}{System.Environment.NewLine}";
                i++;
                return conc + item.ToString();
            });
            Assert.AreEqual("12345", result);
            var expectedIterations = @"
iteration:1, acc=, item=1, ret=1
iteration:2, acc=1, item=2, ret=12
iteration:3, acc=12, item=3, ret=123
iteration:4, acc=123, item=4, ret=1234
iteration:5, acc=1234, item=5, ret=12345";
            Assert.AreEqual(expectedIterations.Trim(), iterations.Trim());
        }

        /// <summary>
        /// � ��������� ����������� ��� Aggregate ����� ������ �������. ���� ��� � 2� ��������� ��� ������� �� ������ ������ ��� ���� ��� �����.
        /// ����� ������ �� ���� �� �� �� �� ������ ����� ��� Aggregate.
        /// </summary>
        [TestMethod]
        public void AggregateLast()
        {
            var seq = new int[] { 1, 2, 3, 4, 5 };
            var iterations = string.Empty;
            var resultSelectorIterations = string.Empty;
            var i = 1;
            var r = 1;
            var result = seq.Aggregate(string.Empty, (conc, item) =>
            {
                var ret = conc + item.ToString();
                iterations += $"iteration:{i}, acc={conc}, item={item}, ret={ret}{System.Environment.NewLine}";
                i++;
                return conc + item.ToString();
            }, a =>
            {
                resultSelectorIterations += r + System.Environment.NewLine;
                return a.Length;
            });
            Assert.AreEqual(5, result);
            var expectedIterations = @"
iteration:1, acc=, item=1, ret=1
iteration:2, acc=1, item=2, ret=12
iteration:3, acc=12, item=3, ret=123
iteration:4, acc=123, item=4, ret=1234
iteration:5, acc=1234, item=5, ret=12345";
            Assert.AreEqual(expectedIterations.Trim(), iterations.Trim());
            Assert.AreEqual("1", resultSelectorIterations.Trim());
        }
    }
}
