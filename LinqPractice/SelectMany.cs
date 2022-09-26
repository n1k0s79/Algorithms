using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqPractice
{
    [TestClass]
    public class SelectMany
    {
        /// <summary>
        /// H ����� ����� ��� SelectMany ����������� ���� �� ��� ��������� ��� ������� ��� ��������� ��������������� 
        /// � ��������� ��������������� ������� ��� ���� ��������� ��� ���� ��� �������� ��� ������� ����������
        /// �� ��������� ���������� ����� ��� ��������� ��� ����������.
        /// ����� ������������ ��� ���������� �� ���
        /// �� ������ ��� ��������� ��� ������� ���������� ����� �1 + �2 + ... + ��
        ///    ���� �� ����� �� ������ ��� ��������� ��� ���������� ��� ��������� ��� �� �������� � ��� ������� ����������
        /// </summary>
        [TestMethod]
        public void SelectMany1()
        {
            var a = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var result = a.SelectMany(i => new char[] { i, i, i }).ToList();
            var expected = new char[] { 'a', 'a', 'a',     'b', 'b', 'b',     'c', 'c', 'c',     'd', 'd', 'd',     'e', 'e', 'e' };
            Assert.IsTrue(expected.SequenceEqual(result));
            Assert.AreEqual(15, result.Count);
        }

        /// <summary>
        /// H ������� ����� ��� SelectMany ����������� ���� �� ��� ��������� ��� ������� ��� ��������� ��������������� 
        /// � ��������� ��������������� ������� ��� ���� ��������� ����������� �� ���� �������� ��� ������� ���������� ���� �� �� ������ ���
        /// �� ��������� ���������� ����� ��� ��������� ��� ����������.
        /// ����� ������������ ��� ���������� �� ���
        /// �� ������ ��� ��������� ��� ������� ���������� ����� �1 + �2 + ... + ��
        ///    ���� �� ����� �� ������ ��� ��������� ��� ���������� ��� ��������� ��� �� �������� � ��� ������� ����������
        /// </summary>
        [TestMethod]
        public void SelectMany2()
        {
            var a = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var result = a.SelectMany((item, index) => new string[] { item.ToString(), index.ToString() }).ToList();
            var expected = new string[] { "a", "0",
                                          "b", "1", 
                                          "c", "2", 
                                          "d", "3",
                                          "e", "4" };
            Assert.IsTrue(expected.SequenceEqual(result));
            Assert.AreEqual(10, result.Count);
        }

        /// <summary>
        /// H ����� ����� ��� SelectMany ����������� ���� �� ��� ��������� ��� ������� ��� �����������:
        /// - ��� ��������� ��������������� � ����� ������� ��� ���� ��������� ��� ���� ��� �������� ��� ������� ����������
        /// - ��� ��������� ��������������� � ����� �������� ��� ��������:
        ///   �) �� ���� �������� ��� ������ ����������
        ///   �) �� ���� �������� ��� ����������� (��� ��� ����� ��������� ���������������) ����������
        /// �� ������ ��� ��������� ��� ������� ���������� ����� �1 + �2 + ... + ��
        ///    ���� �� ����� �� ������ ��� ��������� ��� ���������� ��� ��������� ��� �� �������� � ��� ������� ����������
        /// </summary>
        [TestMethod]
        public void SelectMany3()
        {
            var a = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var result = a.SelectMany(c => new string[] { c.ToString().ToUpper(), ((int)c).ToString()}, (c, i) => c.ToString() + i.ToString()).ToList();
            Assert.IsTrue(new string[] { "aA", "a97", "bB", "b98", "cC", "c99", "dD", "d100", "eE", "e101" }.SequenceEqual(result));
            Assert.AreEqual(10, result.Count);
        }
    }
}
