using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DataAPI;
using BusinessLogic.Extensions;
using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;

namespace BusinessLogic.UnitTests
{
    [TestClass]
    public abstract class UnitTestBase
    {
        protected AutoMocker mocker;

        [TestInitialize]
        public void BaseSetup()
        {
            mocker = new AutoMocker();
        }

        protected TClass GetInstanceOf<TClass>()
            where TClass : class
        {
            return mocker.CreateInstance<TClass>();
        }

        protected Mock<TClass> ForMock<TClass>()
            where TClass : class
        {
            return mocker.GetMock<TClass>();
        }

        protected void SetupUnitOfWorkMocks()
        {
            
        }
    }
}
