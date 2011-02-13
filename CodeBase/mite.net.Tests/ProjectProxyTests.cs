using NUnit.Framework;

namespace Mite.Tests
{
    [TestFixture]
    public class ProjectProxyTests
    {
        [Test]
        public void ProjectShouldBeEqualToProxy()
        {
            Project project = new Project
            {
                Id = 3,
                Name = "Test"
            };

            Project projectProxy = new ProjectProxy
            {
                Name = "Test",
                Id = 3
            };

            Assert.IsTrue(projectProxy.Equals(project));
        }

        [Test]
        public void ProxyShouldBeEqualToProject()
        {
            Project project = new Project
            {
                Id = 3,
                Name = "Test"
            };

            Project projectProxy = new ProjectProxy
            {
                Name = "Test",
                Id = 3
            };

            Assert.IsTrue(project.Equals(projectProxy));
        }

        [Test]
        public void ShouldBeEqualForSameInstance()
        {
            Project project = new Project();
            project.Name = "Test";

            Assert.IsTrue(project.Equals(project));
        }

        [Test]
        public void GetHashCodeShouldReturnSameValueForIdenticalObject()
        {
            Project p1 = new ProjectProxy();
            p1.Id = 1;

            Project p2 = new ProjectProxy();
            p2.Id = 1;

            int p1Hash = p1.GetHashCode();
            int p2Hash = p2.GetHashCode();
            
            Assert.AreEqual(p1Hash,p2Hash);
        }
    }
}