using System;
using NUnit.Framework;

namespace Mite.Tests
{
    [TestFixture]
    [Category("MapperFactory")]
    public class MiteDataFactoryTests
    {
        [Test]
        [ExpectedException(typeof(NotImplementedException))]
        public void ThrowExceptionForUnkownType()
        {
            IDataMapper<object> mapper = MiteDataMapperFactory.GetMapper<object>();
        }

        [Test]
        public void GetMapperForUser()
        {
            IDataMapper<User> mapper = MiteDataMapperFactory.GetMapper<User>();

            Assert.IsInstanceOfType(typeof(IDataMapper<User>),mapper);
        }

        [Test]
        public void GetMapperForTimeEntry()
        {
            IDataMapper<TimeEntry> mapper = MiteDataMapperFactory.GetMapper<TimeEntry>();

            Assert.IsInstanceOfType(typeof(IDataMapper<TimeEntry>), mapper);
        }

        [Test]
        public void GetMapperForService()
        {
            IDataMapper<Service> mapper = MiteDataMapperFactory.GetMapper<Service>();

            Assert.IsInstanceOfType(typeof(IDataMapper<Service>), mapper);
        }

        [Test]
        public void GetMapperForProject()
        {
            IDataMapper<Project> mapper = MiteDataMapperFactory.GetMapper<Project>();

            Assert.IsInstanceOfType(typeof(IDataMapper<Project>), mapper);
        }

        [Test]
        public void GetMapperForCustomer()
        {
            IDataMapper<Customer> mapper = MiteDataMapperFactory.GetMapper<Customer>();

            Assert.IsInstanceOfType(typeof(IDataMapper<Customer>), mapper);
        }

        [Test]
        public void GetMapperForTimer()
        {
            IDataMapper<Timer> mapper = MiteDataMapperFactory.GetMapper<Timer>();

            Assert.IsInstanceOfType(typeof(IDataMapper<Timer>), mapper);
        }
    }
}