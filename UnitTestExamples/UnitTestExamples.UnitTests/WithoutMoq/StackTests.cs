using Fundamentals.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestExamples.UnitTests.WithoutMoq
{
    [TestClass]
    public class StackTests
    {
        private Fundamentals.WithoutMoq.Stack<Employee> _stack;

        [TestInitialize]
        public void Setup()
        {
            _stack = new Fundamentals.WithoutMoq.Stack<Employee>();
        }

        [TestCleanup]
        public void Flush()
        {
            _stack = null;
        }

        [TestMethod]
        public void Count_IntialCountIsZero_ReturnsZero()
        {
            Assert.AreEqual(0, _stack.Count);
        }

        [TestMethod]
        public void Push_PassNullObject_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _stack.Push(null));
        }

        [TestMethod]
        public void Push_PassEmployeeObject_CountShouldBeIncreasedBy1()
        {
            _stack.Push(new Employee { Id = 1});

            Assert.AreEqual(1, _stack.Count);
        }

        [TestMethod]
        public void Pop_PopEmptyStack_ThrowsInvalidOperationException()
        {
            Assert.ThrowsException<InvalidOperationException>(() => _stack.Pop());
        }

        [TestMethod]
        public void Pop_PopAObject_GetTheSamePushedObject()
        {
            //Push one object first.
            Employee employee = new Employee { Id = 1 };
            _stack.Push(employee);

            //now pop the object so that we can verify that whether we get the same object or not.
            var _employee = _stack.Pop();

            Assert.AreSame(employee, _employee);
        }

        [TestMethod]
        public void Pop_PopAObject_ObjectShouldBeRemovedFromStack()
        {
            //Push one object first.
            Employee employee = new Employee { Id = 1 };
            _stack.Push(employee);

            //now pop the object so that we can check whether the count is set to zero or not.
            _stack.Pop();

            Assert.AreEqual(0, _stack.Count);
        }

        [TestMethod]
        public void Peek_PeekEmptyStack_ThrowsInvalidOperationException()
        {
            Assert.ThrowsException<InvalidOperationException>(() => _stack.Peek());
        }

        [TestMethod]
        public void Peek_PeekAObject_GetsTheLastAddedObject()
        {
            //Here we are going to add 2 eployee objects.
            Employee employee1 = new Employee { Id = 1 };
            _stack.Push(employee1);

            Employee employee2 = new Employee { Id = 1 };
            _stack.Push(employee2);

            //now peek and check whether the peek object is the same or not.
            var _employee = _stack.Peek();

            Assert.AreSame(employee2, _employee);
        }

        [TestMethod]
        public void Peek_PeekAObject_TheObjectShouldNotBeRemovedFromStack()
        {
            //Here we are going to add 2 eployee objects.
            Employee employee1 = new Employee { Id = 1 };
            _stack.Push(employee1);

            Employee employee2 = new Employee { Id = 1 };
            _stack.Push(employee2);

            //now peek and check whether the count is still the same or not.
            _stack.Peek();

            Assert.AreEqual(2, _stack.Count);
        }
    }
}
